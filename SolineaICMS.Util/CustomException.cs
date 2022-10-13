using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolineaICMS.Util
{
    public class CustomException : Exception
    {
        public string Mensagem { get; set; }
        public string CausaProvavel { get; set; }
        public string NomeProcedure { get; set; }        

        public CustomException()
            : base()
        {
        }

        public CustomException(string mensagem)
            : base(mensagem)
        {
            this.Mensagem = mensagem;
        }

        public CustomException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {
            this.Mensagem = mensagem;          
        }

        public CustomException(string mensagem, Exception innerException, string causaProvavel)
            : base(mensagem, innerException)
        {
            this.Mensagem = mensagem;
            this.CausaProvavel = causaProvavel;
        }

        public CustomException(string mensagem, Exception innerException, string causaProvavel, string nomeProcedure)
            : base(mensagem, innerException)
        {
            this.Mensagem = mensagem;         
            this.NomeProcedure = nomeProcedure;
            this.CausaProvavel = causaProvavel;
        }
    }
}
