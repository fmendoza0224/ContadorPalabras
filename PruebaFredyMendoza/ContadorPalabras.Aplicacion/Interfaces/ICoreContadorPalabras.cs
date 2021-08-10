using ContadorPalabras.Dominio;
using System.Collections.Generic;

namespace ContadorPalabras.Aplicacion.Interfaces
{
    public interface ICoreContadorPalabras
    {
        List<ContadorPalabra> ContarPalabras(string texto);
    }
}
