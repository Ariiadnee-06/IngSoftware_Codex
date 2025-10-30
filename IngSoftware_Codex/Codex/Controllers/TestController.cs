using Codex.Data;
using Microsoft.AspNetCore.Mvc;

namespace Codex.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return Content($"Base de datos conectada. Usuarios encontrados: {users.Count}");
        }
    }
}
