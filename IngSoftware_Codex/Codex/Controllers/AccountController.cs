using Microsoft.AspNetCore.Mvc;
using Codex.Models;
using Codex.Data;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
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

        // Vista de login/registro
        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }

        // ===== LOGIN =====
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null || !VerifyPassword(password, user.Password))
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View("Auth");
            }

            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Rol", user.Rol);

            return RedirectToAction("Index", "Home");
        }

        // ===== REGISTER =====
        [HttpPost]
        public IActionResult Register(string username, string password, string confirmPassword)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                ViewBag.Error = "El usuario ya existe";
                return View("Auth");
            }

            if (password != confirmPassword)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View("Auth");
            }

            var hashedPassword = HashPassword(password);

            var newUser = new User
            {
                Username = username,
                Password = hashedPassword,
                Rol = "Usuario",
                IdType = 1
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            ViewBag.Message = "Registrado con éxito. Ahora puedes iniciar sesión.";
            return View("Auth");
        }

        // ===== Métodos auxiliares =====
        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            var parts = storedPassword.Split('.');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            string hashedEntered = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedEntered == parts[1];
        }
    }
}
