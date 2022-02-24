using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestAPI_Brasil_io.Service;
using System.Threading.Tasks;

namespace RestAPI_Brasil_io.Controllers
{
  public class ApiController : Controller
  {

    private readonly IConfiguration _configuration;

    public ApiController(IConfiguration configuration) => _configuration = configuration;

    public async Task<IActionResult> Index()
    {
      var service = new ApiService(_configuration.GetValue<string>("BrasilIOApiToken"));
      var response = await service.GetData();

      return View(response.results);
    }
  }
}