#region Usings

using System;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voEstoque : voBase
    {
        #region Propriedades e Atributos

        public int CodigoEstoque { get; set; }
        public voNotaFiscalEntrada NotaFiscalEntrada { get; set; }
        public voProduto Produto { get; set; }
        public Int32 Ncm { get; set; }
        public decimal Quantidade { get; set; }
        public decimal QuantidadeSaida { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorIcmsProprio { get; set; }
        public decimal ValorIcmsSt { get; set; }

        #endregion
    }
}

#endregion