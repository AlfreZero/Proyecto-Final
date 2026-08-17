using System.Web.Security;
using System.Web.Mvc;
using Proyecto_N2.Logic;
using Proyecto_N2.Models;

namespace Proyecto_N2.Controllers
{
    public class CuentaController : Controller
    {
        private readonly CuentaLogica logica = new CuentaLogica();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel modelo, string returnUrl)
        {
            if (!ModelState.IsValid) return View(modelo);

            var usuario = logica.Validar(modelo);
            if (usuario == null)
            {
                ModelState.AddModelError("", "El correo o la contraseña no son correctos.");
                return View(modelo);
            }

            FormsAuthentication.SetAuthCookie(usuario.CorreoElectronico, false);
            Session["UsuarioActual"] = usuario;
            return RedirectToLocal(returnUrl);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Cuenta");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            return !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)
                ? (ActionResult)Redirect(returnUrl)
                : RedirectToAction("Index", "Home");
        }
    }
}
