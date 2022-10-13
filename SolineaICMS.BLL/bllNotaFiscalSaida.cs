using System.Collections.Generic;
using SolineaICMS.Interfaces;
using SolineaICMS.DAL;
using SolineaICMS.VO;

namespace SolineaICMS.BLL
{
    public class bllNotaFiscalSaida : IBllBase<voNotaFiscalSaida>
    {
        public IList<voNotaFiscalSaida> Select(voNotaFiscalSaida voNotaFiscalSaida)
        {
            dalNotaFiscalSaida dalNotaFiscalSaida = new dalNotaFiscalSaida();

            return dalNotaFiscalSaida.Select(voNotaFiscalSaida);
        }

        public int Insert(voNotaFiscalSaida voNotaFiscalSaida)
        {
            dalNotaFiscalSaida dalNotaFiscalSaida = new dalNotaFiscalSaida();

            return dalNotaFiscalSaida.Insert(voNotaFiscalSaida);
        }

        public int Update(voNotaFiscalSaida voNotaFiscalSaida)
        {
            dalNotaFiscalSaida dalNotaFiscalSaida = new dalNotaFiscalSaida();

            return dalNotaFiscalSaida.Update(voNotaFiscalSaida);
        }

        public int Delete(voNotaFiscalSaida voNotaFiscalSaida)
        {
            dalNotaFiscalSaida dalNotaFiscalSaida = new dalNotaFiscalSaida();

            return dalNotaFiscalSaida.Delete(voNotaFiscalSaida);
        }
    }
}

