#region Usings

using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voLoginExistente : voBase
    {
        #region Propriedades e Atributos
        
        public string Login { get; set; }
        public int CodigoUsuario { get; set; }
        public bool LoginExiste { get; set; }

        #endregion
    }
}

#endregion