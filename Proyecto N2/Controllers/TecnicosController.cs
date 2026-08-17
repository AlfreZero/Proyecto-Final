using System.Web.Mvc; using Proyecto_N2.Logic; using Proyecto_N2.Models;
namespace Proyecto_N2.Controllers
{ [Authorize]
public class TecnicosController : Controller
{ private readonly TecnicoLogica logica = new TecnicoLogica();
public ActionResult Index() { return View(logica.Listar()); }
public ActionResult Crear() { return View(new Tecnico()); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Crear(Tecnico item) { if(!ModelState.IsValid)return View(item); logica.Guardar(item); return RedirectToAction("Index"); }
public ActionResult Editar(int id) { var item = logica.ObtenerPorId(id); if (item == null) return HttpNotFound(); return View(item); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Editar(Tecnico item) { if(!ModelState.IsValid)return View(item); logica.Editar(item); return RedirectToAction("Index"); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Eliminar(int id) { logica.Eliminar(id); return RedirectToAction("Index"); }
} }