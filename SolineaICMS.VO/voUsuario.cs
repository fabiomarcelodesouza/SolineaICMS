#region Usings

using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voUsuario : voBase
    {
        #region Propriedades e Atributos

        [UtilAttributes.ProcedureParameter(DbType.Int32, true, false, true, true)]
        public int? CodigoUsuario { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, true, true, false)]
        public string Nome { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, true, true, false)]
        public string Login { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, true, true, false)]
        public string Senha { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, true, true, false)]        
        public string Perfil { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Boolean, true, true, true, false)]
        public bool? Ativo { get; set; }

        #endregion

        #region Construtores

        public voUsuario()
        {
        }

        public voUsuario(int codigoUsuario)
        {
            this.CodigoUsuario = codigoUsuario;
        }

        public voUsuario(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }
        #endregion
    }
}

#endregion