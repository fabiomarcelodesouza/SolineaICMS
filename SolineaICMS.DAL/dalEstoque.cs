#region Usings

using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalEstoque : dalBase<voEstoque>
    {
        #region Construtores

        public dalEstoque()
        {
            base.ProcedureInsert = "SP_INSERT_Tb007_Estoque";
        }

        #endregion
    }
}

#endregion