#region Usings

using System.Collections.Generic;
using SolineaICMS.DAL;
using SolineaICMS.Interfaces;
using SolineaICMS.VO;

#endregion

#region Class

namespace SolineaICMS.BLL
{
    public class bllRegistrosImportadosMovimentoEstoque : IBllBase<voRegistrosImportadosMovimentoEstoque>
    {
        public IList<voRegistrosImportadosMovimentoEstoque> Select(voRegistrosImportadosMovimentoEstoque voRegistrosImportadosMovimentoEstoque)
        {
            dalRegistrosImportadosMovimentoEstoque dalRegistrosImportadosMovimentoEstoque = new dalRegistrosImportadosMovimentoEstoque();

            return dalRegistrosImportadosMovimentoEstoque.Select(voRegistrosImportadosMovimentoEstoque);
        }

        public int Insert(voRegistrosImportadosMovimentoEstoque voRegistrosImportadosMovimentoEstoque)
        {
            dalRegistrosImportadosMovimentoEstoque dalRegistrosImportadosMovimentoEstoque = new dalRegistrosImportadosMovimentoEstoque();

            return dalRegistrosImportadosMovimentoEstoque.Insert(voRegistrosImportadosMovimentoEstoque);
        }

        public int Update(voRegistrosImportadosMovimentoEstoque voRegistrosImportadosMovimentoEstoque)
        {
            dalRegistrosImportadosMovimentoEstoque dalRegistrosImportadosMovimentoEstoque = new dalRegistrosImportadosMovimentoEstoque();

            return dalRegistrosImportadosMovimentoEstoque.Update(voRegistrosImportadosMovimentoEstoque);
        }

        public int Delete(voRegistrosImportadosMovimentoEstoque voRegistrosImportadosMovimentoEstoque)
        {
            dalRegistrosImportadosMovimentoEstoque dalRegistrosImportadosMovimentoEstoque = new dalRegistrosImportadosMovimentoEstoque();

            return dalRegistrosImportadosMovimentoEstoque.Delete(voRegistrosImportadosMovimentoEstoque);
        }
    }
}

#endregion