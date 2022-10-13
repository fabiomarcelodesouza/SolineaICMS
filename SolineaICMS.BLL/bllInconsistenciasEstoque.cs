using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    public class bllInconsistenciasEstoque : IBllBase<voInconsistenciasEstoque>
    {
        public IList<voInconsistenciasEstoque> Select(voInconsistenciasEstoque voInconsistenciasEstoque)
        {
            dalInconsistenciasEstoque dalInconsistenciasEstoque = new dalInconsistenciasEstoque();

            return dalInconsistenciasEstoque.Select(voInconsistenciasEstoque);
        }

        public int Insert(voInconsistenciasEstoque voInconsistenciasEstoque)
        {
            dalInconsistenciasEstoque dalInconsistenciasEstoque = new dalInconsistenciasEstoque();

            return dalInconsistenciasEstoque.Insert(voInconsistenciasEstoque);
        }

        public int Update(voInconsistenciasEstoque voInconsistenciasEstoque)
        {
            dalInconsistenciasEstoque dalInconsistenciasEstoque = new dalInconsistenciasEstoque();

            return dalInconsistenciasEstoque.Update(voInconsistenciasEstoque);
        }

        public int Delete(voInconsistenciasEstoque voInconsistenciasEstoque)
        {
            dalInconsistenciasEstoque dalInconsistenciasEstoque = new dalInconsistenciasEstoque();

            return dalInconsistenciasEstoque.Delete(voInconsistenciasEstoque);
        }

        public void CorrigirInconsistencias(List<voInconsistenciasEstoque> listaInconsistencias)
        {
            dalInconsistenciasEstoque dalInconsistenciasEstoque = new dalInconsistenciasEstoque();

            dalInconsistenciasEstoque.CorrigirInconsistencias(listaInconsistencias);
        }
    }
}

