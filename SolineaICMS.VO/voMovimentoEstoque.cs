#region Classe

namespace SolineaICMS.VO
{
    public class voMovimentoEstoque : voBase
    {
        #region Propriedades e Atributos

        public int CodigoMovimentoEstoque { get; set; }
        public voEstoque Estoque { get; set; }
        public voNotaFiscalSaida NotaFiscalSaida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorIcmsProprio { get; set; }
        public decimal ValorIcmsSt { get; set; }

        #endregion
    }
}

#endregion