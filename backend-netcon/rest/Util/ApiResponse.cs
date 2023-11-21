using System;

namespace rest.Util
{
    /// <summary>
    /// Representa uma resposta padrão da API.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Código de status HTTP da resposta.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Mensagem de erro associada à resposta, se houver.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Data e hora em que a resposta foi gerada.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Valor associado à resposta.
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Cria uma instância de ApiResponse representando uma resposta de erro.
        /// </summary>
        /// <param name="errorMessage">Mensagem de erro.</param>
        /// <returns>Instância de ApiResponse para resposta de erro.</returns>
        public static ApiResponse BadRequestResponse(string errorMessage)
        {
            return new ApiResponse
            {
                StatusCode = 400,
                ErrorMessage = errorMessage,
                DateTime = DateTime.Now,
                Value = null
            };
        }

        /// <summary>
        /// Cria uma instância de ApiResponse representando uma resposta de sucesso.
        /// </summary>
        /// <param name="value">Valor associado à resposta.</param>
        /// <param name="unit">Unidade da resposta.</param>
        /// <returns>Instância de ApiResponse para resposta de sucesso.</returns>
        public static ApiResponse SuccessResponse(double value, string unit)
        {
            return new ApiResponse
            {
                StatusCode = 200,
                ErrorMessage = null,
                DateTime = DateTime.Now,
                Value = $"{value.ToString("E3").Replace('E', '^')} {unit}"
            };
        }
    }
}
