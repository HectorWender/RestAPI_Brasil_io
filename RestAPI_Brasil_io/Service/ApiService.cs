using Newtonsoft.Json;
using RestAPI_Brasil_io.Models;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Brasil_io.Service
{
    public class ApiService
    {

        private readonly string _token;
        private readonly string _baseApiUrl = "https://api.brasil.io/v1/dataset/covid19/caso/data/";

        public ApiService(string token = null) => _token = token;
        private IEnumerator getEnumerator()
        {
            return (IEnumerator)this;
        }
        public async Task<ApiResponseModel> GetData(Result search = null)
        {
            var client = new RestClient(_baseApiUrl);

            var request = new RestRequest
            {
                Method = Method.Get
            };

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.state))
                {
                    request.AddParameter("state", search.state);
                }
            }

            request.AddHeader("Authorization", $"Token {_token}");

            var response = await client.GetAsync(request);

            var retorno = JsonConvert.DeserializeObject<ApiResponseModel>(response.Content);
            return retorno;
        }
    }
}
