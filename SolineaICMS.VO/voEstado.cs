#region Usings

using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voEstado : voBase
    {
        #region Propriedades e Atributos

        [UtilAttributes.ProcedureParameter(DbType.Int32, true, false, true, true)]
        public int? CodigoEstado { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, true, true, false)]
        public string Nome { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, true, true, false)]
        public string Uf { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, true, true, true, false, Precision = 15, Scale = 4)]
        public decimal? AliquotaICMS { get; set; }

        #endregion
    }
}

#endregion