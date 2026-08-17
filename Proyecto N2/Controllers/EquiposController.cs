using System.Web.Mvc; using Proyecto_N2.Logic; using Proyecto_N2.Models;
namespace Proyecto_N2.Controllers
{ [Authorize]
public class EquiposController : Controller
{ private readonly EquipoLogica logica = new EquipoLogica();
public ActionResult Index() { return View(logica.Listar()); }
public ActionResult Crear() { CargarUsuarios(); return View(new Equipo()); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Crear(Equipo item) { if(!ModelState.IsValid) { CargarUsuarios(); return View(item); } logica.Guardar(item); return RedirectToAction("Index"); }
public ActionResult Editar(int id) { var item=logica.ObtenerPorId(id); if(item==null)return HttpNotFound(); CargarUsuarios(); return View(item); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Editar(Equipo item) { if(!ModelState.IsValid) { CargarUsuarios(); return View(item); } logica.Editar(item); return RedirectToAction("Index"); }
[HttpPost, ValidateAntiForgeryToken] public ActionResult Eliminar(int id) { logica.Eliminar(id); return RedirectToAction("Index"); }
private void CargarUsuarios() { ViewBag.Usuarios = new UsuarioLogica().Listar(); }
} }