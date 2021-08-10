using ContadorPalabras.Aplicacion.Excepciones;
using ContadorPalabras.Aplicacion.Interfaces;
using ContadorPalabras.Aplicacion.MetodosExtension;
using ContadorPalabras.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContadorPalabras.Aplicacion
{
    public class CoreContadorPalabras : ICoreContadorPalabras
    {
        public CoreContadorPalabras() { }

        public List<ContadorPalabra> ContarPalabras(string texto)
        {
            try
            {
                List<string> listaPalabras = texto.ReemplazarCaracteres().Split(' ').Where(exp => !string.IsNullOrEmpty(exp)).ToList();

                return listaPalabras.GroupBy(exp => exp)
                                          .Select(exp => new ContadorPalabra { Palabra = exp.Key, NumeroRepeticiones = exp.Count() })
                                          .OrderByDescending(exp => exp.NumeroRepeticiones).ToList();
            }
            catch (Exception ex)
            {
                throw new ContadorPalabrasException($"{ex.Message} {Environment.NewLine} {ex.InnerException}");
            }
        }
    }
}
