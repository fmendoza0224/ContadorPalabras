using System;
using System.Runtime.Serialization;

namespace ContadorPalabras.Aplicacion.Excepciones
{
    public class ContadorPalabrasException : Exception
    {
        public ContadorPalabrasException(string message) : base(message) { }

        public ContadorPalabrasException(string message, Exception innerException) : base(message, innerException) { }

        protected ContadorPalabrasException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
