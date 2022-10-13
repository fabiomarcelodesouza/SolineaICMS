#region Usings

using SolineaICMS.VO;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    public class dalNotaFiscalEntrada : dalBase<voNotaFiscalEntrada>
    {
        #region Construtores

        public dalNotaFiscalEntrada()
        {
            base.ProcedureInsert = "SP_INSERT_Tb006_NotaFiscalEntrada";
        }

        #endregion
    }
}

#endregion