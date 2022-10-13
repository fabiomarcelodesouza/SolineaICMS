#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using SolineaICMS.Interfaces;
using SolineaICMS.Util;

#endregion

#region Classe

namespace SolineaICMS.Databases
{
    /// <summary>
    /// Classe responsável pelos métodos de conexão e acesso a dados utilizando o banco de dados SQL Server
    /// </summary>
    /// <typeparam name="T">VO que será utilizada para recuperar as properties e transformá-las em parâmetros para as procedures</typeparam>
    public class SQLServer<T> : IDatabase<T>
    {
        #region Propriedades e Atributos

        /// <summary>
        /// Nome da procedure ou instrução SQL a ser executada contra a base de dados
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Tipo de comando que será executado (Procedure ou SQL Implícito)
        /// </summary>
        public CommandType CommandType { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor da classe SQLServer
        /// </summary>        
        public SQLServer()
        {
        }

        /// <summary>
        /// Construtor da classe SQLServer
        /// </summary>
        /// <param name="operation">Nome da procedure ou instrução SQL a ser executada contra a base de dados</param>
        /// <param name="commandType">Tipo de comando que será executado (Procedure ou SQL Implícito)</param>
        public SQLServer(string operation, CommandType commandType)
        {
            this.Operation = operation;
            this.CommandType = commandType;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Conexão com o bando de dados
        /// </summary>
        /// <returns>SqlConnection</returns>
        public IDbConnection Connection()
        {
            IDbConnection cn = new SqlConnection(ConfigurationManager.ConnectionString);
            return cn;
        }

        /// <summary>
        /// Abre a conexão com banco de dados
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>
        public void OpenConnection(IDbConnection cn)
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }

        /// <summary>
        /// Inicia uma transação
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>
        /// <returns>IDbTransaction</returns>
        public IDbTransaction BeginTransaction(IDbConnection cn)
        {
            IDbTransaction trans = cn.BeginTransaction();
            return trans;
        }

        /// <summary>
        /// Inicia uma transação
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>
        /// <param name="isolationLevel">Nível de isolamento da transação</param>
        /// <returns>IDbTransaction</returns>
        public IDbTransaction BeginTransaction(IDbConnection cn, IsolationLevel isolationLevel)
        {
            IDbTransaction trans = cn.BeginTransaction(isolationLevel);
            return trans;
        }

        /// <summary>
        /// Commit na transação
        /// </summary>
        /// <param name="trans">Transação do banco de dados</param>
        public void CommitTransaction(IDbTransaction trans)
        {
            trans.Commit();
        }

        /// <summary>
        /// Rollback na transação
        /// </summary>
        /// <param name="trans">Transação do banco de dados</param>
        public void RollbackTransaction(IDbTransaction trans)
        {
            trans.Rollback();
        }

        /// <summary>
        /// Fecha a conexão com banco de dados
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>      
        public void CloseConnection(IDbConnection cn)
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Command de execução
        /// </summary>
        /// <param name="cn">Conexão com o banco de dados</param>
        /// <returns>SqlCommand</returns>
        public IDbCommand Command(IDbConnection cn)
        {
            IDbCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = this.CommandType;
            cmd.CommandText = Operation;
            return cmd;
        }

        /// <summary>
        /// Lista de parametros da procedure obitdos partir do objeto enviado
        /// </summary>
        /// <param name="objeto">VO que será utilizada para recuperar as properties e transformá-las em parâmetros para as procedures</param>
        /// <param name="FieldType">Tipo do campo (PrimaryKey, ForeingKey, NonPrimaryKey ou All)</param>
        /// <returns>Lista de IDbDataParameter</returns>
        public List<IDbDataParameter> GetParameters(T objeto, UtilEnums.ProcedureType ProcedureType)
        {
            //Flag que irá definir se a propriedade será tratada como parâmetro ou não de acordo com o tipo da procedure e as flags dentro do Atributo
            bool trataParametro = false;

            //Lista de retorno do método
            List<IDbDataParameter> listParamaters = new List<IDbDataParameter>();

            //Parâmetro da procedure
            SqlParameter sqlParameter;

            //Obtém o tipo da VO
            Type type = objeto.GetType();

            //Variável que irá receber o atributo da propriedade
            UtilAttributes.ProcedureParameterAttribute procedureParameterAttribute;

            //Lista de Custom Attributes
            object[] listAttributes;            

            //Para cada propriedade do objeto enviado como parâmetro
            foreach (PropertyInfo pInfo in type.GetProperties())
            {
                //Obtém os atributos da propriedade
                listAttributes = pInfo.GetCustomAttributes(true);
                procedureParameterAttribute = null;
                trataParametro = false;

                //Para cada atributo da propriedade
                foreach (Attribute attr in listAttributes)
                {
                    //Se o nome do atributo dor "ProcedureParameterAttribute", popula a variável com o atributo
                    if (string.Equals((((Type)(attr.TypeId)).Name), "ProcedureParameterAttribute"))
                    {
                        procedureParameterAttribute = (UtilAttributes.ProcedureParameterAttribute)attr;
                    }
                }

                //Se a propriedade conter o atributo
                if (procedureParameterAttribute != null)
                {
                    //Verifica se o tipo de procedure é diferente de Other, pois se for Oher os parametro terão que ser criados manualmente
                    if (ProcedureType == UtilEnums.ProcedureType.Other)
                    {
                        trataParametro = true;
                    }
                    else
                    {
                        if (ProcedureType == UtilEnums.ProcedureType.Select)
                        {
                            if (procedureParameterAttribute.SelectParameter)
                            {
                                trataParametro = true;
                            }
                            else
                            {
                                trataParametro = false;
                            }
                        }
                        else if (ProcedureType == UtilEnums.ProcedureType.Insert)
                        {
                            if (procedureParameterAttribute.InsertParameter)
                            {
                                trataParametro = true;
                            }
                            else
                            {
                                trataParametro = false;
                            }
                        }
                        else if (ProcedureType == UtilEnums.ProcedureType.Update)
                        {
                            if (procedureParameterAttribute.UpdateParameter)
                            {
                                trataParametro = true;
                            }
                            else
                            {
                                trataParametro = false;
                            }
                        }
                        else if (ProcedureType == UtilEnums.ProcedureType.Delete)
                        {
                            if (procedureParameterAttribute.DeleteParameter)
                            {
                                trataParametro = true;
                            }
                            else
                            {
                                trataParametro = false;
                            }
                        }
                    }

                    if (trataParametro)
                    {
                        sqlParameter = new SqlParameter();

                        //Se foi declarado um nome para o parametro, cria um parametro com o nome declarado
                        if (!string.IsNullOrEmpty(procedureParameterAttribute.ParameterName))
                        {
                            sqlParameter.ParameterName = procedureParameterAttribute.ParameterName;
                        }
                        //Caso contrário, cria um parâmetro com o nome da propriedade
                        else
                        {
                            sqlParameter.ParameterName = pInfo.Name;
                        }

                        //Direção do parâmetro
                        if (procedureParameterAttribute.Direction != 0)
                        {
                            sqlParameter.Direction = procedureParameterAttribute.Direction;
                        }
                        else
                        {
                            sqlParameter.Direction = ParameterDirection.Input;
                        }

                        //Tipo de dado do parâmetro
                        sqlParameter.DbType = procedureParameterAttribute.DbType;

                        //Capacidade da variável numérica
                        if (procedureParameterAttribute.Precision != 0)
                        {
                            sqlParameter.Precision = procedureParameterAttribute.Precision;
                        }

                        //Casas decimais
                        if (procedureParameterAttribute.Scale != 0)
                        {
                            sqlParameter.Scale = procedureParameterAttribute.Scale;
                        }

                        //Capacidade da variável texto
                        if (procedureParameterAttribute.Size != 0)
                        {
                            sqlParameter.Size = procedureParameterAttribute.Size;
                        }

                        //Se a propriedade estiver populada, popula o parâmetro com o valor da propriedade
                        if (pInfo.GetValue(objeto, null) != null)
                        {
                            sqlParameter.Value = pInfo.GetValue(objeto, null);
                        }
                        //Caso contrário popula com o valor de DBNull
                        else
                        {
                            sqlParameter.Value = DBNull.Value;
                        }                       
                       
                        //Adiciona o parâmetro à lista
                        listParamaters.Add(sqlParameter);
                    }
                }
            }

            //Retorna a lista de parâmetros
            return listParamaters;
        }

        /// <summary>
        /// Instancia um novo parametro
        /// </summary>
        /// <returns>IDbDataParameter</returns>
        public IDbDataParameter NewParameter()
        {
            SqlParameter param = new SqlParameter();
            return param;
        }

        #endregion
    }
}

#endregion