using Microsoft.AspNetCore.Mvc;
using Codex.Data;
using Codex.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Codex.Controllers
{
    public class ProviderAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProviderAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ====== LISTAR COMPUTADORES ======
        public IActionResult ProviderAdmin()
        {
            var username = HttpContext.Session.GetString("Username");
            var idType = HttpContext.Session.GetInt32("IdType");

            // Validación de permisos
            if (username == null || idType != 3)
            {
                return RedirectToAction("Auth", "Account");
            }

            var providers = _context.Computers.ToList();
            return View(providers);
        }

        // ====== EDITAR ======
        [HttpPost]
        public IActionResult Edit(Computers updated)
        {
            if (updated == null || updated.IdComputers == 0)
            {
                TempData["Error"] = "Datos inválidos para la edición.";
                return RedirectToAction("ProviderAdmin");
            }

            var comp = _context.Computers.Find(updated.IdComputers);

            if (comp == null)
            {
                TempData["Error"] = "El computador no existe.";
                return RedirectToAction("ProviderAdmin");
            }

            // Actualizar datos
            comp.Brand = updated.Brand;
            comp.Model = updated.Model;
            comp.Processor = updated.Processor;
            comp.Memory = updated.Memory;
            comp.Storage = updated.Storage;
            comp.Price = updated.Price;

            _context.SaveChanges();

            TempData["Success"] = "Registro actualizado correctamente.";
            return RedirectToAction("ProviderAdmin");
        }

        // ====== ELIMINAR ======
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var comp = _context.Computers.Find(id);

            if (comp == null)
            {
                TempData["Error"] = "El registro no existe.";
                return RedirectToAction("ProviderAdmin");
            }

            _context.Computers.Remove(comp);
            _context.SaveChanges();

            TempData["Success"] = "Registro eliminado correctamente.";
            return RedirectToAction("ProviderAdmin");
        }

        [HttpPost]
        public IActionResult Create(Computers newComp)
        {
            // Convertir price manualmente para evitar errores de cultura
            string priceString = Request.Form["Price"];

            if (!decimal.TryParse(priceString, System.Globalization.NumberStyles.Any,
                                  System.Globalization.CultureInfo.InvariantCulture, out decimal price))
            {
                TempData["Error"] = "El precio no es válido.";
                return RedirectToAction("ProviderAdmin");
            }

            newComp.Price = price;

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(newComp.Brand) ||
                string.IsNullOrWhiteSpace(newComp.Model) ||
                string.IsNullOrWhiteSpace(newComp.Processor) ||
                string.IsNullOrWhiteSpace(newComp.Memory) ||
                string.IsNullOrWhiteSpace(newComp.Storage))
            {
                TempData["Error"] = "Todos los campos son obligatorios.";
                return RedirectToAction("ProviderAdmin");
            }

            // Guardar en BD
            _context.Computers.Add(newComp);
            _context.SaveChanges();

            TempData["Success"] = "Computador agregado correctamente.";
            return RedirectToAction("ProviderAdmin");
        }

    }
}
