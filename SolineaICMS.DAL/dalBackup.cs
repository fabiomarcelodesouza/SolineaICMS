#region Usings

using System;
using System.Data;
using SolineaICMS.Databases;
using SolineaICMS.Util;
using SolineaICMS.VO;
using System.IO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalBackup : dalBase<voBackup>
    {
        #region Propriedades e Atributos

        private string ProcedureBackup
        {
            get
            {
                return "SP_DIVERSOS_BACKUP";
            }
        }

        #endregion

        #region Métodos

        public void EfetuarBackup(voBackup voBackup)
        {
            // Specify a "currently active folder"
            string folder = AppDomain.CurrentDomain.BaseDirectory + "BackupBancoDados";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            FactoryDatabase<voBackup> database = new FactoryDatabase<voBackup>(this.ProcedureBackup, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = database.Manage.Connection())
            {

                //Instancia um Command
                using (IDbCommand cmd = database.Manage.Command(cn))
                {

                    //Cria os parametros para utilização na procedure
                    IDbDataParameter pNomeBanco = database.Manage.NewParameter();
                    pNomeBanco.ParameterName = "NomeBanco";
                    pNomeBanco.Value = voBackup.NomeBancoDados;

                    IDbDataParameter pCaminho = database.Manage.NewParameter();
                    pCaminho.ParameterName = "Caminho";
                    pCaminho.Value = String.Concat(folder, "\\teste.bak");

                    cmd.Parameters.Add(pNomeBanco);
                    cmd.Parameters.Add(pCaminho);

                    //Abre a conexão com o banco e inicia uma transação
                    database.Manage.OpenConnection(cn);

                    try
                    {
                        //Lista com o retorno do método ManageSelect                
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        #endregion
    }
}

#endregion