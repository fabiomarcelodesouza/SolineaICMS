using System.Collections.Generic;
using SolineaICMS.DAL.Relatorios;
using SolineaICMS.VO.Relatorios;

namespace SolineaICMS.BLL.Relatorios
{
    public class bllRelatorioInconsistenciasEstoque
    {
        dalRelatorioInconsistenciasEstoque dalRelatorioInconsistenciasEstoque = new dalRelatorioInconsistenciasEstoque();

        public IList<voRelatorioInconsistenciasEstoque> Select(voRelatorioInconsistenciasEstoque voRelatorioInconsistenciasEstoque)
        {
            return dalRelatorioInconsistenciasEstoque.Select(voRelatorioInconsistenciasEstoque);
        }    
    }
}

