using Microsoft.AspNetCore.Mvc;
using Codex.Data;
using Codex.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Codex.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ====== LISTAR USUARIOS ======
        public IActionResult Admin()
        {
            var username = HttpContext.Session.GetString("Username");
            var idType = HttpContext.Session.GetInt32("IdType");

            // Validación de permisos
            if (username == null || idType != 2)
            {
                return RedirectToAction("Auth", "Account");
            }

            var usuarios = _context.Users.ToList();
            return View(usuarios);
        }

        // ====== EDITAR USUARIO ======
        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            if (updatedUser == null || updatedUser.IdUsers == 0)
            {
                TempData["Error"] = "Datos inválidos para la edición.";
                return RedirectToAction("Admin");
            }

            var user = _context.Users.Find(updatedUser.IdUsers);

            if (user == null)
            {
                TempData["Error"] = "El usuario que intentas editar no existe.";
                return RedirectToAction("Admin");
            }

            // Actualizar datos
            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;
            user.IdType = updatedUser.IdType;

            _context.SaveChanges();

            TempData["Success"] = "Usuario actualizado correctamente.";
            return RedirectToAction("Admin");
        }

        // ====== ELIMINAR USUARIO ======
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                TempData["Error"] = "El usuario que intentas eliminar no existe.";
                return RedirectToAction("Admin");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            TempData["Success"] = "Usuario eliminado correctamente.";
            return RedirectToAction("Admin");
        }
    }
}
