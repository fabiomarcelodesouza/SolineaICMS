#region Usings

using System.Collections.Generic;
using System.Data;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.Interfaces
{
    /// <summary>
    /// Interface que define os métodos necessários para conexão como banco de dados
    /// </summary>
    public interface IDatabase<T>
    {
        #region Methods

        /// <summary>
        /// Conexão com o bando de dados
        /// </summary>
        /// <returns>IDbConnection</returns>
        IDbConnection Connection();

        /// <summary>
        /// Abre a conexão com banco de dados
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>        
        void OpenConnection(IDbConnection cn);

        /// <summary>
        /// Inicia uma transação
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>
        /// <returns>IDbTransaction</returns>
        IDbTransaction BeginTransaction(IDbConnection cn);

        /// <summary>
        /// Inicia uma transação
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>
        /// <param name="isolationLevel">Nível de isolamento da transação</param>
        /// <returns>IDbTransaction</returns>
        IDbTransaction BeginTransaction(IDbConnection cn, IsolationLevel isolationLevel);

        /// <summary>
        /// Commit na transação
        /// </summary>
        /// <param name="trans">Transação do banco de dados</param>
        void CommitTransaction(IDbTransaction trans);

        /// <summary>
        /// Rollback na transação
        /// </summary>
        /// <param name="trans">Transação do banco de dados</param>
        void RollbackTransaction(IDbTransaction trans);

        /// <summary>
        /// Fecha a conexão com banco de dados
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>        
        void CloseConnection(IDbConnection cn);

        /// <summary>
        /// Command de execução
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>
        /// <returns>IDbCommand</returns>
        IDbCommand Command(IDbConnection cn);

        /// <summary>
        /// Lista de parametros da procedure obitdos partir do objeto enviado
        /// </summary>
        /// <param name="objeto">VO que será utilizada para recuperar as properties e transformá-las em parâmetros para as procedures</param>
        /// <param name="FieldType">Tipo do campo (PrimaryKey, ForeingKey, NonPrimaryKey ou All)</param>
        /// <returns>Lista de IDbDataParameter</returns>
        List<IDbDataParameter> GetParameters(T objeto, UtilEnums.ProcedureType ProcedureType);

        /// <summary>
        /// Instancia um novo parametro
        /// </summary>
        /// <returns>IDbDataParameter</returns>
        IDbDataParameter NewParameter();

        #endregion
    }
}

#endregion