#region Usings

using System;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voInconsistenciasEstoque : voBase
    {
        #region Propriedades e Atributos

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string CodigoProdutoCliente { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string NomeProduto { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int64, false, true, false, false)]
        public Int64? Ncm { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, true, false, false)]
        public decimal? Quantidade { get; set; }

        public decimal? QuantidadeSolinea { get; set; }
        public decimal? QuantidadeEmpresa { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string UnidadeMedida { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int32, false, true, false, false)]
        [UtilAttributes.ManageSelect(ManageSelect = false)]
        public int CodigoUsuario { get; set; }

        public string CheckboxSelecionado { get; set; }

        #endregion
    }
}

#endregion