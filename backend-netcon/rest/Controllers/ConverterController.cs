using Microsoft.AspNetCore.Mvc;
using rest.Util;
using System;

namespace NetConConverterApi.Controllers
{
    /// <summary>
    /// Recebe um valor de km ou anos luz e devolve esse valor convertido para a outra unidade de medida
    /// </summary>
    /// <param name="km">Unidade de medida em quilometros</param>
    /// <param name="anos-luz">Unidade de medida em anos luz</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso tudo dê certo e consiga retornar a unidade de medida corretamente</response>
    /// <response code="400">Caso algum dos dados fornecidos estiver errado</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("netcon/api/v1/converter")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        public ConverterController() { }

        [HttpGet]
        public IActionResult Convert([FromQuery] string? km, [FromQuery(Name = "anos-luz")] string? anosLuz)
        {
            // Verifica se foi fornecido apenas um dos parâmetros
            if ( !String.IsNullOrEmpty(km) && !String.IsNullOrEmpty(anosLuz) )
            {
                return BadRequest(ApiResponse.BadRequestResponse("Invalid request. Only one value must be provided and be greater than zero."));
            }

            if (!IsValidFloat(km!) && !IsValidFloat(anosLuz!))
            {
                return BadRequest(ApiResponse.BadRequestResponse("Invalid value format. Please provide valid float values for km or anosLuz."));
            }

            try
            {
                if (!String.IsNullOrEmpty(km))
                {
                    var intKm = Int32.Parse(km!);

                    if (intKm < 1)
                    {
                        return BadRequest(ApiResponse.BadRequestResponse("Invalid value"));
                    }

                    // Faz a conversão de km para anos-luz
                    var anosLuzValue = intKm * 1.057E-13;

                    return Ok(ApiResponse.SuccessResponse(anosLuzValue, "anos-luz"));
                }
                else
                {
                    var intAnosLuz = Int32.Parse(anosLuz!);

                    if (intAnosLuz < 1)
                    {
                        return BadRequest(ApiResponse.BadRequestResponse("Invalid value"));            
                    }

                    // Faz a conversão de anos-luz para km
                    var kmValue = intAnosLuz * 9.461E12;

                    return Ok(ApiResponse.SuccessResponse(kmValue, "km"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.BadRequestResponse(ex.Message));
            }
        }
        private static bool IsValidFloat(string value)
        {
            return float.TryParse(value, out _);
        }
    }
}
