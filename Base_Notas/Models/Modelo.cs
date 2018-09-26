namespace Base_Notas.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<alumnos> alumnos { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<notas> notas { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<alumnos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<alumnos>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<alumnos>()
                .HasMany(e => e.notas)
                .WithOptional(e => e.alumnos)
                .HasForeignKey(e => e.id_alum);

            modelBuilder.Entity<Materias>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Materias>()
                .HasMany(e => e.notas)
                .WithOptional(e => e.Materias)
                .HasForeignKey(e => e.id_materia);

            modelBuilder.Entity<notas>()
                .Property(e => e.nota)
                .HasPrecision(4, 2);

            modelBuilder.Entity<notas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Profesores>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Profesores>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Profesores>()
                .HasMany(e => e.notas)
                .WithOptional(e => e.Profesores)
                .HasForeignKey(e => e.id_prof);
        }
    }
}
