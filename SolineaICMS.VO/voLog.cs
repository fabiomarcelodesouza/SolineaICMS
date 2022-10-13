#region Usings

using System;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voLog : voBase
    {
        #region Propriedades e Atributos

        public int CodigoLog { get; set; }
        public voUsuario Usuario { get; set; }
        public DateTime DataHora { get; set; }
        public string Operacao { get; set; }

        #endregion
    }
}

#endregion