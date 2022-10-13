using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    public class bllPessoa : IBllBase<voPessoa>
    {
        public IList<voPessoa> Select(voPessoa voPessoa)
        {
            dalPessoa dalPessoa = new dalPessoa();

            return dalPessoa.Select(voPessoa);
        }

        public int Insert(voPessoa voPessoa)
        {
            dalPessoa dalPessoa = new dalPessoa();

            return dalPessoa.Insert(voPessoa);
        }

        public int Update(voPessoa voPessoa)
        {
            dalPessoa dalPessoa = new dalPessoa();

            return dalPessoa.Update(voPessoa);
        }

        public int Delete(voPessoa voPessoa)
        {
            dalPessoa dalPessoa = new dalPessoa();

            return dalPessoa.Delete(voPessoa);
        }
    }
}

