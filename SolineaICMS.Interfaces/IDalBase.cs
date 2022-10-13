#region Usings

using System.Collections.Generic;
using System.Data;

#endregion

#region Classe

namespace SolineaICMS.Interfaces
{
    /// <summary>
    /// Interface que define os métodos executados contra o banco de dados
    /// </summary>
    public interface IDalBase<T>
    {
        #region Properties

        /// <summary>
        /// Nome da procedure de "Select"
        /// </summary>
        string ProcedureSelect { get; set; }

        /// <summary>
        /// Nome da procedure de "Insert"
        /// </summary>
        string ProcedureInsert { get; set; }

        /// <summary>
        /// Nome da procedure de "Update"
        /// </summary>
        string ProcedureUpdate { get; set; }

        /// <summary>
        /// Nome da procedure de "Delete"
        /// </summary>
        string ProcedureDelete { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Com o retorno da procedure, criar uma lista de VO do tipo passado da VO passada como parâmetro
        /// </summary>
        /// <param name="dr">Datareader com o retorno da procedure</param>
        /// <param name="objeto">VO utilizada de modelo para a criação da lista de VO</param>
        /// <returns>IList de VO do tipo da VO passada por parâmetro</returns>
        IList<T> ManageSelect(IDataReader dr, T objeto);

        /// <summary>
        /// Recupera os registros da base
        /// </summary>
        /// <param name="objeto">VO utilizada como filtro</param>
        /// <returns>IList de VO do tipo da VO passada por parâmetro</returns>
        IList<T> Select(T objeto);       

        /// <summary>
        /// Persiste o registro na base
        /// </summary>
        /// <param name="objeto">VO contendo os valores que serão persistidos</param>
        /// <returns>Inteiro</returns>
        int Insert(T objeto);

        /// <summary>
        /// Persiste o registro na base com a conexão passada por parâmetro
        /// </summary>
        /// <param name="objeto">VO contendo os valores que serão persistidos</param>
        /// <param name="cn">Conexão aberta com o banco de dados</param>
        /// <param name="trans">Transação aberta no banco de dados</param>
        /// <returns>Inteiro</returns>
        int Insert(T objeto, IDbConnection cn, IDbTransaction trans);

        /// <summary>
        /// Atualiza o registro na base
        /// </summary>
        /// <param name="objeto">VO contendo os valores que serão persistidos</param>
        /// <returns>Inteiro</returns>
        int Update(T objeto);

        /// <summary>
        /// Deleta um registro da base
        /// </summary>
        /// <param name="objeto">VO contendo o código do registro que será deletado</param>
        /// <returns>Inteiro</returns>
        int Delete(T objeto);

        #endregion
    }
}

#endregion