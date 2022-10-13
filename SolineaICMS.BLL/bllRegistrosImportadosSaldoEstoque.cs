#region Usings

using System.Collections.Generic;
using SolineaICMS.DAL;
using SolineaICMS.Interfaces;
using SolineaICMS.VO;

#endregion

#region Class

namespace SolineaICMS.BLL
{    
    public class bllRegistrosImportadosSaldoEstoque : IBllBase<voRegistrosImportadosSaldoEstoque>
    {
        public IList<voRegistrosImportadosSaldoEstoque> Select(voRegistrosImportadosSaldoEstoque voRegistrosImportadosSaldoEstoque)
        {
            dalRegistrosImportadosSaldoEstoque dalRegistrosImportadosSaldoEstoque = new dalRegistrosImportadosSaldoEstoque();

            return dalRegistrosImportadosSaldoEstoque.Select(voRegistrosImportadosSaldoEstoque);
        }

        public int Insert(voRegistrosImportadosSaldoEstoque voRegistrosImportadosSaldoEstoque)
        {
            dalRegistrosImportadosSaldoEstoque dalRegistrosImportadosSaldoEstoque = new dalRegistrosImportadosSaldoEstoque();

            return dalRegistrosImportadosSaldoEstoque.Insert(voRegistrosImportadosSaldoEstoque);
        }

        public int Update(voRegistrosImportadosSaldoEstoque voRegistrosImportadosSaldoEstoque)
        {
            dalRegistrosImportadosSaldoEstoque dalRegistrosImportadosSaldoEstoque = new dalRegistrosImportadosSaldoEstoque();

            return dalRegistrosImportadosSaldoEstoque.Update(voRegistrosImportadosSaldoEstoque);
        }

        public int Delete(voRegistrosImportadosSaldoEstoque voRegistrosImportadosSaldoEstoque)
        {
            dalRegistrosImportadosSaldoEstoque dalRegistrosImportadosSaldoEstoque = new dalRegistrosImportadosSaldoEstoque();

            return dalRegistrosImportadosSaldoEstoque.Delete(voRegistrosImportadosSaldoEstoque);
        }
    }
}

#endregion