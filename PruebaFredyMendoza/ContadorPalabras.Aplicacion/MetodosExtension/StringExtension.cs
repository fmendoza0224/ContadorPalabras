namespace ContadorPalabras.Aplicacion.MetodosExtension
{
    public static class StringExtension
    {
        public static string ReemplazarCaracteres(this string texto)
        {
            return texto.Replace('.', ' ').Replace(',', ' ').Replace('(', ' ').Replace(')', ' ');
        }
    }
}
