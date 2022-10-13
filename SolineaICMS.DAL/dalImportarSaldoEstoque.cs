#region Usings

using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using SolineaICMS.Databases;
using SolineaICMS.Util;
using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    /// <summary>
    /// Classe responsável pela importação dos arquivos Excel e por popular as tabelas necessárias
    /// </summary>
    public class dalImportarSaldoEstoque
    {
        #region Propriedades e Atributos

        /// <summary>
        /// Conexão OLEDB para leitura do arquivo
        /// </summary>
        private OleDbConnection CnFile { get; set; }

        /// <summary>
        /// Conexão com o banco de dados
        /// </summary>
        private IDbConnection CnImportacao { get; set; }

        /// <summary>
        /// Transação com o banco de dados
        /// </summary>
        private IDbTransaction Transaction { get; set; }

        /// <summary>
        /// Tipo do arquivo
        /// </summary>
        public UtilEnums.FileType FileType { get; set; }

        /// <summary>
        /// Nome e caminho do arquivo
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Classe de acesso a dados
        /// </summary>
        private FactoryDatabase<voBase> Database { get; set; }

        /// <summary>
        /// Instrução select a ser executada contra o arquivo Excel
        /// </summary>
        private string SelectExcel
        {
            get
            {
                return @"SELECT   Codigo_Produto
                               , Nome_Produto
                               , Ncm
                               , SUM(Quantidade) as Quantidade
                               , Unidade
                          FROM [{0}] 
                         GROUP BY   Codigo_Produto
                                  , Nome_Produto
                                  , Ncm
                                  , Unidade";
            }
        }

        #endregion

        #region Construtores

        public dalImportarSaldoEstoque(UtilEnums.FileType fileType, string filePath)
        {
            this.FileType = fileType;
            this.FilePath = filePath;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Efetua o processamento dos dados do arquivo Excel
        /// </summary>        
        public void ImportarSaldoEstoque()
        {
            //Instancia um objeto de acesso ao banco de dados
            this.Database = new FactoryDatabase<voBase>();

            dalRegistrosImportadosSaldoEstoque dalRegistrosImportadosSaldoEstoque = new dalRegistrosImportadosSaldoEstoque();

            //Instancia uma nova conexão
            using (this.CnImportacao = Database.Manage.Connection())
            {
                //Abre a conexão com o banco e inicia uma transação
                Database.Manage.OpenConnection(this.CnImportacao);

                //Inicia uma transação com o banco de dados
                using (this.Transaction = Database.Manage.BeginTransaction(this.CnImportacao))
                {
                    try
                    {
                        //Deleta os registros importados temporariamente
                        dalRegistrosImportadosSaldoEstoque.Delete(new voRegistrosImportadosSaldoEstoque());

                        IDataReader dr = this.RecuperarSaldoEstoque();
                        dalRegistrosImportadosSaldoEstoque.Insert(dr);

                        this.CnFile.Close();

                        //Commit na transação
                        Database.Manage.CommitTransaction(this.Transaction);
                    }
                    catch (Exception ex)
                    {
                        //Rollback na transação
                        Database.Manage.RollbackTransaction(this.Transaction);

                        throw new CustomException(UtilConstants.MSG_ERRO_IMPORTAR_ARQUIVO, ex, UtilConstants.CAUSA_PROVAVEL_ERRO_IMPORTAR_ARQUIVO);
                    }
                }
            }
        }

        /// <summary>
        /// Recupera os registros do arquivo
        /// </summary>        
        private IDataReader RecuperarSaldoEstoque()
        {
            //Instancia um DataReader
            IDataReader dr;

            switch (this.FileType)
            {
                //Caso seja um arquivo do Excel 2003 ou anterior
                case UtilEnums.FileType.xls:
                    dr = ReadExcel2003();
                    break;
                //Caso seja um arquivo do Excel 2007/2010
                case UtilEnums.FileType.xlsx:
                    dr = ReadExcel2007();
                    break;
                //Caso seja um arquivo XML
                case UtilEnums.FileType.xml:
                    dr = ReadXml();
                    break;
                default:
                    dr = null;
                    break;
            }

            return dr;
        }

        /// <summary>
        /// Efetua a leitura dos registros de um arquivo Excel 2003 ou anterior
        /// </summary>        
        /// <returns>IDataReader</returns>
        private IDataReader ReadExcel2003()
        {
            //Intancia uma conexão OLEDB para leitura do arquivo
            this.CnFile = new OleDbConnection(String.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = Excel 8.0;", this.FilePath));

            //Instancia Datatable para armazenar as tables do arquivo Excel
            DataTable workbooks = new DataTable();

            //Abre a conexão
            this.CnFile.Open();

            //Obtém as planilhas do Excel
            workbooks = this.CnFile.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            //Se não houver planilhas no arquivo
            if (workbooks == null)
            {
                throw new CustomException(String.Format("O arquivo selecionado não contém nenhum planilha."));
            }

            IDataReader dr;

            //Define o Command
            using (OleDbCommand cmd = new OleDbCommand(String.Format(this.SelectExcel, workbooks.Rows[0]["TABLE_NAME"]), this.CnFile))
            {
                //Executa o Command
                dr = cmd.ExecuteReader();
            }

            //Retorna o Datareader
            return dr;
        }

        /// <summary>
        /// Efetua a leitura dos registros de um arquivo Excel 2007/2010
        /// </summary>        
        /// <returns>IDataReader</returns>
        private IDataReader ReadExcel2007()
        {
            //Intancia uma conexão OLEDB para leitura do arquivo
            this.CnFile = new OleDbConnection(String.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0';", this.FilePath));

            //Instancia Datatable para armazenar as tables do arquivo Excel
            DataTable workbooks = new DataTable();

            //Abre a conexão
            this.CnFile.Open();

            //Obtém as planilhas do Excel
            workbooks = this.CnFile.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            //Se não houver planilhas no arquivo
            if (workbooks == null)
            {
                throw new CustomException(String.Format("O arquivo selecionado não contém nenhum planilha."));
            }

            IDataReader dr;

            //Define o Command
            using (OleDbCommand cmd = new OleDbCommand(String.Format(this.SelectExcel, workbooks.Rows[0]["TABLE_NAME"]), this.CnFile))
            {
                //Executa o Command
                dr = cmd.ExecuteReader();
            }

            //Retorna o Datareader
            return dr;
        }

        /// <summary>
        /// Efetua a leitura dos registros de um arquivo XML
        /// </summary>        
        /// <returns>IDataReader</returns>
        private IDataReader ReadXml()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

#endregion