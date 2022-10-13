#region Usings

using System.Data;
using SolineaICMS.Databases;
using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalProduto : dalBase<voProduto>
    {
        #region Construtores

        public dalProduto()
        {
            base.ProcedureSelect = "SP_SELECT_Tb005_Produto";
            base.ProcedureInsert = "SP_INSERT_Tb005_Produto";
        }

        #endregion      
    }
}

#endregion