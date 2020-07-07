using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2doParcial.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public int TipoId { get; set; }

        [ForeignKey("TipoId")]
        public Tareas Tarea { get; set; } = new Tareas();
        /*public int TareaId { get; set; }*/
        public string Requerimiento { get; set; }
        public int TiempoMinutos { get; set; }


        /*public ProyectosDetalle() 
        {
            Id = 0;
            ProyectoId = 0;
            TipoId = 0;
            Tareasid = 0;
            Requerimiento = string.Empty;
            TiempoMinutos = 0;

        }

        public ProyectosDetalle(int id, int proyectoid, int tipoid,int tareaid,string requerimiento,int minutos)
        {
            Id = id;
            ProyectoId = proyectoid;
            TipoId = tipoid;
            Tareasid = tareaid;
            Requerimiento = requerimiento;
            TiempoMinutos = minutos;
        }*/
    }

}

