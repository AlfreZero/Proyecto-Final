using System.ComponentModel.DataAnnotations;

namespace Proyecto_N2.Models
{
    public class Equipo
    {
        public int EquipoID { get; set; }
        [Required, StringLength(80)] public string TipoEquipo { get; set; }
        [Required, StringLength(80)] public string Modelo { get; set; }
        [Required] public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
    }
}