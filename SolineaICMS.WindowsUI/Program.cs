using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SolineaICMS.WindowsUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
           
            frmLogin _frmLogin = new frmLogin();
            Application.Run(_frmLogin);
            //frmInconsistenciaEstoque teste = new frmInconsistenciaEstoque();
            //teste.Usuario = new VO.voUsuario(1);
            //Application.Run(teste);
           if (_frmLogin.DialogResult == DialogResult.OK)
                Application.Run(new frmPrincipal(_frmLogin.Usuario));
        }
    }
}
