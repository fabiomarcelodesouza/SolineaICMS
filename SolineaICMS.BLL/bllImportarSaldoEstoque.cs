using System;
using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.Util;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    public class bllImportarSaldoEstoque : IBllBase<voRegistrosImportadosSaldoEstoque>
    {
        public void ProcessarSaldoEstoque(UtilEnums.FileType FileType, string filePath)
        {
            dalImportarSaldoEstoque dalImportarSaldoEstoque;

            dalImportarSaldoEstoque = new dalImportarSaldoEstoque(FileType, filePath);            
            dalImportarSaldoEstoque.ImportarSaldoEstoque();           
        }

        #region IBllBase<voImportarSaldoEstoque> Members

        public IList<voRegistrosImportadosSaldoEstoque> Select(voRegistrosImportadosSaldoEstoque objeto)
        {
            throw new NotImplementedException();
        }

        public int Insert(voRegistrosImportadosSaldoEstoque objeto)
        {
            throw new NotImplementedException();
        }

        public int Update(voRegistrosImportadosSaldoEstoque objeto)
        {
            throw new NotImplementedException();
        }

        public int Delete(voRegistrosImportadosSaldoEstoque objeto)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
