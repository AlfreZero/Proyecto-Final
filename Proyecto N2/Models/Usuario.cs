using System.ComponentModel.DataAnnotations;

namespace Proyecto_N2.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        [Required, StringLength(100)] public string Nombre { get; set; }
        [Required, EmailAddress, StringLength(150)] public string CorreoElectronico { get; set; }
        [StringLength(30)] public string Telefono { get; set; }
    }
}