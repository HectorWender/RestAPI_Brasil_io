using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAPI_Brasil_io.Models;
using System.Diagnostics;

namespace RestAPI_Brasil_io.Controllers
{
  public class LoginController : Controller
  {
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger) => _logger = logger;

    public IActionResult Index() => View();

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
