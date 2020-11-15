using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlocaGFT.Controllers
{
    public class CepController : Controller
    {
        public async Task<IActionResult> GetEndereco(string cep){
            var result = await GetResultAsync(cep);

            return Json(result);
        }

        private async Task<CEPAbertoResponse> GetResultAsync(string cep)
        {
            var token = "Token token=ffae4b9e771d08ae6c29adb9059f114f";
            var url = "https://www.cepaberto.com/api/v3/cep?cep={0}";

            var client = new WebClient { Encoding = Encoding.UTF8 };
            client.Headers.Add(HttpRequestHeader.Authorization, token);

            var requestResult = await client.DownloadStringTaskAsync(string.Format(url, cep));

            CEPAbertoResponse cepResponse = JsonConvert.DeserializeObject<CEPAbertoResponse>(requestResult);

            return cepResponse;
        }
    }

    public class CEPAbertoResponse
        {
            public Cidade cidade { get; set; }
            public Estado estado { get; set; }
            public string bairro { get; set; }
            public string cep { get; set; }
            public string logradouro { get; set; }
            public decimal? altitude { get; set; }
            public decimal? latitude { get; set; }
            public decimal? longitude { get; set; }

            public class Cidade
            {
                public short? ddd { get; set; }
                public int? ibge { get; set; }
                public string nome { get; set; }
            }

            public class Estado
            {
                public string sigla { get; set; }
            }
        }
}