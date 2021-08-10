namespace ContadorPalabras.Dominio
{
    public class ContadorPalabra
    {
        /// <summary>
        /// Hace referencia a la palabra que se va a contar y es parte texto
        /// </summary>
        public string Palabra { get; set; }

        /// <summary>
        /// Cantidad de veces que se encuentra la palabra en el texto
        /// </summary>
        public int NumeroRepeticiones { get; set; }
    }
}
