using Loja.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Loja.Controllers
{
    public class ClienteController : Controller
    {      

        public IActionResult CadastrarCliente()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
