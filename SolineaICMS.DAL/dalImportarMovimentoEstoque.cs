#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using SolineaICMS.Databases;
using SolineaICMS.Util;
using SolineaICMS.VO;
using System.IO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    /// <summary>
    /// Classe responsável pela importação dos arquivos Excel e por popular as tabelas necessárias
    /// </summary>
    public class dalImportarMovimentoEstoque
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
                return @"SELECT  Numero_Nota
                               , Data_Hora
                               , Tipo_Movimento
                               , CFOP
                               , Nome_Emitente_Destinatario
                               , CNPJ_CPF                               
                               , Uf
                               , NCM
                               , Codigo_Produto
                               , Nome_Produto
                               , Quantidade
                               , Unidade
                               , Valor
                               , ICMS_Proprio
                               , ICMS_ST
                          FROM [{0}]";
            }
        }

        private string ProcedureSelectPeriodoCoincidente
        {
            get
            {
                return "SP_SELECT_PERIODO_COINCIDENTE";
            }
        }

        public string ProcedureDeletePeriodoCoincidente
        {
            get
            {
                return "SP_DELETE_PERIODO_COINCIDENTE";
            }
        }

        private voUsuario Usuario { get; set; }

        #endregion

        #region Construtores

        public dalImportarMovimentoEstoque()
        { 
        }

        public dalImportarMovimentoEstoque(UtilEnums.FileType fileType, string filePath, voUsuario usuario)
        {
            this.FileType = fileType;
            this.FilePath = filePath;
            this.Usuario = usuario;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Importa os registros de uma arquivo para o banco de dados
        /// </summary>
        public void ImportarMovimentoEstoque()
        {
            UtilLog.InicioFimLog(Usuario.Login, UtilEnums.LogType.ImportarMovimentoEstoque);

            UtilLog.GerarLog(Usuario.Login, "Inicio da importação do movimento de estoque.", UtilEnums.LogType.ImportarMovimentoEstoque);

            //Instancia um objeto de acesso ao banco de dados
            this.Database = new FactoryDatabase<voBase>();

            dalRegistrosImportadosMovimentoEstoque dalRegistrosImportadosMovimentoEstoque = new dalRegistrosImportadosMovimentoEstoque();

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
                        dalRegistrosImportadosMovimentoEstoque.Delete(new voRegistrosImportadosMovimentoEstoque());

                        UtilLog.GerarLog(Usuario.Login, "Registros temporários excluidos.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        IDataReader dr = this.RecuperarMovimentoEstoque();

                        dalRegistrosImportadosMovimentoEstoque.Insert(dr);

                        UtilLog.GerarLog(Usuario.Login, "Registros temporários inseridos.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Commit na transação
                        Database.Manage.CommitTransaction(this.Transaction);
                    }
                    catch
                    {
                        //Rollback na transação
                        Database.Manage.RollbackTransaction(this.Transaction);

                        throw;
                    }
                    finally
                    {
                        if (CnFile.State == ConnectionState.Open)
                        {
                            CnFile.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Efetua o processamento dos dados do arquivo Excel
        /// </summary>        
        public void ProcessarMovimentoEstoque(voUsuario voUsuario)
        {
            UtilLog.GerarLog(Usuario.Login, "Inicio do processamento de movimento de estoque.", UtilEnums.LogType.ImportarMovimentoEstoque);

            //Instancia um objeto de acesso ao banco de dados
            this.Database = new FactoryDatabase<voBase>();

            dalPessoa dalPessoa = new dalPessoa();
            dalProduto dalProduto = new dalProduto();
            dalNotaFiscalEntrada dalNotaFiscalEntrada = new dalNotaFiscalEntrada();
            dalEstoque dalEstoque = new dalEstoque();
            dalNotaFiscalSaida dalNotaFiscalSaida = new dalNotaFiscalSaida();

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
                        //Exclui os ajustes sobrepostos
                        this.ExcluiAjustesSobrepostos();

                        UtilLog.GerarLog(Usuario.Login, "Ajustes sobrepostos excluídos.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Atualiza a tabela de Pessoas
                        dalPessoa.Update(new voPessoa(), this.CnImportacao, this.Transaction);

                        UtilLog.GerarLog(Usuario.Login, "Tabela Pessoa atualizada.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Popula a tabela de Pessoas
                        dalPessoa.Insert(new voPessoa(), this.CnImportacao, this.Transaction);

                        UtilLog.GerarLog(Usuario.Login, "Tabela Pessoa populada.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Popula a tabela Produtos
                        dalProduto.Insert(new voProduto(), this.CnImportacao, this.Transaction);

                        UtilLog.GerarLog(Usuario.Login, "Tabela Produto populada.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Popula a tabela de Notas Fiscais de Entrada
                        dalNotaFiscalEntrada.Insert(new voNotaFiscalEntrada(voUsuario), this.CnImportacao, this.Transaction);

                        UtilLog.GerarLog(Usuario.Login, "Tabela NotaFiscalEntrada populada.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Popula a tabela de Estoque
                        dalEstoque.Insert(new voEstoque(), this.CnImportacao, this.Transaction);

                        UtilLog.GerarLog(Usuario.Login, "Tabela Estoque populada.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Popula a tabela de Notas Fiscais de Saída
                        dalNotaFiscalSaida.Insert(new voNotaFiscalSaida(voUsuario), this.CnImportacao, this.Transaction);

                        UtilLog.GerarLog(Usuario.Login, "Tabela NotaFiscalSaida populada.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Vincula a tabela Estoque com a tabela de Movimento de Estoque
                        this.VincularEntradasSaidas();

                        UtilLog.GerarLog(Usuario.Login, "Término dos vinculos de entradas e saídas.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        //Commit na transação
                        Database.Manage.CommitTransaction(this.Transaction);

                        UtilLog.GerarLog(Usuario.Login, "Término do processamento.", UtilEnums.LogType.ImportarMovimentoEstoque);

                        UtilLog.InicioFimLog(Usuario.Login, UtilEnums.LogType.ImportarMovimentoEstoque);
                    }
                    catch
                    {
                        //Rollback na transação
                        Database.Manage.RollbackTransaction(this.Transaction);

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Recupera registros do arquivo
        /// </summary>        
        private IDataReader RecuperarMovimentoEstoque()
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
            this.CnFile = new OleDbConnection(String.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = Excel 12.0;", this.FilePath));

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

        /// <summary>
        /// Recupera o período coincidente com os registros importados
        /// </summary>
        /// <returns></returns>
        public string SelectPeriodoCoincidente()
        {
            string retorno = string.Empty;

            //Instancia um objeto de acesso ao banco de dados
            this.Database = new FactoryDatabase<voBase>(ProcedureSelectPeriodoCoincidente, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = Database.Manage.Connection())
            {
                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {
                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    try
                    {
                        //Lista com o retorno do método ManageSelect
                        IDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            retorno = dr[0].ToString();
                        }

                        return retorno;
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, ProcedureSelectPeriodoCoincidente);
                    }
                }
            }
        }

        /// <summary>
        /// Delete os registros com a data anterior ou coincidente com os registros importados
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <returns></returns>
        public int DeletePeriodoCoincidente(string dataInicial)
        {
            string retorno = string.Empty;

            //Instancia um objeto de acesso ao banco de dados
            this.Database = new FactoryDatabase<voBase>(ProcedureDeletePeriodoCoincidente, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = Database.Manage.Connection())
            {
                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {
                    IDbDataParameter pDataHoraEmissao = this.Database.Manage.NewParameter();
                    pDataHoraEmissao.ParameterName = "DataHoraEmissao";
                    pDataHoraEmissao.DbType = DbType.DateTime;
                    pDataHoraEmissao.Value = dataInicial;

                    cmd.Parameters.Add(pDataHoraEmissao);

                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    //Inicia uma transação com o banco de dados
                    using (IDbTransaction trans = Database.Manage.BeginTransaction(cn))
                    {
                        //Atribui a transação ao Command
                        cmd.Transaction = trans;

                        try
                        {
                            //Executa o comanndo
                            int result = cmd.ExecuteNonQuery();

                            //Commit na transação
                            Database.Manage.CommitTransaction(trans);

                            //Retorna o resultado
                            return result;
                        }
                        catch (Exception ex)
                        {
                            //Rollback na transação
                            Database.Manage.RollbackTransaction(trans);

                            throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, ProcedureDeletePeriodoCoincidente);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Deleta todos os ajustes sobrepostos
        /// </summary>        
        /// <returns>Inteiro</returns>
        public void ExcluiAjustesSobrepostos()
        {
            dalRegistrosImportadosMovimentoEstoque dalRegistrosImportadosMovimentoEstoque = new dalRegistrosImportadosMovimentoEstoque();
            IList<voRegistrosImportadosMovimentoEstoque> listaAjustesSaida = dalRegistrosImportadosMovimentoEstoque.SelectAjustesSaida(new voRegistrosImportadosMovimentoEstoque());

            for (int i = 0; i <= listaAjustesSaida.Count - 1; i++)
            {
                dalRegistrosImportadosMovimentoEstoque.DeleteAjustesSobrepostos(listaAjustesSaida[i]);
            }
        }

        /// <summary>
        /// Vincula o Movimento de Estoque com o Estoque
        /// </summary>
        private void VincularEntradasSaidas()
        {
            UtilLog.GerarLog(Usuario.Login, "Inicio da vinculação das notas fiscais de entrada e saída.", UtilEnums.LogType.ImportarMovimentoEstoque);

            //Quantidade total das Saídas
            decimal? quantidade = 0;

            //Quantidade restante das Saídas
            decimal? quantidadeRestante = 0;

            dalRegistrosImportadosMovimentoEstoque dalRegistrosImportadosMovimentoEstoque = new dalRegistrosImportadosMovimentoEstoque();
            IList<voRegistrosImportadosMovimentoEstoque> listRegistrosImportados;

            listRegistrosImportados = dalRegistrosImportadosMovimentoEstoque.SelectSaidasAjustesSaida(new voRegistrosImportadosMovimentoEstoque());

            FactoryDatabase<voVinculaEntradasSaidas> Database = new FactoryDatabase<voVinculaEntradasSaidas>("SP_DIVERSOS_VINCULA_ENTRADAS_SAIDAS", CommandType.StoredProcedure);
            using (IDbCommand cmd = Database.Manage.Command(this.CnImportacao))
            {
                //Atribui a transação ao Command
                cmd.Transaction = this.Transaction;

                try
                {
                    voRegistrosImportadosMovimentoEstoque registroImportado;

                    for (int contRegistrosImportados = 0; contRegistrosImportados < listRegistrosImportados.Count; contRegistrosImportados++)
                    {
                        registroImportado = listRegistrosImportados[contRegistrosImportados];

                        quantidade = registroImportado.Quantidade;

                        do
                        {
                            cmd.Parameters.Clear();

                            List<IDbDataParameter> listParams = Database.Manage.GetParameters(new voVinculaEntradasSaidas(registroImportado, quantidade), UtilEnums.ProcedureType.Other);

                            for (int i = 0; i < listParams.Count; i++)
                            {
                                cmd.Parameters.Add(listParams[i]);
                            }

                            cmd.ExecuteNonQuery();

                            quantidadeRestante = (decimal)listParams[9].Value;
                            registroImportado.Quantidade = quantidadeRestante;

                        } while (registroImportado.Quantidade != 0);
                    }

                    UtilLog.GerarLog(Usuario.Login, "Término da vinculação das notas fiscais de entrada e saída.", UtilEnums.LogType.ImportarMovimentoEstoque);
                }
                catch (Exception ex)
                {
                    UtilLog.GerarLog(Usuario.Login, String.Concat(((IDbDataParameter)cmd.Parameters[10]).Value.ToString(), " Quantidade que não pode ser vinculada: ", quantidade, "."), UtilEnums.LogType.ImportarMovimentoEstoque);
                    UtilLog.InicioFimLog(Usuario.Login, UtilEnums.LogType.ImportarMovimentoEstoque);

                    throw new CustomException(UtilConstants.MSG_ERRO_IMPORTAR_ARQUIVO, ex, String.Concat(((IDbDataParameter)cmd.Parameters[10]).Value.ToString(), " Quantidade que não pode ser vinculada: ", quantidade, "."));                    
                }
            }
        }

        /// <summary>
        /// Deleta todos os registros de todas as tabelas relacionadas a movimento da base de dados
        /// </summary>
        /// <param name="objeto">VO contendo o código do registro que será deletado</param>
        /// <returns>Inteiro</returns>
        public int DeleteGeral()
        {
            //Instancia um objeto de acesso ao banco de dados
            Database = new FactoryDatabase<voBase>("SP_DELETE_GERAL", CommandType.StoredProcedure);

            //Instancia uma nova conexão
            IDbConnection cn = Database.Manage.Connection();

            //Instancia um Command
            IDbCommand cmd = Database.Manage.Command(cn);

            //Abre a conexão com o banco e inicia uma transação
            Database.Manage.OpenConnection(cn);

            //Inicia uma transação com o banco de dados
            IDbTransaction trans = Database.Manage.BeginTransaction(cn);

            //Atribui a transação ao Command
            cmd.Transaction = trans;

            try
            {
                //Executa o comanndo
                int result = cmd.ExecuteNonQuery();

                //Commit na transação
                Database.Manage.CommitTransaction(trans);

                //Retorna o resultado
                return result;
            }
            catch (Exception ex)
            {
                //Rollback na transação
                Database.Manage.RollbackTransaction(trans);

                throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, "SP_DELETE_GERAL");
            }
            finally
            {
                //Fecha a conexão com o banco de dados
                Database.Manage.CloseConnection(cn);
            }
        }

        #endregion
    }
}

#endregion