#region Usings

using System;
using System.Data;
using SolineaICMS.Databases;
using SolineaICMS.Util;
using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalUsuario : dalBase<voUsuario>
    {
        #region Propriedades e Atributos

        private string ProcedureLogin { get; set; }
        private string ProcedureVerificaLoginExistente { get; set; }

        #endregion

        #region Construtores

        public dalUsuario()
        {
            base.ProcedureSelect = "SP_SELECT_Tb002_Usuario";
            base.ProcedureInsert = "SP_INSERT_Tb002_Usuario";
            base.ProcedureUpdate = "SP_UPDATE_Tb002_Usuario";

            this.ProcedureLogin = "SP_DIVERSOS_LOGIN";
            this.ProcedureVerificaLoginExistente = "SP_SELECT_LOGIN_EXISTENTE";
        }

        #endregion

        #region Métodos

        public voUsuario Login(voUsuario voUsuario)
        {
            UtilLog.GerarLog(voUsuario.Login, "Tentativa de Login", UtilEnums.LogType.Outros);
            
            FactoryDatabase<voUsuario> database = new FactoryDatabase<voUsuario>(ProcedureLogin, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = database.Manage.Connection())
            {

                //Instancia um Command
                using (IDbCommand cmd = database.Manage.Command(cn))
                {

                    //Cria os parametros para utilização na procedure
                    IDbDataParameter pLogin = database.Manage.NewParameter();
                    pLogin.ParameterName = "Login";
                    pLogin.Value = voUsuario.Login;

                    IDbDataParameter pSenha = database.Manage.NewParameter();
                    pSenha.ParameterName = "Senha";
                    pSenha.Value = voUsuario.Senha;

                    cmd.Parameters.Add(pLogin);
                    cmd.Parameters.Add(pSenha);

                    //Abre a conexão com o banco e inicia uma transação
                    database.Manage.OpenConnection(cn);

                    try
                    {
                        //Lista com o retorno do método ManageSelect                
                        IDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            UtilLog.GerarLog(voUsuario.Login, "Login", UtilEnums.LogType.Outros);

                            voUsuario.CodigoUsuario = (int)dr["CodigoUsuario"];
                            voUsuario.Nome = dr["Nome"].ToString();
                            voUsuario.Perfil = dr["Perfil"].ToString();
                            voUsuario.Senha = null;
                        }
                        else
                        {
                            UtilLog.GerarLog(voUsuario.Login, "Erro de Login", UtilEnums.LogType.Outros);

                            voUsuario = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, ProcedureLogin);
                    }
                }
            }

            return voUsuario;
        }

        public voUsuario LoginExiste(voUsuario voUsuario)
        {
            FactoryDatabase<voUsuario> database = new FactoryDatabase<voUsuario>(ProcedureVerificaLoginExistente, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using(IDbConnection cn = database.Manage.Connection()){

                //Instancia um Command
                using (IDbCommand cmd = database.Manage.Command(cn))
                {

                    //Cria os parametros para utilização na procedure
                    IDbDataParameter pLogin = database.Manage.NewParameter();
                    pLogin.ParameterName = "Login";
                    pLogin.Value = voUsuario.Login;

                    cmd.Parameters.Add(pLogin);

                    //Abre a conexão com o banco e inicia uma transação
                    database.Manage.OpenConnection(cn);

                    try
                    {
                        //Lista com o retorno do método ManageSelect                
                        IDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            voUsuario.CodigoUsuario = (int)dr["CodigoUsuario"];
                        }
                        else
                        {
                            voUsuario = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, ProcedureVerificaLoginExistente);
                    }
                }
            }

            return voUsuario;
        }

        #endregion
    }
}

#endregion