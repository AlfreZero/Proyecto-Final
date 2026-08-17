using System.ComponentModel.DataAnnotations;

namespace Proyecto_N2.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress, Display(Name = "Correo electrónico")]
        public string CorreoElectronico { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Contraseña")]
        public string Clave { get; set; }
    }
}
