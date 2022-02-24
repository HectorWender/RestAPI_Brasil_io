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

    public async Task<ApiResponseModel> GetData(string state = null, string place_type = null)
    {
      var client = new RestClient(_baseApiUrl);

      var request = new RestRequest
      {
        Method = Method.Get
      };

      if (!string.IsNullOrEmpty(state))
        request.AddParameter("state", state);

      if (!string.IsNullOrEmpty(place_type))
        request.AddParameter("place_type", place_type);

      request.AddParameter("is_last", "True");

      request.AddHeader("Authorization", $"Token {_token}");

      var response = await client.GetAsync(request);

      var retorno = JsonConvert.DeserializeObject<ApiResponseModel>(response.Content);
      return retorno;
    }
  }
}
