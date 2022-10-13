using System.Collections.Generic;
using System.Data;

namespace SolineaICMS.Interfaces
{
    /// <summary>
    /// Interface que define os métodos executados contra o banco de dados
    /// </summary>
    public interface IBllBase<T> 
    {
        IList<T> Select(T objeto);
        int Insert(T objeto);
        int Update(T objeto);
        int Delete(T objeto);
    }
}
