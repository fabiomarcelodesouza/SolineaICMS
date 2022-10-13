#region Usings

using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalNotaFiscalSaida : dalBase<voNotaFiscalSaida>
    {
        #region Construtores

        public dalNotaFiscalSaida()
        {
            base.ProcedureInsert = "SP_INSERT_Tb008_NotaFiscalSaida";
        }

        #endregion
    }
}

#endregion