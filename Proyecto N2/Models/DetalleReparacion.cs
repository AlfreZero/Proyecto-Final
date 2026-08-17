using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_N2.Models
{
    public class DetalleReparacion
    {
        public int DetalleID { get; set; }
        [Required] public int ReparacionID { get; set; }
        [Required, StringLength(1000)] public string Descripcion { get; set; }
        [Required, DataType(DataType.Date)] public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)] public DateTime? FechaFin { get; set; }
    }
}