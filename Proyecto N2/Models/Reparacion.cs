using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_N2.Models
{
    public class Reparacion
    {
        public int ReparacionID { get; set; }
        [Required] public int EquipoID { get; set; }
        public string TipoEquipo { get; set; }
        [Required, DataType(DataType.Date)] public DateTime FechaSolicitud { get; set; }
        [Required, StringLength(40)] public string Estado { get; set; }
    }
}