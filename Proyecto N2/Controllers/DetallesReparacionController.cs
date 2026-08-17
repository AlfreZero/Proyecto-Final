using System.Web.Mvc; using Proyecto_N2.Logic; using Proyecto_N2.Models;
namespace Proyecto_N2.Controllers
{ [Authorize]
public class DetallesReparacionController : Controller
{ private readonly DetalleReparacionLogica logica = new DetalleReparacionLogica();
public ActionResult Index() { return View(logica.Listar()); }
public ActionResult Crear() { CargarReparaciones(); return View(new DetalleReparacion { FechaInicio = System.DateTime.Today }); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Crear(DetalleReparacion item) { if(!ModelState.IsValid) { CargarReparaciones(); return View(item); } logica.Guardar(item); return RedirectToAction("Index"); }
public ActionResult Editar(int id) { var item=logica.ObtenerPorId(id); if(item==null)return HttpNotFound(); CargarReparaciones(); return View(item); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Editar(DetalleReparacion item) { if(!ModelState.IsValid) { CargarReparaciones(); return View(item); } logica.Editar(item); return RedirectToAction("Index"); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Eliminar(int id) { logica.Eliminar(id); return RedirectToAction("Index"); }
private void CargarReparaciones() { ViewBag.Reparaciones = new ReparacionLogica().Listar(); }
} }