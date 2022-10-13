namespace SolineaICMS.Util
{
    public static class UtilConstants
    {
        public const string ERROR_DESCRIPTION = "Descrição do erro: ";

        public const string CONFIRM_INSERT = "Tem certeza que deseja efetuar a inclusão? ";
        public const string CONFIRM_UPDATE = "Tem certeza que deseja efetuar as alterações? ";

        public const string SUCCESS_INSERT = "Inclusão efetuada com sucesso. ";
        public const string SUCCESS_UPDATE = "Alteração efetuada com sucesso. ";

        public const string CANCEL_UPDATE = "Tem certeza que deseja cancelar as alterações? ";

        public const string TITLE_ERROR = "Erro";
        public const string TITLE_INFORMATION = "Informação";
        public const string TITLE_QUESTION = "Confirmação";
        public const string TITLE_WARNING = "Atenção";

        public const string MSG_ERRO_BANCO_DADOS = "Erro no banco de dados";
        public const string MSG_ERRO_IMPORTAR_ARQUIVO = "Erro ao importar arquivo";
        public const string CAUSA_PROVAVEL_ERRO_VINCULAR_ENTRADAS_SAIDAS = "Ocorreu um erro ao vincular as notas de saída com as notas de entrada. Provavelmente algum produto esteja com estoque insuficiente, ou seja, esteja ocorrendo mais saídas do que entradas do produto.";
        public const string CAUSA_PROVAVEL_ERRO_IMPORTAR_ARQUIVO = "Ocorreu um erro ao importar o arquivo. Se o arquivo for excel, provavelmente os nomes das colunas estão com a nomenclatura errada. Se for um arquivo texto, provavelmente os dados não estão na ordem ou com os separadores corretos.";
    }
}
