using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Cuestionario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservicio_Cuestionario.AccessData.Context
{
    public class GenericContext : DbContext
    {
        public virtual DbSet<Cuestionario> Cuestionarios { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<Pregunta> Preguntas { get; set; }
        public virtual DbSet<Respuesta> Respuestas { get; set; }

        public GenericContext() { }


        public GenericContext (DbContextOptions<GenericContext> options): base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database = MicroCuestionario ; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuestionario>(entity =>
            {
                entity.HasKey(q => q.CuestionarioID);

                entity.Property(q => q.Descripcion).HasMaxLength(250).IsRequired();
                entity.Property(q => q.Calificacion).IsRequired();

            }
            );
            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasKey(q => q.RegistroId);
                entity.Property(q => q.EstudianteId).IsRequired();


                entity.HasOne(q => q.Cuestionario)
                .WithMany(q => q.Registros)
                .HasForeignKey(q => q.CuestionarioId);
            }
            );

            modelBuilder.Entity<Pregunta>(entity =>
            {
                //entity.HasKey(q => new { q.PreguntaId, q.CuestionarioId}); // pk compuesta
                //entity.HasKey(q => q.CuestionarioId);
                entity.HasKey(q => q.PreguntaId );

                entity.Property(q => q.Descripcion).HasMaxLength(250).IsRequired();

                entity.HasOne(q => q.CuestionarioNavegator)
                .WithMany(q => q.PreguntaNavegator)
                .HasForeignKey(q => q.CuestionarioId);

                entity.HasOne(q => q.RespuestaNavegator)
                .WithOne(q => q.PreguntaNavegator)
                .HasForeignKey<Respuesta>(b => b.PreguntaId);

            }
            );

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.HasKey(q => q.RespuestaId);

                entity.Property(q => q.Descripcion).HasMaxLength(250).IsRequired();
                entity.Property(q => q.PreguntaId).IsRequired();

                //entity.HasOne(q => q.PreguntaNavegator)
                //.WithOne(q => q.RespuestaNavegator).HasForeignKey<Respuesta>(q => q.PreguntaId);

            }
            );

        }

        
    }
}
