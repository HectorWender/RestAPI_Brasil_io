using Newtonsoft.Json;
using RestAPI_Brasil_io.Models;
using RestSharp;
using System.Threading.Tasks;

namespace RestAPI_Brasil_io.Service
{
    public class ApiService
    {

        private readonly string _token;
        private readonly string _baseApiUrl = "https://api.brasil.io/v1/dataset/covid19/caso/data/";

        public ApiService(string token = null) => _token = token;

        public async Task<ApiResponseModel> GetData(Result search = null)
        {
            var client = new RestClient(_baseApiUrl);

            var request = new RestRequest
            {
                Method = Method.Get
            };

            request.AddParameter("search", "");

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.state))
                    request.AddParameter("state", search.state);

                if (!string.IsNullOrEmpty(search.city))
                    request.AddParameter("city", search.city);

                if (!string.IsNullOrEmpty(search.place_type))
                    request.AddParameter("place_type", search.place_type);

                if (!string.IsNullOrEmpty(search.date))
                    request.AddParameter("date", search.date);

                if (!string.IsNullOrEmpty(search.is_last))
                    request.AddParameter("is_last", search.is_last);
            }
            else
                return null;

            request.AddHeader("Authorization", $"Token {_token}");

            var response = await client.GetAsync(request);

            var retorno = JsonConvert.DeserializeObject<ApiResponseModel>(response.Content);
            return retorno;
        }
    }
}
