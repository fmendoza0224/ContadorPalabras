using ContadorPalabras.Aplicacion.Excepciones;
using ContadorPalabras.Aplicacion.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContadorPalabras.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadorPalabrasController : ControllerBase
    {
        private readonly ICoreContadorPalabras _coreContadorPalabras;

        public ContadorPalabrasController(ICoreContadorPalabras coreContadorPalabras)
        {
            _coreContadorPalabras = coreContadorPalabras;
        }

        /// <summary>
        /// Este servicio retorna un listado de las palabras que se encuentran dentro del texto y la cantidad de veces que se repite ordenando de manera descedente por la cantidad de repeticiones.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult ContarPalabras(string texto)
        {
            try
            {
                if (string.IsNullOrEmpty(texto))
                {
                    throw new ContadorPalabrasException("Debe ingresar al menos una palabra");
                }

                return StatusCode(StatusCodes.Status200OK, _coreContadorPalabras.ContarPalabras(texto));
            }
            catch (ContadorPalabrasException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
