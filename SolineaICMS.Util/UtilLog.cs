using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SolineaICMS.Util
{
    public class UtilLog
    {
        public static void InicioFimLog(string usuario, UtilEnums.LogType LogType)
        {
            if (String.IsNullOrEmpty(usuario))
            {
                throw new Exception("Arquivo de Log não pode ser gerado: Usuário não foi informado. PROCESSAMENTO CANCELADO.");
            }
            else
            {
                // Specify a "currently active folder"
                string folder = AppDomain.CurrentDomain.BaseDirectory + "Log";                

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                StreamWriter sw = null;

                switch (LogType)
                {
                    case UtilEnums.LogType.ImportarSaldoEstoque:
                        sw = File.AppendText(folder + @"\LogImportarSaldoEstoque.txt");
                        break;
                    case UtilEnums.LogType.ImportarMovimentoEstoque:
                        sw = File.AppendText(folder + @"\LogImportarMovimentoEstoque.txt");
                        break;
                    default:
                        break;
                }

                sw.WriteLine("-----------------------------------------" + DateTime.Now.ToString() + " - " + usuario + "-----------------------------------------");
                sw.Close();
            }
        }

        public static void GerarLog(string usuario, string texto, UtilEnums.LogType LogType)
        {
            if (String.IsNullOrEmpty(usuario))
            {
                throw new Exception("Arquivo de Log não pode ser gerado: Usuário não foi informado. PROCESSAMENTO CANCELADO.");
            }
            else if (String.IsNullOrEmpty(usuario))
            {
                throw new Exception("Arquivo de Log não pode ser gerado: Texto não foi informado. PROCESSAMENTO CANCELADO.");
            }
            else
            {
                string folder = AppDomain.CurrentDomain.BaseDirectory + "Log";         

                StreamWriter sw = null;

                switch (LogType)
                {
                    case UtilEnums.LogType.ImportarSaldoEstoque:
                        sw = File.AppendText(folder + @"\LogImportarSaldoEstoque.txt");
                        break;
                    case UtilEnums.LogType.ImportarMovimentoEstoque:
                        sw = File.AppendText(folder + @"\LogImportarMovimentoEstoque.txt");
                        break;
                    case UtilEnums.LogType.Outros:
                        sw = File.AppendText(folder + @"\LogOutros.txt");
                        break;
                    default:
                        break;
                }

                sw.WriteLine(DateTime.Now.ToString() + " - " + usuario.PadRight(15, ' ') + " - " + texto);
                sw.Close();
            }
        }
    }
}
