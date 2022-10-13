#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SolineaICMS.Databases;
using SolineaICMS.Util;
using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalRegistrosImportadosMovimentoEstoque : dalBase<voRegistrosImportadosMovimentoEstoque>
    {
        #region Propriedades e Atributos

        /// <summary>
        /// Nome da procedure de "Select das Saidas e Ajustes de Saida"
        /// </summary>
        private string ProcedureSelectSaidasAjustesSaida
        {
            get
            {
                return "SP_SELECT_Tb011_RegistrosImportados_MovimentoEstoque_Saidas_AjustesSaida";
            }
        }

        /// <summary>
        /// Nome da procedure de "Select dos Ajustes de Saida"
        /// </summary>
        private string ProcedureSelectAjustesSaida
        {
            get
            {
                return "SP_SELECT_Tb011_RegistrosImportados_MovimentoEstoque_AjustesSaida";
            }
        }

        /// <summary>
        /// Nome da procedure de "Select dos Ajustes de Entrada"
        /// </summary>
        private string ProcedureSelectAjustesEntrada
        {
            get
            {
                return "SP_SELECT_Tb011_RegistrosImportados_MovimentoEstoque_AjustesEntrada";
            }
        }

        /// <summary>
        /// Nome da procedure de "Delete ajustes sobrepostos"
        /// </summary>
        private string ProcedureDeleteAjustesSobrepostos
        {
            get
            {
                return "SP_DELETE_AJUSTES_SOBREPOSTOS";
            }
        }
        #endregion

        #region Construtores

        public dalRegistrosImportadosMovimentoEstoque()
        {
            base.ProcedureSelect = "SP_SELECT_Tb011_RegistrosImportados_MovimentoEstoque";
            base.ProcedureInsert = "SP_INSERT_Tb011_RegistrosImportados_MovimentoEstoque";
            base.ProcedureDelete = "SP_DELETE_Tb011_RegistrosImportados_MovimentoEstoque";
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Recupera as Saidas e Ajustes de Saida
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns>IList de VO do tipo voRegistrosImportadosMovimentoEstoque</returns>
        public IList<voRegistrosImportadosMovimentoEstoque> SelectSaidasAjustesSaida(voRegistrosImportadosMovimentoEstoque objeto)
        {
            //Instancia um objeto de acesso ao banco de dados
            base.Database = new FactoryDatabase<voRegistrosImportadosMovimentoEstoque>(this.ProcedureSelectSaidasAjustesSaida, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = Database.Manage.Connection())
            {
                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {

                    //Obtém a lista de parâmetros da procedure
                    List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Other);

                    //Adiciona cada parâmetro da lista ao Command
                    foreach (IDbDataParameter item in listParams)
                    {
                        cmd.Parameters.Add(item);
                    }

                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    try
                    {
                        //Lista com o retorno do método ManageSelect
                        IList<voRegistrosImportadosMovimentoEstoque> listManageSelect = ManageSelect(cmd.ExecuteReader(), objeto);

                        //Retorna a lista
                        return listManageSelect;
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, ProcedureSelectSaidasAjustesSaida);
                    }
                }
            }
        }

        /// <summary>
        /// Recupera os Ajustes de Saida
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns>IList de VO do tipo voRegistrosImportadosMovimentoEstoque</returns>
        public IList<voRegistrosImportadosMovimentoEstoque> SelectAjustesSaida(voRegistrosImportadosMovimentoEstoque objeto)
        {
            //Instancia um objeto de acesso ao banco de dados
            base.Database = new FactoryDatabase<voRegistrosImportadosMovimentoEstoque>(this.ProcedureSelectAjustesSaida, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using(IDbConnection cn = Database.Manage.Connection()){

                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {

                    //Obtém a lista de parâmetros da procedure
                    List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Other);

                    //Adiciona cada parâmetro da lista ao Command
                    foreach (IDbDataParameter item in listParams)
                    {
                        cmd.Parameters.Add(item);
                    }

                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    try
                    {
                        //Lista com o retorno do método ManageSelect
                        IList<voRegistrosImportadosMovimentoEstoque> listManageSelect = ManageSelect(cmd.ExecuteReader(), objeto);

                        //Retorna a lista
                        return listManageSelect;
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, ProcedureSelectAjustesSaida);
                    }
                }
            }
        }

        /// <summary>
        /// Recupera os Ajustes de Entrada
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns>IList de VO do tipo voRegistrosImportadosMovimentoEstoque</returns>
        public IList<voRegistrosImportadosMovimentoEstoque> SelectAjustesEntrada(voRegistrosImportadosMovimentoEstoque objeto)
        {
            //Instancia um objeto de acesso ao banco de dados
            base.Database = new FactoryDatabase<voRegistrosImportadosMovimentoEstoque>(this.ProcedureSelectAjustesEntrada, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            IDbConnection cn = Database.Manage.Connection();

            //Instancia um Command
            IDbCommand cmd = Database.Manage.Command(cn);

            //Obtém a lista de parâmetros da procedure
            List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Other);

            //Adiciona cada parâmetro da lista ao Command
            foreach (IDbDataParameter item in listParams)
            {
                cmd.Parameters.Add(item);
            }

            //Abre a conexão com o banco e inicia uma transação
            Database.Manage.OpenConnection(cn);

            try
            {
                //Lista com o retorno do método ManageSelect
                IList<voRegistrosImportadosMovimentoEstoque> listManageSelect = ManageSelect(cmd.ExecuteReader(), objeto);

                //Retorna a lista
                return listManageSelect;
            }
            catch (Exception ex)
            {
                throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, ProcedureSelectAjustesEntrada);
            }
            finally
            {
                //Fecha a conexão com o banco de dados
                Database.Manage.CloseConnection(cn);
            }
        }

        /// <summary>
        /// Deleta os ajustes sobrepostos
        /// </summary>
        /// <param name="objeto"></param>
        public void DeleteAjustesSobrepostos(voRegistrosImportadosMovimentoEstoque objeto)
        {
            //Instancia um objeto de acesso ao banco de dados
            base.Database = new FactoryDatabase<voRegistrosImportadosMovimentoEstoque>(this.ProcedureDeleteAjustesSobrepostos, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using(IDbConnection cn = Database.Manage.Connection()){

                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {
                    //Cria os parametros para utilização na procedure
                    IDbDataParameter pCodigoRegistrosImportados_MovimentoEstoque = Database.Manage.NewParameter();
                    pCodigoRegistrosImportados_MovimentoEstoque.ParameterName = "CodigoRegistrosImportados_MovimentoEstoque";
                    pCodigoRegistrosImportados_MovimentoEstoque.Value = objeto.CodigoRegistrosImportados_MovimentoEstoque;

                    IDbDataParameter pDataHoraEmissao = Database.Manage.NewParameter();
                    pDataHoraEmissao.ParameterName = "DataHoraEmissao";
                    pDataHoraEmissao.Value = objeto.DataHoraEmissao;

                    IDbDataParameter pQuantidade = Database.Manage.NewParameter();
                    pQuantidade.ParameterName = "Quantidade";
                    pQuantidade.Value = objeto.Quantidade;

                    IDbDataParameter pCodigoProdutoCliente = Database.Manage.NewParameter();
                    pCodigoProdutoCliente.ParameterName = "CodigoProdutoCliente";
                    pCodigoProdutoCliente.Value = objeto.CodigoProdutoCliente;

                    cmd.Parameters.Add(pCodigoRegistrosImportados_MovimentoEstoque);
                    cmd.Parameters.Add(pDataHoraEmissao);
                    cmd.Parameters.Add(pQuantidade);
                    cmd.Parameters.Add(pCodigoProdutoCliente);

                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, ProcedureDeleteAjustesSobrepostos);
                    }
                }
            }
        }

        /// <summary>
        /// Insere os registros recuperados na base
        /// </summary>
        /// <param name="dr"></param>
        public void Insert(IDataReader dr)
        {
            switch (ConfigurationManager.BaseDeDados)
            {
                case UtilEnums.Database.SQLServer:
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionString, SqlBulkCopyOptions.UseInternalTransaction))
                    {
                        bulkCopy.BulkCopyTimeout = 0;
                        bulkCopy.DestinationTableName = "Tb011_RegistrosImportados_MovimentoEstoque";

                        bulkCopy.ColumnMappings.Add("Numero_Nota", "NumeroNota");
                        bulkCopy.ColumnMappings.Add("Data_Hora", "DataHoraEmissao");
                        bulkCopy.ColumnMappings.Add("Tipo_Movimento", "TipoNota");
                        bulkCopy.ColumnMappings.Add("CFOP", "Cfop");
                        bulkCopy.ColumnMappings.Add("Nome_Emitente_Destinatario", "NomeEmitenteDestinatario");
                        bulkCopy.ColumnMappings.Add("CNPJ_CPF", "CnpjCpfEmitenteDestinatario");
                        //bulkCopy.ColumnMappings.Add("Inscricao_Estadual", "InscricaoEstadualEmitenteDestinatario");
                        bulkCopy.ColumnMappings.Add("UF", "UfEmitenteDestinatario");
                        bulkCopy.ColumnMappings.Add("NCM", "Ncm");
                        bulkCopy.ColumnMappings.Add("Codigo_Produto", "CodigoProdutoCliente");
                        bulkCopy.ColumnMappings.Add("Nome_Produto", "NomeProduto");
                        bulkCopy.ColumnMappings.Add("Quantidade", "Quantidade");
                        bulkCopy.ColumnMappings.Add("Unidade", "UnidadeMedida");
                        bulkCopy.ColumnMappings.Add("Valor", "Valor");
                        bulkCopy.ColumnMappings.Add("ICMS_Proprio", "IcmsProprio");
                        bulkCopy.ColumnMappings.Add("ICMS_ST", "IcmsSt");

                        bulkCopy.WriteToServer(dr);
                    }
                    break;
                default:
                    dalRegistrosImportadosMovimentoEstoque dalRegistrosImportadosMovimentoEstoque = new dalRegistrosImportadosMovimentoEstoque();
                    voRegistrosImportadosMovimentoEstoque voRegistrosImportadosMovimentoEstoque;

                    //Enquando o DataReader puder ser lido (houver registros)
                    while (dr.Read())
                    {
                        //Cria um novo objeto do tipo voRegistrosImportadosMovimentoEstoque
                        voRegistrosImportadosMovimentoEstoque = new voRegistrosImportadosMovimentoEstoque();

                        //Se o numero da nota não for nulo, popula a propriedade com o numero da nota
                        if (dr["NumeroNota"] != DBNull.Value)
                        {
                            voRegistrosImportadosMovimentoEstoque.NumeroNota = Convert.ToInt32(dr["NumeroNota"]);
                        }
                        //Caso contrário, popula com o valor Zero
                        else
                        {
                            voRegistrosImportadosMovimentoEstoque.NumeroNota = 0;
                        }

                        //Popula a propriedade com a data e hora de emissão da nota fiscal
                        voRegistrosImportadosMovimentoEstoque.DataHoraEmissao = Convert.ToDateTime(dr["DataHoraEmissao"]);

                        //Popula a propriedade com o tipo de nota fiscal
                        voRegistrosImportadosMovimentoEstoque.TipoNota = dr["TipoNota"].ToString();

                        //Se o CFOP da nota não for nulo, popula a propriedade com o CFOP
                        if (dr["Cfop"] != DBNull.Value)
                        {
                            voRegistrosImportadosMovimentoEstoque.Cfop = Convert.ToInt32(dr["Cfop"]);
                        }
                        //Caso contrário, popula com o valor nulo
                        else
                        {
                            voRegistrosImportadosMovimentoEstoque.Cfop = null;
                        }

                        //Se o Nome do Emitente ou Destinatário da nota não for nulo, popula a propriedade com o Nome
                        if (dr["NomeEmitenteDestinatario"] != DBNull.Value)
                        {
                            voRegistrosImportadosMovimentoEstoque.NomeEmitenteDestinatario = dr["NomeEmitenteDestinatario"].ToString();
                        }
                        //Caso contrário, popula com o valor nulo
                        else
                        {
                            voRegistrosImportadosMovimentoEstoque.NomeEmitenteDestinatario = null;
                        }

                        //Popula a propriedade com o Cnpj ou Cpf
                        voRegistrosImportadosMovimentoEstoque.CnpjCpfEmitenteDestinatario = dr["CnpjCpfEmitenteDestinatario"].ToString();

                        //Popula a propriedade com a Inscrição Estadual
                        voRegistrosImportadosMovimentoEstoque.InscricaoEstadualEmitenteDestinatario = dr["InscricaoEstadualEmitenteDestinatario"].ToString();

                        //Se a UF do Emitente ou Destinatário da nota não for nulo, popula a propriedade com a UF
                        if (dr["UfEmitenteDestinatario"] != DBNull.Value)
                        {
                            voRegistrosImportadosMovimentoEstoque.UfEmitenteDestinatario = dr["UfEmitenteDestinatario"].ToString();
                        }
                        //Caso contrário, popula com o valor nulo
                        else
                        {
                            voRegistrosImportadosMovimentoEstoque.UfEmitenteDestinatario = null;
                        }

                        //Se o NCM do produto não for nulo, popula a propriedade com o NCM
                        if (dr["Ncm"] != DBNull.Value)
                        {
                            voRegistrosImportadosMovimentoEstoque.Ncm = Convert.ToInt64(dr["Ncm"]);
                        }
                        //Caso contrário, popula com o valor nulo
                        else
                        {
                            voRegistrosImportadosMovimentoEstoque.Ncm = null;
                        }

                        //Popula a propriedade com o codigo do produto no cliente
                        voRegistrosImportadosMovimentoEstoque.CodigoProdutoCliente = dr["CodigoProdutoCliente"].ToString();

                        //Popula a propriedade com o nome do produto
                        voRegistrosImportadosMovimentoEstoque.NomeProduto = dr["NomeProduto"].ToString();

                        //Popula a propriedade com a quantidade do produto
                        voRegistrosImportadosMovimentoEstoque.Quantidade = Convert.ToDecimal(dr["Quantidade"]);

                        //Se o valor do produto não for nulo, popula a propriedade com o Valor
                        if (dr["Valor"] != DBNull.Value)
                        {
                            voRegistrosImportadosMovimentoEstoque.Valor = Convert.ToDecimal(dr["Valor"]);
                        }
                        //Caso contrário, popula com o valor nulo
                        else
                        {
                            voRegistrosImportadosMovimentoEstoque.Valor = null;
                        }

                        //Se o ICMS Proprio do produto não for nulo, popula a propriedade com o ICMS Proprio
                        if (dr["IcmsProprio"] != DBNull.Value)
                        {
                            voRegistrosImportadosMovimentoEstoque.IcmsProprio = Convert.ToDecimal(dr["IcmsProprio"]);
                        }
                        //Caso contrário, popula com o valor nulo
                        else
                        {
                            voRegistrosImportadosMovimentoEstoque.IcmsProprio = null;
                        }

                        //Se o ICMS ST do produto não for nulo, popula a propriedade com o ICMS ST
                        if (dr["IcmsSt"] != DBNull.Value)
                        {
                            voRegistrosImportadosMovimentoEstoque.IcmsSt = Convert.ToDecimal(dr["IcmsSt"]);
                        }
                        //Caso contrário, popula com o valor nulo
                        else
                        {
                            voRegistrosImportadosMovimentoEstoque.IcmsSt = null;
                        }

                        //Insere o registro na base
                        dalRegistrosImportadosMovimentoEstoque.Insert(voRegistrosImportadosMovimentoEstoque);
                    }

                    break;
            }
        }

        #endregion
    }
}

#endregion