#region Usings

using System;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voRegistrosImportadosMovimentoEstoque : voBase
    {
        #region Propriedades e Atributos

        [UtilAttributes.ProcedureParameter(DbType.Int32, false, true, false, true)]
        public int? CodigoRegistrosImportados_MovimentoEstoque { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int32, false, true, false, false)]
        public int? NumeroNota { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.DateTime, false, true, false, false)]
        public DateTime? DataHoraEmissao { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string TipoNota { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int32, false, true, false, false)]
        public int? Cfop { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string NomeEmitenteDestinatario { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string CnpjCpfEmitenteDestinatario { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string InscricaoEstadualEmitenteDestinatario { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string UfEmitenteDestinatario { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int64, false, true, false, false)]
        public Int64? Ncm { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string CodigoProdutoCliente { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string NomeProduto { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, true, false, false, Precision = 15, Scale = 4)]
        public decimal? Quantidade { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.String, false, true, false, false)]
        public string UnidadeMedida { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, true, false, false, Precision = 15, Scale = 2)]
        public decimal? Valor { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, true, false, false, Precision = 15, Scale = 2)]
        public decimal? IcmsProprio { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Decimal, false, true, false, false, Precision = 15, Scale = 2)]
        public decimal? IcmsSt { get; set; }

        [UtilAttributes.ManageSelect(ManageSelect = false)]
        public voUsuario Usuario { get; set; }

        #endregion
    }
}

#endregion