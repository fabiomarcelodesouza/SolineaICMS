namespace SolineaICMS.Util
{
    /// <summary>
    /// Enumeradores
    /// </summary>
    public static class UtilEnums
    {
        /// <summary>
        /// Bancos de dados suportados pelo sistema
        /// </summary>
        public enum Database
        {
            SQLServer,
            PostGreSQL
        }

        /// <summary>
        /// Tipo de mensagens
        /// </summary>
        public enum MessageType
        {
            Error,
            Information,
            Question,
            Warning,
            Success
        }

        /// <summary>
        /// Tipo de arquivo a ser importado
        /// </summary>
        public enum FileType
        {
            xls,
            xlsx,
            xml
        }

        /// <summary>
        /// Ação a ser executada
        /// </summary>
        public enum Acao
        {
            Incluir,
            Editar
        }

        /// <summary>
        /// Tipo de Procedure
        /// </summary>
        public enum ProcedureType
        {
            Select,
            Insert,
            Update,
            Delete,
            Other
        }

        /// <summary>
        /// Tipo de Log
        /// </summary>
        public enum LogType
        {
            ImportarSaldoEstoque,
            ImportarMovimentoEstoque,
            Outros
        }
    }
}
