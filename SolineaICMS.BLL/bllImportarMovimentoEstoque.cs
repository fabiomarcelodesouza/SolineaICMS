using System;
using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.Util;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    /// <summary>
    /// Classe de negocio utilizada para importar os movimentos de estoque
    /// </summary>
    public class bllImportarMovimentoEstoque : IBllBase<voRegistrosImportadosMovimentoEstoque>
    {
        private dalImportarMovimentoEstoque DalImportarMovimentoEstoque { get; set; }

        public bllImportarMovimentoEstoque()
        {
            this.DalImportarMovimentoEstoque = new dalImportarMovimentoEstoque();
        }

        /// <summary>
        /// Aplica as regras de negócio e importa os movimentos de estoque
        /// </summary>
        /// <param name="fileType">Tipo de arquivo (xls, xlsx ou xml)</param>
        /// <param name="filePath">Caminho do arquivo</param>
        /// <param name="Usuario">Usuário logado no sistema</param>
        public bllImportarMovimentoEstoque(UtilEnums.FileType fileType, string filePath, voUsuario Usuario)
        {
            this.DalImportarMovimentoEstoque = new dalImportarMovimentoEstoque(fileType, filePath, Usuario);
        }

        public void ImportarMovimentoEstoque()
        {
            DalImportarMovimentoEstoque.ImportarMovimentoEstoque();
        }

        public string SelectPeriodoCoincidente()
        {
            return DalImportarMovimentoEstoque.SelectPeriodoCoincidente();
        }

        public int DeletePeriodoCoincidente(string dataInicial)
        {
            return DalImportarMovimentoEstoque.DeletePeriodoCoincidente(dataInicial);
        }

        public void ProcessarMovimentoEstoque(voUsuario voUsuario)
        {
            DalImportarMovimentoEstoque.ProcessarMovimentoEstoque(voUsuario);
        }

        public int DeleteGeral()
        {
            return DalImportarMovimentoEstoque.DeleteGeral();
        }

        #region IBllBase<voImportarMovimentoEstoque> Members

        public IList<voRegistrosImportadosMovimentoEstoque> Select(voRegistrosImportadosMovimentoEstoque objeto)
        {
            throw new NotImplementedException();
        }

        public int Insert(voRegistrosImportadosMovimentoEstoque objeto)
        {
            throw new NotImplementedException();
        }

        public int Update(voRegistrosImportadosMovimentoEstoque objeto)
        {
            throw new NotImplementedException();
        }

        public int Delete(voRegistrosImportadosMovimentoEstoque objeto)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
