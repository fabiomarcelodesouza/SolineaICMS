using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    public class bllNotaFiscalEntrada : IBllBase<voNotaFiscalEntrada>
    {
        public IList<voNotaFiscalEntrada> Select(voNotaFiscalEntrada voNotaFiscalEntrada)
        {
            dalNotaFiscalEntrada dalNotaFiscalEntrada = new dalNotaFiscalEntrada();

            return dalNotaFiscalEntrada.Select(voNotaFiscalEntrada);
        }

        public int Insert(voNotaFiscalEntrada voNotaFiscalEntrada)
        {
            dalNotaFiscalEntrada dalNotaFiscalEntrada = new dalNotaFiscalEntrada();

            return dalNotaFiscalEntrada.Insert(voNotaFiscalEntrada);
        }

        public int Update(voNotaFiscalEntrada voNotaFiscalEntrada)
        {
            dalNotaFiscalEntrada dalNotaFiscalEntrada = new dalNotaFiscalEntrada();

            return dalNotaFiscalEntrada.Update(voNotaFiscalEntrada);
        }

        public int Delete(voNotaFiscalEntrada voNotaFiscalEntrada)
        {
            dalNotaFiscalEntrada dalNotaFiscalEntrada = new dalNotaFiscalEntrada();

            return dalNotaFiscalEntrada.Delete(voNotaFiscalEntrada);
        }
    }
}

