using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Aula01.Exercicio.Exceptions
{
    //exception tab tab

    [Serializable]
    public class NoBalanceException : Exception
    {
        public NoBalanceException() { }
        public NoBalanceException(string message) : base(message) { }
        public NoBalanceException(string message, Exception inner) : base(message, inner) { }
        protected NoBalanceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
