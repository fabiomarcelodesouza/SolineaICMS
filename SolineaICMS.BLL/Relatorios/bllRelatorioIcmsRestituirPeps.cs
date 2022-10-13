using System.Collections.Generic;
using SolineaICMS.DAL.Relatorios;
using SolineaICMS.VO.Relatorios;

namespace SolineaICMS.BLL.Relatorios
{
    public class bllRelatorioIcmsRestituirPeps
    {
        public IList<voRelatorioIcmsRestituirPeps> Select(voRelatorioIcmsRestituirPeps objeto)
        {
            dalRelatorioIcmsRestituir<voRelatorioIcmsRestituirPeps> dalRelatorioIcmsRestituir = new dalRelatorioIcmsRestituir<voRelatorioIcmsRestituirPeps>();
            return dalRelatorioIcmsRestituir.Select(objeto);
        }        
    }
}

