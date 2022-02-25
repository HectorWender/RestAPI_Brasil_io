using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestAPI_Brasil_io.Models;
using RestAPI_Brasil_io.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Brasil_io.Controllers
{
    public class ApiController : Controller
    {
        private readonly ApiService _service;

        public ApiController(IConfiguration configuration)
        {
            _service = new ApiService(configuration.GetValue<string>("BrasilIOApiToken"));
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetData();
            if(response == null)
                return View(response);

            return View(response.results);
        }

        public async Task<IActionResult> SearchApi(Result search)
        {
            var response = await _service.GetData(search);
            return View("Index",response.results);
        }
    }
}