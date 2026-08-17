using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_N2.Models
{
    public class Asignacion
    {
        public int AsignacionID { get; set; }
        [Required] public int ReparacionID { get; set; }
        [Required] public int TecnicoID { get; set; }
        [Required, DataType(DataType.Date)] public DateTime FechaAsignacion { get; set; }
        public string NombreTecnico { get; set; }
        public string EstadoReparacion { get; set; }
    }
}