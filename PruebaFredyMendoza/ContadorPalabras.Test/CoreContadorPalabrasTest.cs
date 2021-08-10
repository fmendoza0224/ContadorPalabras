using ContadorPalabras.Aplicacion;
using ContadorPalabras.Dominio;
using NUnit.Framework;
using System.Collections.Generic;

namespace ContadorPalabras.Test
{
    [TestFixture]
    public class CoreContadorPalabrasTest
    {
        private string texto;
        private List<ContadorPalabra> listaPalabras;

        [SetUp]
        public void SetUp()
        {
            listaPalabras = new List<ContadorPalabra>
            {
                new ContadorPalabra { Palabra = "NET", NumeroRepeticiones = 7 },
                new ContadorPalabra { Palabra = "de", NumeroRepeticiones = 6 },
                new ContadorPalabra { Palabra = "Python", NumeroRepeticiones = 4 }
            };

            texto = "Python.NET () es un paquete que ofrece a los programadores de Python una integración casi perfecta con .NET 4.0+ Common Language Runtime (CLR) en Windows y mono runtime en Linux y OSX. Python.NET proporciona una eficaz herramienta de scripting de aplicaciones para los desarrolladores de .NET. Con este paquete puede crear scripts de aplicaciones .NET o crear aplicaciones completas en Python, utilizando servicios y componentes de .NET escritos en cualquier lenguaje destinado a CLR (C#, VB.NET, F#, C++/CLI)";
        }

        [Test]
        public void ContarPalabrasExitosoTest()
        {
            CoreContadorPalabras coreContadorPalabras = new CoreContadorPalabras();
            var resultado = coreContadorPalabras.ContarPalabras(texto);

            Assert.AreEqual(listaPalabras[0].Palabra, resultado[0].Palabra);
            Assert.AreEqual(listaPalabras[0].NumeroRepeticiones, resultado[0].NumeroRepeticiones);
            Assert.AreEqual(listaPalabras[1].Palabra, resultado[1].Palabra);
            Assert.AreEqual(listaPalabras[1].NumeroRepeticiones, resultado[1].NumeroRepeticiones);
        }
    }
}
