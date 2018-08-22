using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace Elo.Service.Client
{
    internal static class ApiClient
    {
        /// <summary>
        /// Client responsável pelo consumo dos dados do endpoint da API
        /// </summary>
        /// <param name="url">URL do endpoint da API</param>
        /// <returns>Instância do objeto Quotes, contendo a data e o valor do câmbio</returns>
        public static Quotes GetJson(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var retorno = JsonConvert.DeserializeObject<ApiResponse>(response.Content.ReadAsStringAsync().Result);

                    if (!retorno.Success)
                    {
                        throw new Exception(retorno.Error.Code + " - " + retorno.Error.Info);
                    }

                    return retorno.Quotes;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Acesso negado, durante tentativa de recuperar os valores.");
                }
                else
                {
                    throw new Exception("Erro inesperado ao recuperar os valores.");
                }
            }
        }
    }
}