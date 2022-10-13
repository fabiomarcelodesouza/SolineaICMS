#region Usings

using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalPessoa : dalBase<voPessoa>
    {
        #region Construtores
        
        public dalPessoa()
        {
            base.ProcedureInsert = "SP_INSERT_Tb001_Pessoa";
            base.ProcedureUpdate = "SP_UPDATE_Tb001_Pessoa";
        }

        #endregion
    }
}

#endregion