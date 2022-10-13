//using System.Configuration;
using System.Data;
using SolineaICMS.Databases;
using SolineaICMS.Interfaces;
using SolineaICMS.Util;

namespace SolineaICMS.Databases
{
    public class FactoryDatabase<T>
    {
        public IDatabase<T> Manage { get; set; }        

        public FactoryDatabase()
        {
            switch (ConfigurationManager.BaseDeDados)
            {
                case UtilEnums.Database.SQLServer:
                    this.Manage = new SQLServer<T>();
                    break;
                default:
                    throw new System.NotImplementedException("Banco de dados incompatível com o sistema Solinea ICMS, verifique as configurações do sistema.");
            }
        }

        public FactoryDatabase(string operation, CommandType commandType)
        {
            switch (ConfigurationManager.BaseDeDados)
            {
                case UtilEnums.Database.SQLServer:
                    this.Manage = new SQLServer<T>(operation, commandType);
                    break;
                default:
                    throw new System.NotImplementedException("Banco de dados incompatível com o sistema Solinea ICMS, verifique as configurações do sistema.");
            }
        }
    }
}
