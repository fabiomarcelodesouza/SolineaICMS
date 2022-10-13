using System.Collections.Generic;
using SolineaICMS.DAL.Relatorios;
using SolineaICMS.VO.Relatorios;

namespace SolineaICMS.BLL.Relatorios
{
    public class bllRelatorioIcmsRestituirResumoNotas
    {
        public IList<voRelatorioIcmsRestituirResumoNotas> Select(voRelatorioIcmsRestituirResumoNotas objeto)
        {
            dalRelatorioIcmsRestituir<voRelatorioIcmsRestituirResumoNotas> dalRelatorioIcmsRestituir = new dalRelatorioIcmsRestituir<voRelatorioIcmsRestituirResumoNotas>();
            return dalRelatorioIcmsRestituir.Select(objeto);
        }        
    }
}

