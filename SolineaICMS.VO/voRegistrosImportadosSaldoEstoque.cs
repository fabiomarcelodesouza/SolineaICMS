#region Usings

using System.Data;
using SolineaICMS.Util;
using System;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voRegistrosImportadosSaldoEstoque : voBase
    {
        #region Propriedades e Atributos

        public int CodigoRegistrosImportados_SaldoEstoque { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string CodigoProdutoCliente { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string NomeProduto { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int64, false, true, false, false)]
        public Int64 Ncm { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, true, false, false, Precision = 15, Scale = 4)]
        public decimal? Quantidade { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string UnidadeMedida { get; set; }

        #endregion
    }
}

#endregion