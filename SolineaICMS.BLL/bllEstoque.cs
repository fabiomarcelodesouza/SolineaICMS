using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    public class bllEstoque : IBllBase<voEstoque>
    {
        public IList<voEstoque> Select(voEstoque voEstoque)
        {
            dalEstoque dalEstoque = new dalEstoque();

            return dalEstoque.Select(voEstoque);
        }

        public int Insert(voEstoque voEstoque)
        {
            dalEstoque dalEstoque = new dalEstoque();

            return dalEstoque.Insert(voEstoque);
        }

        public int Update(voEstoque voEstoque)
        {
            dalEstoque dalEstoque = new dalEstoque();

            return dalEstoque.Update(voEstoque);
        }

        public int Delete(voEstoque voEstoque)
        {
            dalEstoque dalEstoque = new dalEstoque();

            return dalEstoque.Delete(voEstoque);
        }
    }
}

