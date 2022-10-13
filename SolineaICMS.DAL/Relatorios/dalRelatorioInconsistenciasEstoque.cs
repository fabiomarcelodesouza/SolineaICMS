using SolineaICMS.VO.Relatorios;

namespace SolineaICMS.DAL.Relatorios
{
    public class dalRelatorioInconsistenciasEstoque : dalBase<voRelatorioInconsistenciasEstoque>
    {
        public dalRelatorioInconsistenciasEstoque()
        {
            base.ProcedureSelect = "SP_DIVERSOS_RELATORIO_INCONSISTENCIAS_ESTOQUE";
        }
    }
}
