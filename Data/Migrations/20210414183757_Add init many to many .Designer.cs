﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server;

namespace server.Data.Migrations
{
    [DbContext(typeof(takaContext))]
    [Migration("20210414183757_Add init many to many ")]
    partial class Addinitmanytomany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("server.Models.Clase", b =>
                {
                    b.Property<int>("IdClase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_clase");

                    b.Property<sbyte?>("Activo")
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("activo");

                    b.Property<TimeSpan?>("HoraFin")
                        .HasColumnType("time")
                        .HasColumnName("hora_fin");

                    b.Property<TimeSpan?>("HoraInicio")
                        .HasColumnType("time")
                        .HasColumnName("hora_inicio");

                    b.Property<int?>("IdHorario")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_horario");

                    b.Property<int?>("IdMaestro")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_maestro");

                    b.Property<int?>("IdMateria")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_materia");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("IdClase")
                        .HasName("PRIMARY");

                    b.HasIndex("IdHorario");

                    b.HasIndex("IdMaestro");

                    b.HasIndex("IdMateria");

                    b.ToTable("clase");
                });

            modelBuilder.Entity("server.Models.Especialidad", b =>
                {
                    b.Property<int>("IdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_especialidad");

                    b.Property<sbyte?>("Activo")
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("activo");

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("codigo")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("IdEspecialidad")
                        .HasName("PRIMARY");

                    b.ToTable("especialidades");
                });

            modelBuilder.Entity("server.Models.Grupo", b =>
                {
                    b.Property<int>("IdGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_grupo");

                    b.Property<sbyte?>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("activo")
                        .HasDefaultValueSql("'1'");

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("codigo")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<int?>("IdEspecialidad")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_especialidad");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("IdGrupo")
                        .HasName("PRIMARY");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("grupos");
                });

            modelBuilder.Entity("server.Models.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_horario");

                    b.Property<sbyte?>("Activo")
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("activo");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_grupo");

                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_periodo");

                    b.HasKey("IdHorario")
                        .HasName("PRIMARY");

                    b.HasIndex("IdGrupo");

                    b.HasIndex("IdPeriodo");

                    b.ToTable("horario");
                });

            modelBuilder.Entity("server.Models.Materia", b =>
                {
                    b.Property<int>("IdMateria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_materia");

                    b.Property<sbyte?>("Activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("activo")
                        .HasDefaultValueSql("'1'");

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("codigo")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("IdMateria")
                        .HasName("PRIMARY");

                    b.ToTable("materias");
                });

            modelBuilder.Entity("server.Models.Periodo", b =>
                {
                    b.Property<int>("IdPeriodo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_periodo");

                    b.Property<sbyte?>("Activo")
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("activo");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("date")
                        .HasColumnName("fecha_fin");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("date")
                        .HasColumnName("fecha_inicio");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.HasKey("IdPeriodo")
                        .HasName("PRIMARY");

                    b.ToTable("periodos");
                });

            modelBuilder.Entity("server.Models.Role", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<sbyte?>("Activo")
                        .HasColumnType("tinyint");

                    b.Property<string>("Codigo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdRol")
                        .HasName("PRIMARY");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("server.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_usuario");

                    b.Property<sbyte?>("Activo")
                        .HasColumnType("tinyint(4)")
                        .HasColumnName("activo");

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("apellido_materno")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("ApellidoPaterno")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("apellido_paterno")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Curp")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("curp")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("matricula")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre")
                        .UseCollation("latin1_swedish_ci")
                        .HasCharSet("latin1");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("RoleIdRol")
                        .HasColumnType("int");

                    b.Property<string>("UserNameNormalize")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdUsuario")
                        .HasName("PRIMARY");

                    b.HasIndex("RoleIdRol");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("server.Models.Clase", b =>
                {
                    b.HasOne("server.Models.Horario", "Horario")
                        .WithMany()
                        .HasForeignKey("IdHorario");

                    b.HasOne("server.Models.Usuario", "Maestro")
                        .WithMany()
                        .HasForeignKey("IdMaestro");

                    b.HasOne("server.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("IdMateria");

                    b.Navigation("Horario");

                    b.Navigation("Maestro");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("server.Models.Grupo", b =>
                {
                    b.HasOne("server.Models.Especialidad", "Especialidad")
                        .WithMany()
                        .HasForeignKey("IdEspecialidad");

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("server.Models.Horario", b =>
                {
                    b.HasOne("server.Models.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("server.Models.Periodo", "Periodo")
                        .WithMany()
                        .HasForeignKey("IdPeriodo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");

                    b.Navigation("Periodo");
                });

            modelBuilder.Entity("server.Models.Usuario", b =>
                {
                    b.HasOne("server.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleIdRol");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
