#region Classe

namespace SolineaICMS.VO
{
    public class voConfiguracao : voBase
    {
        #region Propriedades e Atributos

        public int CodigoConfiguracao { get; set; }
        public voEstado Estado { get; set; }
        public string NomeEmpresa { get; set; }
        public string CnpjEmpresa { get; set; }

        #endregion
    }
}

#endregion