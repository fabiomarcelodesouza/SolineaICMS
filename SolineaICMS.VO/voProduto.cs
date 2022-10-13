#region Usings

using System;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voProduto : voBase
    {
        #region Propriedades e Atributos

        [UtilAttributes.ProcedureParameter(DbType.Int32, true, false, true, true)]
        public int? CodigoProduto { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, false, true, false)]
        public string CodigoProdutoCliente { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, false, true, false)]
        public string Nome { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, true, false, false, false)]
        public string UnidadeMedida { get; set; }

        #endregion
    }
}

#endregion