using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    public class bllEstado : IBllBase<voEstado>
    {
        public IList<voEstado> Select(voEstado voEstado)
        {
            dalEstado dalEstado = new dalEstado();

            return dalEstado.Select(voEstado);
        }

        public int Insert(voEstado voEstado)
        {
            dalEstado dalEstado = new dalEstado();

            return dalEstado.Insert(voEstado);
        }

        public int Update(voEstado voEstado)
        {
            dalEstado dalEstado = new dalEstado();

            return dalEstado.Update(voEstado);
        }

        public int Delete(voEstado voEstado)
        {
            dalEstado dalEstado = new dalEstado();

            return dalEstado.Delete(voEstado);
        }
    }
}

