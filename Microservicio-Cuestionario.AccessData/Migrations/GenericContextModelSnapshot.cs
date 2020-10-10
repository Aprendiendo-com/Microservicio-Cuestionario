﻿// <auto-generated />
using Microservicio_Cuestionario.AccessData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Microservicio_Cuestionario.AccessData.Migrations
{
    [DbContext(typeof(GenericContext))]
    partial class GenericContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microservicio_Cuestionario.Domain.Entities.Cuestionario", b =>
                {
                    b.Property<int>("CuestionarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClaseId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("CuestionarioID");

                    b.ToTable("Cuestionarios");
                });

            modelBuilder.Entity("Microservicio_Cuestionario.Domain.Entities.Pregunta", b =>
                {
                    b.Property<int>("PreguntaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CuestionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("PreguntaId");

                    b.HasIndex("CuestionarioId");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("Microservicio_Cuestionario.Domain.Entities.Registro", b =>
                {
                    b.Property<int>("RegistroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Calificacion")
                        .HasColumnType("real");

                    b.Property<int>("CuestionarioId")
                        .HasColumnType("int");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.HasKey("RegistroId");

                    b.HasIndex("CuestionarioId");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("Microservicio_Cuestionario.Domain.Entities.Respuesta", b =>
                {
                    b.Property<int>("RespuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.HasKey("RespuestaId");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("Microservicio_Cuestionario.Domain.Entities.Pregunta", b =>
                {
                    b.HasOne("Microservicio_Cuestionario.Domain.Entities.Cuestionario", "CuestionarioNavegator")
                        .WithMany("PreguntaNavegator")
                        .HasForeignKey("CuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microservicio_Cuestionario.Domain.Entities.Registro", b =>
                {
                    b.HasOne("Microservicio_Cuestionario.Domain.Entities.Cuestionario", "Cuestionario")
                        .WithMany("Registros")
                        .HasForeignKey("CuestionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microservicio_Cuestionario.Domain.Entities.Respuesta", b =>
                {
                    b.HasOne("Microservicio_Cuestionario.Domain.Entities.Pregunta", "PreguntaNavegator")
                        .WithMany("RespuestaNavegator")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
