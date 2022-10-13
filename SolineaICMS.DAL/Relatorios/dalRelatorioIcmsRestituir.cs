using System;
using SolineaICMS.VO.Relatorios;

namespace SolineaICMS.DAL.Relatorios
{
    public class dalRelatorioIcmsRestituir<T> : dalBase<T> where T : new()
    {
        public dalRelatorioIcmsRestituir()
        {
            T obj = new T();
            Type tipo = obj.GetType(); 
            
            voRelatorioIcmsRestituirPeps objPeps = new voRelatorioIcmsRestituirPeps();
            voRelatorioIcmsRestituirCustoMedio objCustoMedio = new voRelatorioIcmsRestituirCustoMedio();
            voRelatorioIcmsRestituirResumoNotas objResumoNotas = new voRelatorioIcmsRestituirResumoNotas();
            
            if (tipo == objPeps.GetType())
            {
                this.ProcedureSelect = "SP_DIVERSOS_RELATORIO_ICMS_RESTITUIR_PEPS";
            }
            else if (tipo == objCustoMedio.GetType())
            {
                this.ProcedureSelect = "SP_DIVERSOS_RELATORIO_ICMS_RESTITUIR_CUSTO_MEDIO";
            }
            else if (tipo == objResumoNotas.GetType())
            {
                this.ProcedureSelect = "SP_DIVERSOS_RELATORIO_ICMS_RESTITUIR_RESUMO_NOTAS";
            }
        }
    }
}
