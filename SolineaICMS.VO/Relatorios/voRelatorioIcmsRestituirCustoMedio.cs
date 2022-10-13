#region Usings

using System;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO.Relatorios
{
    public class voRelatorioIcmsRestituirCustoMedio : voBase
    {
        #region Propriedades e Atributos

        [UtilAttributes.ProcedureParameter(DbType.DateTime, true, false, false, false)]        
        public DateTime? DataInicioNotaEntrada { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.DateTime, true, false, false, false)]        
        public DateTime? DataFimNotaEntrada { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.DateTime, true, false, false, false)]        
        public DateTime? DataInicioNotaSaida { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.DateTime, true, false, false, false)]        
        public DateTime? DataFimNotaSaida { get; set; }

        public string CodigoProdutoCliente { get; set; }
        public Int64 Ncm { get; set; }
        public string NomeProduto { get; set; }
        public decimal Quantidade { get; set; }
        public int NumeroNota { get; set; }
        public string TipoNota { get; set; }
        public DateTime? DataHoraEmissao { get; set; }
        public string NomeCliente { get; set; }
        public string CnpjCpfCliente { get; set; }
        public string Uf { get; set; }
        public decimal ValorIcmsProprio { get; set; }
        public decimal ValorIcmsSt { get; set; }        
        public decimal Credito { get; set; }
        public decimal QuantidadeCustoMedio { get; set; }
        public decimal ValorIcmsProprioCustoMedio { get; set; }
        public decimal ValorIcmsStCustoMedio { get; set; }

        #endregion

        #region Construtores

        public voRelatorioIcmsRestituirCustoMedio() { }

        public voRelatorioIcmsRestituirCustoMedio(DateTime dataInicioNotaEntrada, DateTime dataFimNotaEntrada, DateTime dataInicioNotaSaida, DateTime dataFimNotaSaida)
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