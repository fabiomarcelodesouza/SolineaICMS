#region Usings

using System;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voPessoa : voBase
    {
        #region Propriedades e Atributos

        public Int32 CodigoPessoa { get; set; }
        public string Nome { get; set; }
        public string CnpjCpf { get; set; }

        #endregion
    }
}

#endregion