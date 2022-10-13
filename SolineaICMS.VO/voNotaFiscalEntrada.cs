#region Usings

using System;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voNotaFiscalEntrada : voBase
    {
        #region Propriedades e Atributos

        public int CodigoNotaFiscalEntrada { get; set; }
        public voPessoa Pessoa { get; set; }
        public voUsuario Usuario { get; set; }
        public voEstado Estado { get; set; }
        public int Numero { get; set; }
        public DateTime DataHoraEmissao { get; set; }
        public int Cfop { get; set; }

        [UtilAttributes.ProcedureParameter(DbType.Int32, false, true, false, false)]
        public int? CodigoUsuario
        {
            get
            {
                return this.Usuario.CodigoUsuario;
            }
        }

        #endregion

        #region Construtores

        public voNotaFiscalEntrada()
        {
        }

        public voNotaFiscalEntrada(voUsuario usuario)
        {
            this.Usuario = usuario;
        }

        #endregion
    }
}

#endregion