using System.Web.Mvc; using Proyecto_N2.Logic; using Proyecto_N2.Models;
namespace Proyecto_N2.Controllers
{ [Authorize]
public class ReparacionesController : Controller
{ private readonly ReparacionLogica logica = new ReparacionLogica();
public ActionResult Index() { return View(logica.Listar()); }
public ActionResult Crear() { CargarEquipos(); return View(new Reparacion { FechaSolicitud = System.DateTime.Today }); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Crear(Reparacion item) { if(!ModelState.IsValid) { CargarEquipos(); return View(item); } logica.Guardar(item); return RedirectToAction("Index"); }
public ActionResult Editar(int id) { var item=logica.ObtenerPorId(id); if(item==null)return HttpNotFound(); CargarEquipos(); return View(item); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Editar(Reparacion item) { if(!ModelState.IsValid) { CargarEquipos(); return View(item); } logica.Editar(item); return RedirectToAction("Index"); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Eliminar(int id) { logica.Eliminar(id); return RedirectToAction("Index"); }
private void CargarEquipos() { ViewBag.Equipos = new EquipoLogica().Listar(); }
} }