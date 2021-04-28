using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server.Models;

#nullable disable

namespace server
{
    public partial class takaContext : DbContext
    {
        public takaContext()
        {
        }

        public takaContext(DbContextOptions<takaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clase> Clases { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<Usuario> Usuarios {get;set;}
        public virtual DbSet<Role> Roles {get;set;}
        public virtual DbSet<ClaseAlumno> ClaseAlumnos {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=iguanadevs.com;user=develop;password=5jO9w_ML!.b?;database=taka_p", Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.6.49-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.IdClase)
                    .HasName("PRIMARY");

                entity.ToTable("clase");

                entity.Property(e => e.IdClase)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_clase");

                entity.Property(e => e.Activo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("activo")
                    .HasDefaultValue(true);

                entity.Property(e => e.HoraFin)
                    .HasColumnType("time")
                    .HasColumnName("hora_fin");

                entity.Property(e => e.HoraInicio)
                    .HasColumnType("time")
                    .HasColumnName("hora_inicio");

                entity.Property(e => e.IdMaestro)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_maestro");

                entity.Property(e => e.IdMateria)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_materia");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("nombre")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(c => c.Materia)
                    .WithMany()
                    .HasForeignKey(c => c.IdMateria);

                entity.HasOne(c => c.Maestro)
                    .WithMany()
                    .HasForeignKey(c => c.IdMaestro);

                entity.HasOne(c => c.Grupo)
                    .WithMany()
                    .HasForeignKey(c => c.IdGrupo);
                
                entity.HasOne(c => c.Periodo)
                    .WithMany()
                    .HasForeignKey(c => c.IdPeriodo);
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad)
                    .HasName("PRIMARY");

                entity.ToTable("especialidades");

                entity.Property(e => e.IdEspecialidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_especialidad");

                entity.Property(e => e.Activo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("activo")
                    .HasDefaultValue(true);

                entity.Property(e => e.Codigo)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("codigo")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("nombre")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo)
                    .HasName("PRIMARY");

                entity.ToTable("grupos");

                entity.Property(e => e.IdGrupo)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_grupo");

                entity.Property(e => e.Activo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("activo")
                    .HasDefaultValue(true);

                entity.Property(e => e.Codigo)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("codigo")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdEspecialidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_especialidad");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("nombre")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(g => g.Especialidad)
                    .WithMany()
                    .HasForeignKey(g => g.IdEspecialidad);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PRIMARY");

                entity.ToTable("materias");

                entity.Property(e => e.IdMateria)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_materia");

                entity.Property(e => e.Activo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("activo")
                    .HasDefaultValue(true);

                entity.Property(e => e.Codigo)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("codigo")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("nombre")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo)
                    .HasName("PRIMARY");

                entity.ToTable("periodos");

                entity.Property(e => e.IdPeriodo)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_periodo");

                entity.Property(e => e.Activo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("activo");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("nombre")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");
                
                entity.ToTable("roles");
            });


            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(u => u.UserName)
                    .IsUnique();
                
                entity.HasIndex(u => u.Matricula)
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_usuario");

                entity.Property(e => e.Activo)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("activo")
                    .HasDefaultValue(true);

                entity.Property(e => e.ApellidoMaterno)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("apellido_materno")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ApellidoPaterno)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("apellido_paterno")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Curp)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("curp")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("username")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Matricula)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("matricula")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("nombre")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(u => u.Role)
                    .WithMany()
                    .HasForeignKey(u => u.IdRole);

                entity.HasMany(u => u.Clases)
                    .WithMany(c => c.Alumnos)
                    .UsingEntity<ClaseAlumno>(
                        j => j.HasOne(ca => ca.Clase)
                            .WithMany(c => c.ClaseAlumnos)
                            .HasForeignKey(ca => ca.IdClase),
                        j => j.HasOne(ca => ca.Alumno)
                            .WithMany(a => a.ClaseAlumnos)
                            .HasForeignKey(ca => ca.IdAlumno),
                        j => {
                            j.Property(ca => ca.Parcial1).HasColumnType("decimal(5,2)");
                            j.Property(ca => ca.Parcial2).HasColumnType("decimal(5,2)");
                            j.Property(ca => ca.Parcial3).HasColumnType("decimal(5,2)");

                            j.HasKey(ca => new {ca.IdAlumno, ca.IdClase});   
                        }
                    );   

            });

            modelBuilder.Entity<ClaseAlumno>(entity => {
                entity.HasOne(ca => ca.Alumno)
                .WithMany(a => a.ClaseAlumnos)
                .HasForeignKey(ca => ca.IdAlumno);

                entity.HasOne(ca => ca.Clase)
                .WithMany(a => a.ClaseAlumnos)
                .HasForeignKey(ca => ca.IdClase);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
