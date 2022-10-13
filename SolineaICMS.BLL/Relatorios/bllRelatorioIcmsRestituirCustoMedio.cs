using System.Collections.Generic;
using SolineaICMS.DAL.Relatorios;
using SolineaICMS.VO.Relatorios;

namespace SolineaICMS.BLL.Relatorios
{
    public class bllRelatorioIcmsRestituirCustoMedio
    {
        public IList<voRelatorioIcmsRestituirCustoMedio> Select(voRelatorioIcmsRestituirCustoMedio objeto)
        {
            dalRelatorioIcmsRestituir<voRelatorioIcmsRestituirCustoMedio> dalRelatorioIcmsRestituir = new dalRelatorioIcmsRestituir<voRelatorioIcmsRestituirCustoMedio>();
            return dalRelatorioIcmsRestituir.Select(objeto);
        }
    }
}

