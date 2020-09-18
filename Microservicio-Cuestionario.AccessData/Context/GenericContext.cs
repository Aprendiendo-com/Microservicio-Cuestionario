﻿using System;
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

        }

        
    }
}
