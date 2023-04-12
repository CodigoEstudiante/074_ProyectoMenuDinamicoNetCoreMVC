using Microsoft.AspNetCore.Mvc;

using proyectomenu.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace proyectomenu.Controllers
{
    public class LoginController : Controller
    {
        private readonly DBPRUEBASContext _context;

        public LoginController(DBPRUEBASContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Menu> menulista = _context.Menus.Include(m => m.InverseIdMenuPadreNavigation)
                .Where(m => m.IdMenuPadre == null).ToList();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
            };

            HttpContext.Session.SetString("menu", JsonSerializer.Serialize(menulista, options));

            return View();
        }
    }
}
