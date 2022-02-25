using Microsoft.AspNetCore.Mvc;
using RestAPI_Brasil_io.Database;
using RestAPI_Brasil_io.Models;
using System.Linq;

namespace WebMySQL.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {
            var user = (from u in _context.User
                       where u.Email == login.Email
                       select u).FirstOrDefault();

            if (user == null)
                ModelState.AddModelError("Email", "User not found!");

            if (user != null && user.Password != login.Password)
                ModelState.AddModelError("Password", "Invalid Password");

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Api");
            }

            return View(login);

        }
    }
}
