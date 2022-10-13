#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using SolineaICMS.Databases;
using SolineaICMS.Interfaces;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.DAL
{
    /// <summary>
    /// Classe base herdada pelas classes DAL.
    /// </summary>
    /// <typeparam name="T">VO de onde serão pegos os parâmetros de entrada e saída.</typeparam>
    public class dalBase<T> : IDalBase<T> where T : new()
    {
        #region Propriedades e Atributos

        /// <summary>
        /// Nome da procedure de "Select"
        /// </summary>
        public string ProcedureSelect { get; set; }

        /// <summary>
        /// Nome da procedure de "Insert"
        /// </summary>
        public string ProcedureInsert { get; set; }

        /// <summary>
        /// Nome da procedure de "Update"
        /// </summary>
        public string ProcedureUpdate { get; set; }

        /// <summary>
        /// Nome da procedure de "Delete"
        /// </summary>
        public string ProcedureDelete { get; set; }

        /// <summary>
        /// Classe de acesso a dados
        /// </summary>
        protected FactoryDatabase<T> Database { get; set; }

        #endregion

        #region Métodos

        /// <summary>
        /// Com o retorno da procedure, criar uma lista de VO do tipo passado da VO passada como parâmetro
        /// </summary>
        /// <param name="dr">Datareader com o retorno da procedure</param>
        /// <param name="objeto">VO utilizada de modelo para a criação da lista de VO</param>
        /// <returns>IList de VO do tipo da VO passada por parâmetro</returns>
        public IList<T> ManageSelect(IDataReader dr, T objeto)
        {
            //Lista de VO que irá ser retornada
            IList<T> listObjects = new List<T>();

            //Obtém o tipo da VO
            Type type = objeto.GetType();

            //Variável que irá receber o atributo da propriedade
            UtilAttributes.ManageSelectAttribute manageSelectAttribute = null;

            //Lista de Custom Attributes
            object[] listAttributes;

            //Variável booleana que irá ser populada de acordo com o atributo, para indicar se a propriedade irá ser manipulada ou não
            bool manageSelect;

            //Enquando o DataReader puder ser lido (houver registros)
            while (dr.Read())
            {
                //Cria um novo objeto do tipo da VO passada por parâmetro
                T obj = new T();

                //Para cada propriedade do objeto enviado como parâmetro
                foreach (PropertyInfo pInfo in type.GetProperties())
                {
                    //Obtém os atributos da propriedade
                    listAttributes = pInfo.GetCustomAttributes(true);

                    manageSelectAttribute = null;

                    //Para cada atributo da propriedade
                    foreach (Attribute attr in listAttributes)
                    {
                        //Se o nome do atributo dor "ManageSelectAttribute", popula a variável com o atributo
                        if (string.Equals((((Type)(attr.TypeId)).Name), "ManageSelectAttribute"))
                        {
                            manageSelectAttribute = (UtilAttributes.ManageSelectAttribute)attr;
                        }
                    }

                    //Se a propriedade contiver o atributo ManageSelect, recupera o valor do mesmo
                    if (manageSelectAttribute != null)
                    {
                        manageSelect = manageSelectAttribute.ManageSelect;
                    }
                    //Caso contrário, o sistema assume que a propriedade irá ser manipulada
                    else
                    {
                        manageSelect = true;
                    }

                    //Popula a propriedade com o valor retornado pela procedure
                    if (manageSelect)
                    {
                        if (dr[pInfo.Name] != DBNull.Value)
                        {
                            pInfo.SetValue(obj, dr[pInfo.Name], null);
                        }
                        else
                        {
                            pInfo.SetValue(obj, null, null);
                        }
                    }
                }

                //Adiciona o objeto à lista
                listObjects.Add(obj);
            }

            //Retorna a lista de objetos
            return listObjects;
        }

        /// <summary>
        /// Recupera os registros da base
        /// </summary>
        /// <param name="objeto">VO utilizada como filtro</param>
        /// <returns>IList de VO do tipo da VO passada por parâmetro</returns>
        public IList<T> Select(T objeto)
        {
            //Instancia um objeto de acesso ao banco de dados
            this.Database = new FactoryDatabase<T>(ProcedureSelect, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = Database.Manage.Connection())
            {

                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {

                    //Obtém a lista de parâmetros da procedure
                    List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Select);

                    //Adiciona cada parâmetro da lista ao Command
                    for (int j = 0; j < listParams.Count; j++)
                    {
                        cmd.Parameters.Add(listParams[j]);
                    }

                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    try
                    {
                        //Lista com o retorno do método ManageSelect
                        IList<T> listManageSelect = ManageSelect(cmd.ExecuteReader(), objeto);

                        //Retorna a lista
                        return listManageSelect;
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, ProcedureSelect);
                    }
                }
            }
        }

        /// <summary>
        /// Persiste o registro na base
        /// </summary>
        /// <param name="objeto">VO contendo os valores que serão persistidos</param>
        /// <returns>Inteiro</returns>
        public int Insert(T objeto)
        {
            //Instancia um objeto de acesso ao banco de dados
            Database = new FactoryDatabase<T>(ProcedureInsert, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = Database.Manage.Connection())
            {

                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {

                    //Obtém a lista de parâmetros da procedure
                    List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Insert);

                    //Adiciona cada parâmetro da lista ao Command
                    for (int j = 0; j < listParams.Count; j++)
                    {
                        cmd.Parameters.Add(listParams[j]);
                    }

                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    //Inicia uma transação com o banco de dados
                    using (IDbTransaction trans = Database.Manage.BeginTransaction(cn))
                    {
                        //Atribui a transação ao Command
                        cmd.Transaction = trans;

                        try
                        {
                            //Executa o comanndo
                            int result = cmd.ExecuteNonQuery();

                            //Commit na transação
                            Database.Manage.CommitTransaction(trans);

                            //Retorna o resultado
                            return result;
                        }
                        catch (Exception ex)
                        {
                            //Rollback na transação
                            Database.Manage.RollbackTransaction(trans);

                            throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, ProcedureInsert);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Persiste o registro na base com a conexão passada por parâmetro
        /// </summary>
        /// <param name="objeto">VO contendo os valores que serão persistidos</param>
        /// <param name="cn">Conexão aberta com o banco de dados</param>
        /// <param name="trans">Transação aberta no banco de dados</param>
        /// <returns>Inteiro</returns>
        public int Insert(T objeto, IDbConnection cn, IDbTransaction trans)
        {
            //Instancia um objeto de acesso ao banco de dados
            Database = new FactoryDatabase<T>(ProcedureInsert, CommandType.StoredProcedure);

            //Instancia um Command
            using (IDbCommand cmd = Database.Manage.Command(cn))
            {

                //Obtém a lista de parâmetros da procedure
                List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Insert);

                //Adiciona cada parâmetro da lista ao Command
                for (int j = 0; j < listParams.Count; j++)
                {
                    cmd.Parameters.Add(listParams[j]);
                }

                //Atribui a transação ao Command
                cmd.Transaction = trans;

                //Executa o comanndo
                int result = cmd.ExecuteNonQuery();

                //Retorna o resultado
                return result;
            }
        }

        /// <summary>
        /// Atualiza o registro na base
        /// </summary>
        /// <param name="objeto">VO contendo os valores que serão persistidos</param>
        /// <returns>Inteiro</returns>
        public int Update(T objeto)
        {
            //Instancia um objeto de acesso ao banco de dados
            Database = new FactoryDatabase<T>(ProcedureUpdate, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = Database.Manage.Connection())
            {

                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {

                    //Obtém a lista de parâmetros da procedure
                    List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Update);

                    //Adiciona cada parâmetro da lista ao Command
                    for (int j = 0; j < listParams.Count; j++)
                    {
                        cmd.Parameters.Add(listParams[j]);
                    }

                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    //Inicia uma transação com o banco de dados
                    using (IDbTransaction trans = Database.Manage.BeginTransaction(cn))
                    {
                        //Atribui a transação ao Command
                        cmd.Transaction = trans;

                        try
                        {
                            //Executa o comanndo
                            int result = cmd.ExecuteNonQuery();

                            //Commit na transação
                            Database.Manage.CommitTransaction(trans);

                            //Retorna o resultado
                            return result;
                        }
                        catch (Exception ex)
                        {
                            //Rollback na transação
                            Database.Manage.RollbackTransaction(trans);

                            throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, ProcedureUpdate);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Atualiza o registro na base com a conexão passada por parâmetro
        /// </summary>
        /// <param name="objeto">VO contendo os valores que serão persistidos</param>
        /// <param name="cn">Conexão aberta com o banco de dados</param>
        /// <param name="trans">Transação aberta no banco de dados</param>
        /// <returns>Inteiro</returns>
        public int Update(T objeto, IDbConnection cn, IDbTransaction trans)
        {
            //Instancia um objeto de acesso ao banco de dados
            Database = new FactoryDatabase<T>(ProcedureUpdate, CommandType.StoredProcedure);

            //Instancia um Command
            using (IDbCommand cmd = Database.Manage.Command(cn))
            {
                //Obtém a lista de parâmetros da procedure
                List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Update);

                //Adiciona cada parâmetro da lista ao Command
                for (int j = 0; j < listParams.Count; j++)
                {
                    cmd.Parameters.Add(listParams[j]);
                }

                //Atribui a transação ao Command
                cmd.Transaction = trans;

                //Executa o comanndo
                int result = cmd.ExecuteNonQuery();

                //Retorna o resultado
                return result;
            }
        }

        /// <summary>
        /// Deleta um registro da base
        /// </summary>
        /// <param name="objeto">VO contendo o código do registro que será deletado</param>
        /// <returns>Inteiro</returns>
        public int Delete(T objeto)
        {
            //Instancia um objeto de acesso ao banco de dados
            Database = new FactoryDatabase<T>(ProcedureDelete, CommandType.StoredProcedure);

            //Instancia uma nova conexão
            using (IDbConnection cn = Database.Manage.Connection())
            {

                //Instancia um Command
                using (IDbCommand cmd = Database.Manage.Command(cn))
                {

                    //Obtém a lista de parâmetros da procedure
                    List<IDbDataParameter> listParams = Database.Manage.GetParameters(objeto, UtilEnums.ProcedureType.Delete);

                    //Adiciona cada parâmetro da lista ao Command
                    for (int j = 0; j < listParams.Count; j++)
                    {
                        cmd.Parameters.Add(listParams[j]);
                    }

                    //Abre a conexão com o banco e inicia uma transação
                    Database.Manage.OpenConnection(cn);

                    //Inicia uma transação com o banco de dados
                    using (IDbTransaction trans = Database.Manage.BeginTransaction(cn))
                    {
                        //Atribui a transação ao Command
                        cmd.Transaction = trans;

                        try
                        {
                            //Executa o comanndo
                            int result = cmd.ExecuteNonQuery();

                            //Commit na transação
                            Database.Manage.CommitTransaction(trans);

                            //Retorna o resultado
                            return result;
                        }
                        catch (Exception ex)
                        {
                            //Rollback na transação
                            Database.Manage.RollbackTransaction(trans);

                            throw new CustomException(UtilConstants.MSG_ERRO_BANCO_DADOS, ex, string.Empty, ProcedureDelete);
                        }
                    }
                }
            }
        }

        #endregion
    }
}

#endregion