using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Elo.Service.Client
{
    internal static class ApiClient
    {
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

        public static Quotes GetJsonMock(string url)
        {
            return new Quotes()
            {
                Date = DateTime.Now.Date,
                USDARS = 0.33M,
                USDBRL = 3.77M,
                USDEUR = 4.38M
            };
        }
    }
}
