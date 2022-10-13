using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    public class bllProduto : IBllBase<voProduto>
    {
        public IList<voProduto> Select(voProduto voProduto)
        {
            dalProduto dalProduto = new dalProduto();

            return dalProduto.Select(voProduto);
        }

        public int Insert(voProduto voProduto)
        {
            dalProduto dalProduto = new dalProduto();

            return dalProduto.Insert(voProduto);
        }

        public int Update(voProduto voProduto)
        {
            dalProduto dalProduto = new dalProduto();

            return dalProduto.Update(voProduto);
        }

        public int Delete(voProduto voProduto)
        {
            dalProduto dalProduto = new dalProduto();

            return dalProduto.Delete(voProduto);
        }
    }
}

