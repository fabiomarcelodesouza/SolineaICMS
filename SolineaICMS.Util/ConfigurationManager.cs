#region Usings

using System.Web;

#endregion

#region Class

namespace SolineaICMS.Util
{
    public static class ConfigurationManager
    {
        /// <summary>
        /// Define a base de dados dependendo da configuração no Web.Config
        /// </summary>
        public static UtilEnums.Database BaseDeDados
        {
            get
            {
                switch (System.Configuration.ConfigurationManager.AppSettings["Database"].ToString())
                {
                    case "SqlServer":
                        return UtilEnums.Database.SQLServer;
                    default:
                        throw new System.NotImplementedException("Banco de dados incompatível com o sistema Solinea ICMS, verifique as configurações do sistema.");
                }
            }
        }

        /// <summary>
        /// Plataforma em que o sistema está rodando (Web ou Desktop)
        /// </summary>
        public static string Plataforma
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Plataforma"].ToString();
            }
        }

        /// <summary>
        /// Local de acesso em que o sistema está rodando (Local ou Remoto)
        /// </summary>
        public static string LocalAcesso
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["LocalAcesso"].ToString();
            }
        }

        /// <summary>
        /// Retorna a string de conexão dependendo da configuração
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (Plataforma.Equals("Web"))
                {
                    if (BaseDeDados.ToString().ToUpper().Equals("SQLSERVER"))
                    {
                        if (LocalAcesso.ToString().Equals("Local"))
                        {
                            return System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString();
                        }
                        else if (LocalAcesso.ToString().Equals("Remoto"))
                        {
                            return System.Configuration.ConfigurationManager.ConnectionStrings["RemoteSqlServer"].ToString();
                        }
                        else
                        {
                            throw new System.NotImplementedException("Local de acesso imcompatível com o sistema Solinea ICMS, verifique as configurações do sistema.");
                        }
                    }
                    else
                    {
                        throw new System.NotImplementedException("Banco de dados incompatível com o sistema Solinea ICMS, verifique as configurações do sistema.");
                    }
                }
                else if (Plataforma.ToString().Equals("Desktop"))
                {
                    if (LocalAcesso.ToString().Equals("Local"))
                    {
                        return System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString();
                    }
                    else if (LocalAcesso.ToString().Equals("Remoto"))
                    {
                        return System.Configuration.ConfigurationManager.ConnectionStrings["RemoteSqlServer"].ToString();
                    }
                    else
                    {
                        throw new System.NotImplementedException("Local de acesso imcompatível com o sistema Solinea ICMS, verifique as configurações do sistema.");
                    }
                }
                else
                {
                    throw new System.NotImplementedException("Plataforma incompatível com o sistema Solinea ICMS, verifique as configurações do sistema.");
                }
            }
        }

        public static string NomeBancoDados
        {
            get
            {
                if (LocalAcesso.Equals("Local"))
                {
                    return System.Configuration.ConfigurationManager.AppSettings["NomeBancoDadosLocal"].ToString();
                }
                else if (LocalAcesso.Equals("Remoto"))
                {
                    return System.Configuration.ConfigurationManager.AppSettings["NomeBancoDadosRemoto"].ToString();
                }
                else
                {
                    throw new System.NotImplementedException("Local de acesso imcompatível com o sistema Solinea ICMS, verifique as configurações do sistema.");
                }
            }
        }

        public static string NomeEmpresa
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["NomeEmpresa"].ToString();
            }
        }

        public static string CnpjEmpresa
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["CnpjEmpresa"].ToString();
            }
        }

        public static string EmailSuporte
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["EmailSuporte"].ToString();
            }
        }

        public static string TelefoneSuporte
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["TelefoneSuporte"].ToString();
            }
        }
    }
}

#endregion