using System.Web.Mvc; using Proyecto_N2.Logic; using Proyecto_N2.Models;
namespace Proyecto_N2.Controllers
{ [Authorize]
public class AsignacionesController : Controller
{ private readonly AsignacionLogica logica = new AsignacionLogica();
public ActionResult Index() { return View(logica.Listar()); }
public ActionResult Crear() { CargarCatalogos(); return View(new Asignacion { FechaAsignacion = System.DateTime.Today }); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Crear(Asignacion item) { if(!ModelState.IsValid) { CargarCatalogos(); return View(item); } logica.Guardar(item); return RedirectToAction("Index"); }
public ActionResult Editar(int id) { var item=logica.ObtenerPorId(id); if(item==null)return HttpNotFound(); CargarCatalogos(); return View(item); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Editar(Asignacion item) { if(!ModelState.IsValid) { CargarCatalogos(); return View(item); } logica.Editar(item); return RedirectToAction("Index"); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Eliminar(int id) { logica.Eliminar(id); return RedirectToAction("Index"); }
private void CargarCatalogos() { ViewBag.Reparaciones = new ReparacionLogica().Listar(); ViewBag.Tecnicos = new TecnicoLogica().Listar(); }
} }