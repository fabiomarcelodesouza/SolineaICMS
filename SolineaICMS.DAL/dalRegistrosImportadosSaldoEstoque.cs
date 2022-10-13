#region Usings

using SolineaICMS.VO;
using System.Data;
using SolineaICMS.Util;
using System.Data.SqlClient;
using System;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalRegistrosImportadosSaldoEstoque : dalBase<voRegistrosImportadosSaldoEstoque>
    {
        #region Construtores

        public dalRegistrosImportadosSaldoEstoque()
        {
            base.ProcedureSelect = "SP_SELECT_Tb012_RegistrosImportados_SaldoEstoque";
            base.ProcedureInsert = "SP_INSERT_Tb012_RegistrosImportados_SaldoEstoque";
            base.ProcedureDelete = "SP_DELETE_Tb012_RegistrosImportados_SaldoEstoque";
        }

        #endregion

        #region Métodos

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
                        bulkCopy.DestinationTableName = "Tb012_RegistrosImportados_SaldoEstoque";

                        bulkCopy.ColumnMappings.Add("Codigo_Produto", "CodigoProdutoCliente");
                        bulkCopy.ColumnMappings.Add("Nome_Produto", "NomeProduto");
                        bulkCopy.ColumnMappings.Add("Ncm", "Ncm");
                        bulkCopy.ColumnMappings.Add("Quantidade", "Quantidade");
                        bulkCopy.ColumnMappings.Add("Unidade", "UnidadeMedida");

                        bulkCopy.WriteToServer(dr);
                    }
                    break;
                default:
                    dalRegistrosImportadosSaldoEstoque dalRegistrosImportadosSaldoEstoque = new dalRegistrosImportadosSaldoEstoque();
                    voRegistrosImportadosSaldoEstoque voRegistrosImportadosSaldoEstoque;

                    //Enquando o DataReader puder ser lido (houver registros)
                    while (dr.Read())
                    {
                        //Cria um novo objeto do tipo voRegistrosImportadosSaldoEstoque
                        voRegistrosImportadosSaldoEstoque = new voRegistrosImportadosSaldoEstoque();

                        voRegistrosImportadosSaldoEstoque.CodigoProdutoCliente = dr["CodigoProdutoCliente"].ToString();
                        voRegistrosImportadosSaldoEstoque.NomeProduto = dr["NomeProduto"].ToString();
                        voRegistrosImportadosSaldoEstoque.Quantidade = Convert.ToDecimal(dr["Quantidade"]);
                        voRegistrosImportadosSaldoEstoque.UnidadeMedida = dr["UnidadeMedida"].ToString();

                        dalRegistrosImportadosSaldoEstoque.Insert(voRegistrosImportadosSaldoEstoque);
                    }

                    break;
            }
        }

        #endregion
    }
}

#endregion