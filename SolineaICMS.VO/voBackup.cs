#region Usings

using System;

#endregion

#region Classe

namespace SolineaICMS.VO
{
    public class voBackup : voBase
    {
        #region Propriedades e Atributos

        public string NomeBancoDados { get; set; }

        #endregion

        #region Construtores

        public voBackup()
        {
        }

        public voBackup(string nomeBancoDados)
        {
            this.NomeBancoDados = nomeBancoDados;
        }

        #endregion
    }
}

#endregion