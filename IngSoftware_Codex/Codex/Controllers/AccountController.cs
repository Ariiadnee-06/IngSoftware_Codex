using Microsoft.AspNetCore.Mvc;
using Codex.Models;
using Codex.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Codex.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ====== VISTA PRINCIPAL (LOGIN / REGISTRO) ======
        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }

        // ====== LOGIN ======
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            // VALIDACIÓN DE USUARIO
            if (user == null)
            {
                TempData["Error"] = "Usuario o contraseña incorrectos.";
                return RedirectToAction("Auth");
            }

            // GUARDAR SESIÓN
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetInt32("IdType", user.IdType);

            TempData["Success"] = $"Bienvenido {user.Username}!";

            // REDIRECCIÓN SEGÚN IdType
            if (user.IdType == 1)
                return RedirectToAction("Index", "Home");

            if (user.IdType == 2)
                return RedirectToAction("Admin", "UserAdmin"); // ADMIN

            if (user.IdType == 3)
                return RedirectToAction("ProviderAdmin", "ProviderAdmin"); // PROVIDER

            TempData["Error"] = "Tipo de usuario no reconocido.";
            return RedirectToAction("Auth");
        }

        // ====== REGISTRO ======
        [HttpPost]
        public IActionResult Register(string username, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                TempData["Error"] = "Completa todos los campos.";
                return RedirectToAction("Auth");
            }

            if (password != confirmPassword)
            {
                TempData["Error"] = "Las contraseñas no coinciden.";
                return RedirectToAction("Auth");
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                TempData["Error"] = "El usuario ya existe.";
                return RedirectToAction("Auth");
            }

            var newUser = new User
            {
                Username = username,
                Password = password,
                IdType = 1
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            TempData["Success"] = "Registrado con éxito. Ahora puedes iniciar sesión.";
            return RedirectToAction("Auth");
        }

        // ====== LOGOUT ======
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Auth");
        }
    }
}
