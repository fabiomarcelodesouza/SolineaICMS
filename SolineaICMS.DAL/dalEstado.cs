#region Usings

using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalEstado : dalBase<voEstado>
    {
        #region Construtores

        public dalEstado()
        {
            base.ProcedureSelect = "SP_SELECT_Tb004_Estado";
            base.ProcedureInsert = "SP_INSERT_Tb004_Estado";
            base.ProcedureUpdate = "SP_UPDATE_Tb004_Estado";
            base.ProcedureDelete = "SP_DELETE_Tb004_Estado";
        }

        #endregion
    }
}

#endregion