#region Usings

using System;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voVinculaEntradasSaidas
    {
        #region Propriedades e Atributos

        [UtilAttributes.ProcedureParameter(DbType.String, false, false, false, false)]
        public string CodigoProdutoCliente { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int32, false, false, false, false)]
        public int? NumeroNotaFiscalSaida { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int64, false, false, false, false)]
        public string CnpjCpfEmitenteDestinatario { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.DateTime, false, false, false, false)]
        public DateTime? DataHoraEmissao { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, false, false, false, Precision = 15, Scale = 4)]
        public decimal? QuantidadeBaixa { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, false, false, false, Precision = 15, Scale = 4)]
        public decimal? QuantidadeNotaSaida { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, false, false, false, Precision = 15, Scale = 2)]
        public decimal? Valor { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, false, false, false, Precision = 15, Scale = 2)]
        public decimal? ValorIcmsProprio { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, false, false, false, Precision = 15, Scale = 2)]
        public decimal? ValorIcmsSt { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, false, false, false, Precision = 15, Scale = 4, Direction = ParameterDirection.Output)]
        public decimal? QuantidadeRestante { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, false, false, false, Size = 1024, Direction = ParameterDirection.Output)]
        public string SaiMsg { get; set; }

        #endregion

        #region Construtores

        public voVinculaEntradasSaidas()
        {
        }

        public voVinculaEntradasSaidas(voRegistrosImportadosMovimentoEstoque voRegistrosImportadosMovimentoEstoque, decimal? quantidadeNotaSaida)
        {
            this.CodigoProdutoCliente = voRegistrosImportadosMovimentoEstoque.CodigoProdutoCliente;
            this.NumeroNotaFiscalSaida = voRegistrosImportadosMovimentoEstoque.NumeroNota;
            this.CnpjCpfEmitenteDestinatario = voRegistrosImportadosMovimentoEstoque.CnpjCpfEmitenteDestinatario;
            this.DataHoraEmissao = voRegistrosImportadosMovimentoEstoque.DataHoraEmissao;
            this.QuantidadeBaixa = voRegistrosImportadosMovimentoEstoque.Quantidade;
            this.QuantidadeNotaSaida = quantidadeNotaSaida;
            this.Valor = voRegistrosImportadosMovimentoEstoque.Valor;
            this.ValorIcmsProprio = voRegistrosImportadosMovimentoEstoque.IcmsProprio;
            this.ValorIcmsSt = voRegistrosImportadosMovimentoEstoque.IcmsSt;
            this.SaiMsg = string.Empty;
        }

        #endregion
    }
}

#endregion