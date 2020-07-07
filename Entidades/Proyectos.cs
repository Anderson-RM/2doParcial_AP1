using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _2doParcial.Entidades
{
    public class Proyectos
    { 
            [Key]
            public int ProyectoId { get; set; }
            public DateTime Fecha { get; set; } = DateTime.Now;
            public string DescripcionProyecto { get; set; }
            public int TiempoTotal { get; set; }
            public virtual List<ProyectosDetalle> ProyectoDetalles { get; set; } = new List<ProyectosDetalle>();
        
    }
}
