#region Usings

using System;
using System.Data;

#endregion

#region Classe

namespace SolineaICMS.Util
{
    /// <summary>
    /// Atributos customizados
    /// </summary>
    public class UtilAttributes
    {
        /// <summary>
        /// Atributo utilizado para controlar a geração de parametros de procedures e functions a partir das propriedades da classe
        /// </summary>
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
        public class ProcedureParameterAttribute : System.Attribute
        {            
            public DbType DbType { get; set; }
            public bool SelectParameter { get; set; }
            public bool InsertParameter { get; set; }
            public bool UpdateParameter { get; set; }
            public bool DeleteParameter { get; set; }
            public string ParameterName { get; set; }                                    
            public byte Precision { get; set; }
            public byte Scale { get; set; }
            public int Size { get; set; }
            public ParameterDirection Direction { get; set; }
            
            /// <summary>
            /// Construtor
            /// </summary>                        
            /// <param name="dbType">Tipo do parâmetro</param>
            /// <param name="selectParameter">Indica se o parâmetro será utilizado nas procedures de Select</param>
            /// <param name="insertParameter">Indica se o parâmetro será utilizado nas procedures de Insert</param>
            /// <param name="updateParameter">Indica se o parâmetro será utilizado nas procedures de Update</param>
            /// <param name="deleteParameter">Indica se o parâmetro será utilizado nas procedures de Delete</param>
            public ProcedureParameterAttribute(DbType dbType, bool selectParameter, bool insertParameter, bool updateParameter, bool deleteParameter)
            {                
                this.DbType = dbType;
                this.SelectParameter = selectParameter;
                this.InsertParameter = insertParameter;
                this.UpdateParameter = updateParameter;
                this.DeleteParameter = deleteParameter;
            }
        }

        /// <summary>
        /// Atributo utilizado para controlar se o atributo vai ser manipulado pelo método ManageSelect
        /// </summary>
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
        public class ManageSelectAttribute : System.Attribute
        {
            private bool _manageSelect = true;

            public bool ManageSelect
            {
                get
                {
                    return _manageSelect;
                }
                set
                {
                    _manageSelect = value;
                }
            }
        }
    }
}

#endregion