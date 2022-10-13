using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;
using SolineaICMS.Util;

namespace SolineaICMS.BLL
{
    public class bllBackup : IBllBase<voBackup>
    {
        public void EfetuarBackup(voBackup voBackup)
        {
            new dalBackup().EfetuarBackup(voBackup);
        }

        public IList<voBackup> Select(voBackup objeto)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(voBackup objeto)
        {
            throw new System.NotImplementedException();
        }

        public int Update(voBackup objeto)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(voBackup objeto)
        {
            throw new System.NotImplementedException();
        }
    }
}

