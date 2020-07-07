﻿using System;
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
        public string Requerimiento { get; set; }
        public int TiempoMinutos { get; set; }
    }

}

