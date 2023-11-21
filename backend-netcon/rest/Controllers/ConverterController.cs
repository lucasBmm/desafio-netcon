using Microsoft.AspNetCore.Mvc;
using rest.Util;
using System;

namespace NetConConverterApi.Controllers
{
    /// <summary>
    /// Controller responsável por converter valores entre unidades de medida de quilômetros e anos-luz.
    /// </summary>
    [Route("netcon/api/v1/converter")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        /// <summary>
        /// Converte um valor de quilômetros para anos-luz ou vice-versa, com base nos parâmetros fornecidos.
        /// </summary>
        /// <param name="km">Valor em quilômetros a ser convertido</param>
        /// <param name="anosLuz">Valor em anos-luz a ser convertido</param>
        /// <returns>Um IActionResult representando o resultado da conversão</returns>
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult Convert([FromQuery] string? km, [FromQuery(Name = "anos-luz")] string? anosLuz)
        {
            // Verifica se foi fornecido apenas um dos parâmetros
            if (!String.IsNullOrEmpty(km) && !String.IsNullOrEmpty(anosLuz))
            {
                return BadRequest(ApiResponse.BadRequestResponse("Requisição inválida. Apenas um valor deve ser fornecido e ser maior que zero."));
            }

            if (!IsValidFloat(km!) && !IsValidFloat(anosLuz!))
            {
                return BadRequest(ApiResponse.BadRequestResponse("Formato de valor inválido. Por favor, forneça valores válidos em ponto flutuante para km ou anosLuz."));
            }

            try
            {
                if (!String.IsNullOrEmpty(km))
                {
                    var intKm = Int64.Parse(km!);

                    if (intKm < 1)
                    {
                        return BadRequest(ApiResponse.BadRequestResponse("Valor inválido"));
                    }

                    // Faz a conversão de km para anos-luz
                    var anosLuzValue = intKm * 1.057E-13;

                    return Ok(ApiResponse.SuccessResponse(anosLuzValue, "anos-luz"));
                }
                else
                {
                    var intAnosLuz = Int64.Parse(anosLuz!);

                    if (intAnosLuz < 1)
                    {
                        return BadRequest(ApiResponse.BadRequestResponse("Valor inválido"));
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
