﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2doParcial.DAL;

namespace _2doParcial.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200707074003_Migracion_Inicial")]
    partial class Migracion_Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("_2doParcial.Entidades.Proyectos", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionProyecto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("TiempoTotal")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("_2doParcial.Entidades.ProyectosDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProyectosProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("TiempoMinutos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProyectosProyectoId");

                    b.HasIndex("TipoId");

                    b.ToTable("ProyectosDetalle");
                });

            modelBuilder.Entity("_2doParcial.Entidades.Tareas", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("TareaId");

                    b.ToTable("Tareas");

                    b.HasData(
                        new
                        {
                            TareaId = 1,
                            TipoTarea = "Analisis"
                        },
                        new
                        {
                            TareaId = 2,
                            TipoTarea = "Diseño"
                        },
                        new
                        {
                            TareaId = 3,
                            TipoTarea = "Programación"
                        },
                        new
                        {
                            TareaId = 4,
                            TipoTarea = "Prueba"
                        });
                });

            modelBuilder.Entity("_2doParcial.Entidades.ProyectosDetalle", b =>
                {
                    b.HasOne("_2doParcial.Entidades.Proyectos", null)
                        .WithMany("ProyectoDetalles")
                        .HasForeignKey("ProyectosProyectoId");

                    b.HasOne("_2doParcial.Entidades.Tareas", "Tarea")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}