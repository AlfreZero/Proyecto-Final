using System.ComponentModel.DataAnnotations;

namespace Proyecto_N2.Models
{
    public class Tecnico
    {
        public int TecnicoID { get; set; }
        [Required, StringLength(100)] public string Nombre { get; set; }
        [Required, StringLength(100)] public string Especialidad { get; set; }
    }
}