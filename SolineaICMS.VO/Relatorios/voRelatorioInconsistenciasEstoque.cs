#region Usings

using System;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO.Relatorios
{
    public class voRelatorioInconsistenciasEstoque : voBase
    {
        #region Propriedades e Atributos

        [UtilAttributes.ProcedureParameter(DbType.DateTime, true, false, false, false)]
        [UtilAttributes.ManageSelect(ManageSelect = false)]
        public DateTime? DataInicioNotaEntrada { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.DateTime, true, false, false, false)]
        [UtilAttributes.ManageSelect(ManageSelect = false)]
        public DateTime? DataFimNotaEntrada { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.DateTime, true, false, false, false)]
        [UtilAttributes.ManageSelect(ManageSelect = false)]
        public DateTime? DataInicioNotaSaida { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.DateTime, true, false, false, false)]
        [UtilAttributes.ManageSelect(ManageSelect = false)]
        public DateTime? DataFimNotaSaida { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, false, false, false)]
        public string CodigoProdutoCliente { get; set; }

        public Int64 Ncm { get; set; }
        public string NomeProduto { get; set; }
        public decimal Quantidade { get; set; }
        public int NotaSaida { get; set; }
        public DateTime? DataHoraEmissaoNotaSaida { get; set; }
        public string NomeDestinatario { get; set; }
        public string CnpjCpfDestinatario { get; set; }
        public string UfDestino { get; set; }
        public decimal IcmsProprioSaida { get; set; }
        public int NotaEntrada { get; set; }
        public DateTime? DataHoraEmissaoNotaEntrada { get; set; }
        public string NomeFornecedor { get; set; }
        public string CnpjCpfFornecedor { get; set; }
        public string UfOrigem { get; set; }
        public decimal IcmsProprioEntrada { get; set; }
        public decimal IcmsStEntrada { get; set; }
        public decimal Credito { get; set; }

        #endregion

        #region Construtores

        public voRelatorioInconsistenciasEstoque() { }

        public voRelatorioInconsistenciasEstoque(DateTime dataInicioNotaEntrada, DateTime dataFimNotaEntrada, DateTime dataInicioNotaSaida, DateTime dataFimNotaSaida)
        {
            this.DataInicioNotaEntrada = dataInicioNotaEntrada;
            this.DataFimNotaEntrada = dataFimNotaEntrada;
            this.DataInicioNotaSaida = dataInicioNotaSaida;
            this.DataFimNotaSaida = dataFimNotaSaida;
        }

        #endregion
    }
}

#endregion