using System.Web.Mvc; using Proyecto_N2.Logic; using Proyecto_N2.Models;
namespace Proyecto_N2.Controllers
{ [Authorize]
public class UsuariosController : Controller
{ private readonly UsuarioLogica logica = new UsuarioLogica();
public ActionResult Index() { return View(logica.Listar()); }
public ActionResult Crear() { return View(new Usuario()); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Crear(Usuario item) { if(!ModelState.IsValid)return View(item); logica.Guardar(item); return RedirectToAction("Index"); }
        public ActionResult Editar(int id)
        {
            var item = logica.ObtenerPorId(id);
            if (item == null) return HttpNotFound();
            return View(item);
        }

        [HttpPost, ValidateAntiForgeryToken] public ActionResult Editar(Usuario item) { if(!ModelState.IsValid)return View(item); logica.Editar(item); return RedirectToAction("Index"); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Eliminar(int id) { logica.Eliminar(id); return RedirectToAction("Index"); }
} }