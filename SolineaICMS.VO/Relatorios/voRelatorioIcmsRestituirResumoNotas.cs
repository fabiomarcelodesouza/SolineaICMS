#region Usings

using System;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO.Relatorios
{
    public class voRelatorioIcmsRestituirResumoNotas : voBase
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

        public int NumeroNota { get; set; }
        public DateTime? DataHoraEmissao { get; set; }
        public string TipoNota { get; set; }
        public string Uf { get; set; }
        public string NomeCliente { get; set; }
        public string CnpjCpfCliente { get; set; }

        #endregion

        #region Construtores

        public voRelatorioIcmsRestituirResumoNotas() { }

        public voRelatorioIcmsRestituirResumoNotas(DateTime dataInicioNotaEntrada, DateTime dataFimNotaEntrada, DateTime dataInicioNotaSaida, DateTime dataFimNotaSaida)
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