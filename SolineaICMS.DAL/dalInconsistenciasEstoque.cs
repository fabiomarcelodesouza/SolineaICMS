#region Usings

using System.Collections.Generic;
using System.Data;
using SolineaICMS.Databases;
using SolineaICMS.Util;
using SolineaICMS.VO;
using System;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalInconsistenciasEstoque : dalBase<voInconsistenciasEstoque>
    {
        #region Propriedades e Atributos

        public string ProcedureCorrigirIncosistenciaEstoque
        {
            get
            {
                return "SP_DIVERSOS_CARGA_INICIAL";
            }
        }

        #endregion

        #region Construtores

        public dalInconsistenciasEstoque()
        {
            base.ProcedureSelect = "SP_SELECT_INCONSISTENCIAS_ESTOQUE";
        }

        #endregion

        #region Métodos

        public void CorrigirInconsistencias(List<voInconsistenciasEstoque> listaInconsistencias)
        {
            //Instancia um objeto de acesso ao banco de dados
            Database = new FactoryDatabase<voInconsistenciasEstoque>(ProcedureCorrigirIncosistenciaEstoque, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using(IDbConnection cn = Database.Manage.Connection()){

                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {
                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    //Inicia uma transação com o banco de dados
                    using (IDbTransaction trans = Database.Manage.BeginTransaction(cn))
                    {
                        //Atribui a transação ao Command
                        cmd.Transaction = trans;

                        try
                        {
                            //Para cada inconsistencias selecionada, executa a correção
                            for (int i = 0; i < listaInconsistencias.Count; i++)
                            {
                                cmd.Parameters.Clear();

                                //Obtém a lista de parâmetros da procedure
                                List<IDbDataParameter> listParams = Database.Manage.GetParameters(listaInconsistencias[i], UtilEnums.ProcedureType.Other);

                                //Adiciona cada parâmetro da lista ao Command
                                for (int j = 0; j < listParams.Count; j++)
                                {
                                    cmd.Parameters.Add(listParams[j]);
                                }

                                cmd.ExecuteNonQuery();
                            }

                            //Commit na transação
                            Database.Manage.CommitTransaction(trans);
                        }
                        catch (Exception ex)
                        {
                            //Rollback na transação
                            Database.Manage.RollbackTransaction(trans);

                            throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, ProcedureCorrigirIncosistenciaEstoque);
                        }
                    }
                }
            }
        }

        #endregion
    }
}

#endregion