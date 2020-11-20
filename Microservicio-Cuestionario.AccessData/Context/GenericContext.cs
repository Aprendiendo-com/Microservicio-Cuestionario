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

                entity.Property(q => q.ClaseId).IsRequired();
                entity.Property(q => q.Descripcion).HasMaxLength(250).IsRequired();





                entity.HasData(
                    new Cuestionario { CuestionarioID = 1, Descripcion = "Cuestionario de POO", ClaseId = 1 },
                    new Cuestionario { CuestionarioID = 2, Descripcion = "Cuestionario de Manejo de excepciones", ClaseId = 2 },
                    new Cuestionario { CuestionarioID = 3, Descripcion = "Cuestionario de Grafos", ClaseId = 3 },
                    new Cuestionario { CuestionarioID = 4, Descripcion = "Cuestionario de verbo to be", ClaseId = 4 },
                    new Cuestionario { CuestionarioID = 5, Descripcion = "Cuestionario de Presente Simple", ClaseId = 5 },
                    new Cuestionario { CuestionarioID = 6, Descripcion = "Completa las sentencias usando Presente Continuo", ClaseId = 6 },
                    new Cuestionario { CuestionarioID = 7, Descripcion = "Cuestionario de Campo eléctrico", ClaseId = 7 },
                    new Cuestionario { CuestionarioID = 8, Descripcion = "Cuestinario de Campo Magnético", ClaseId = 8 },
                    new Cuestionario { CuestionarioID = 9, Descripcion = "Cuestionario de Ecuaciones de Maxwell", ClaseId = 9 }
                    );

            }
            );
            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasKey(q => q.RegistroId);
                entity.Property(q => q.EstudianteId).IsRequired();
                entity.Property(q => q.Calificacion).IsRequired();


                entity.HasOne(q => q.Cuestionario)
                .WithMany(q => q.Registros)
                .HasForeignKey(q => q.CuestionarioId);
            }
            );

            modelBuilder.Entity<Pregunta>(entity =>
            {
                
                entity.HasKey(q => q.PreguntaId );

                entity.Property(q => q.Descripcion).HasMaxLength(250).IsRequired();
                entity.Property(q => q.CalificacionParcial).IsRequired();

                entity.HasOne(q => q.CuestionarioNavegator)
                .WithMany(q => q.PreguntaNavegator)
                .HasForeignKey(q => q.CuestionarioId);




                entity.HasData(
                    new Pregunta { PreguntaId = 1, Descripcion = "¿Que es la Encapsulación?", CuestionarioId = 1 , CalificacionParcial = 3},
                    new Pregunta { PreguntaId = 2, Descripcion = "¿Que son las Interfaces?", CuestionarioId = 1, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 3, Descripcion = "¿Que es Sobrecarga?", CuestionarioId = 1, CalificacionParcial = 4 },

                    new Pregunta { PreguntaId = 4, Descripcion = "¿Qué es una excepción?", CuestionarioId = 2, CalificacionParcial = 2 },
                    new Pregunta { PreguntaId = 5, Descripcion = "Un programador, ¿puede disparar sus propias excepciones?", CuestionarioId = 2, CalificacionParcial = 4},
                    new Pregunta { PreguntaId = 6, Descripcion = "¿Qué se define dentro del finally?", CuestionarioId = 2, CalificacionParcial = 2 },
                    new Pregunta { PreguntaId = 7, Descripcion = "¿Qué se puede hacer con la sentencia trow?", CuestionarioId = 2, CalificacionParcial = 2 },

                    new Pregunta { PreguntaId = 8, Descripcion = "Según la definición de Grafos, indice cual opción define mejor el concepto de trayectoria de un vértice v0 a vn.", CuestionarioId = 3, CalificacionParcial = 4 },
                    new Pregunta { PreguntaId = 9, Descripcion = "Indique la definición correcta de Grafo.", CuestionarioId = 3, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 10, Descripcion = "¿Cuál es el algoritmo que resuelve el problema del camino mínimo?", CuestionarioId = 3, CalificacionParcial = 3 },

                    new Pregunta { PreguntaId = 11, Descripcion = "Complete: ___________ in the office?", CuestionarioId = 4, CalificacionParcial = 4 },
                    new Pregunta { PreguntaId = 12, Descripcion = "Complete: _______ the books on the shelf?", CuestionarioId = 4, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 13, Descripcion = "Complete: I ____ not ready.", CuestionarioId = 4, CalificacionParcial = 3 },
                    
                    new Pregunta { PreguntaId = 14, Descripcion = "Complete: She ______ (wash) her car every week? ", CuestionarioId = 5, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 15, Descripcion = "Complete: Paul _______ (sleep) seven hours a day.", CuestionarioId = 5, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 16, Descripcion = "Complete: Who _____ (be) your favourite football player? ", CuestionarioId = 5, CalificacionParcial = 4 },

                    new Pregunta { PreguntaId = 17, Descripcion = "Complete: She _________ (leave) tomorrow morning.", CuestionarioId = 6, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 18, Descripcion = "Complete: You _______ (make) a great effort.", CuestionarioId = 6, CalificacionParcial = 4 },
                    new Pregunta { PreguntaId = 19, Descripcion = "Complete: I _______ (watch) TV right now.", CuestionarioId = 6, CalificacionParcial = 3 },

                    new Pregunta { PreguntaId = 20, Descripcion = "El campo eléctrico es:", CuestionarioId = 7, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 21, Descripcion = "¿Qué es un solenoide?", CuestionarioId = 7, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 22, Descripcion = "¿Qué es un electroimán?", CuestionarioId = 7, CalificacionParcial = 4 },

                    new Pregunta { PreguntaId = 23, Descripcion = "¿Qué es la Coercitividad?", CuestionarioId = 8, CalificacionParcial = 4 },
                    new Pregunta { PreguntaId = 24, Descripcion = "¿Qué es la Remanencia?", CuestionarioId = 8, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 25, Descripcion = "El vacío, ¿Tiene Coercitividad?", CuestionarioId = 8, CalificacionParcial = 3 },

                    new Pregunta { PreguntaId = 26, Descripcion = "¿A qué se conoce como ecuaciones de Maxwell?.", CuestionarioId = 9, CalificacionParcial = 4 },
                    new Pregunta { PreguntaId = 27, Descripcion = "¿Cuál de los siguientes parámetros no interviene en las ecuaciones de Maxwell?", CuestionarioId = 9, CalificacionParcial = 3 },
                    new Pregunta { PreguntaId = 28, Descripcion = "¿Qué sucede con el valor del Flujo si duplicamos el valor de la carga?", CuestionarioId = 9, CalificacionParcial = 3 }


                    );
            }
            );

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.HasKey(q => q.RespuestaId);

                entity.Property(q => q.Descripcion).HasMaxLength(250).IsRequired();
                entity.Property(q => q.PreguntaId).IsRequired();
                entity.Property(q => q.Flag).IsRequired();

                entity.HasOne(q => q.PreguntaNavegator)
                .WithMany(q => q.RespuestaNavegator)
                .HasForeignKey(q => q.PreguntaId);




                entity.HasData(
                    new Respuesta { RespuestaId = 1, Descripcion = "Es la capacidad que tienen los objetos de comportarse de múltiples formas recurriendo a la herencia.", PreguntaId = 1, Flag = false },
                    new Respuesta { RespuestaId = 2, Descripcion = "Es la forma de proteger u ocultar las propiedades de un objetos, estableciendo los permisos y niveles de visibilidad.", PreguntaId = 1, Flag = true },
                    new Respuesta { RespuestaId = 3, Descripcion = "Es un evento que ocurre durante la ejecucion del programa, interrumpiendo el flujo normal.", PreguntaId = 1, Flag = false },
                    new Respuesta { RespuestaId = 4, Descripcion = "Las interfaces definen lo que una clase que la implemente debe hacer.", PreguntaId = 2, Flag = true },
                    new Respuesta { RespuestaId = 5, Descripcion = "Es la capacidad que tienen los objetos de comportarse de múltiples formas recurriendo a la herencia.", PreguntaId = 2, Flag = false },
                    new Respuesta { RespuestaId = 6, Descripcion = "Es la base de la reutilización del código, obteniendo la información de sus superclases.", PreguntaId = 2, Flag = false },
                    new Respuesta { RespuestaId = 7, Descripcion = "Consiste en tener dos o más métodos con distinto nombre pero los mismos parámetros.", PreguntaId = 3, Flag = false },
                    new Respuesta { RespuestaId = 8, Descripcion = "Consiste en tener dos o más métodos con el mismo nombre pero diferentes parámetros.", PreguntaId = 3, Flag = true },

                    new Respuesta { RespuestaId = 9, Descripcion = "Es un evento que ocurre durante la ejecución de un programa y que provoca que los ciclos no puedan terminarse.", PreguntaId = 4, Flag = false },
                    new Respuesta { RespuestaId = 10, Descripcion = "Es un evento que ocurre durante la ejecución de un programa y que interrumpe el flujo normal de operación.", PreguntaId = 4, Flag = true },
                    new Respuesta { RespuestaId = 11, Descripcion = "No.", PreguntaId = 5, Flag = false },
                    new Respuesta { RespuestaId = 12, Descripcion = "Sí.", PreguntaId = 5, Flag = true },
                    new Respuesta { RespuestaId = 13, Descripcion = "El código que se ejecuta cuando haya excepciones.", PreguntaId = 6, Flag = false },
                    new Respuesta { RespuestaId = 14, Descripcion = "El código que se ejecutará haya o no excepciones.", PreguntaId = 6, Flag = true },
                    new Respuesta { RespuestaId = 15, Descripcion = "El código que captura y maneja el código que se lance la excepción.", PreguntaId = 6, Flag = false },
                    new Respuesta { RespuestaId = 16, Descripcion = "Se puede identificar un error al cual posteriormente aplicar una excepción.", PreguntaId = 7, Flag = false },
                    new Respuesta { RespuestaId = 17, Descripcion = "Se puede utilizar para disparar una excepción.", PreguntaId = 7, Flag = true },
                    new Respuesta { RespuestaId = 18, Descripcion = "Se puede utilizar para señalar un código y no lanzar una excepción si este tiene problemas.", PreguntaId = 7, Flag = false },

                    new Respuesta { RespuestaId = 19, Descripcion = "Un camino consecutivo de aristas consecutivas desde v0 hasta vn.", PreguntaId = 8, Flag = false },
                    new Respuesta { RespuestaId = 20, Descripcion = "Es un camino de nodos alternantes desde v0 hasta vn.", PreguntaId = 8, Flag = false },
                    new Respuesta { RespuestaId = 21, Descripcion = "Es una sucesión de longitud n, alternante de n+1 vértices y n aristas que comienza en v0 y termina en vn.", PreguntaId = 8, Flag = true },
                    new Respuesta { RespuestaId = 22, Descripcion = "Es un conjunto de n-1 nodos alternantes y consecutivos desde v0 hasta vn.", PreguntaId = 8, Flag = false },
                    new Respuesta { RespuestaId = 23, Descripcion = "Un conjunto de vértices y aristas, tal que cada arista está asociada a un par.", PreguntaId = 9, Flag = true },
                    new Respuesta { RespuestaId = 24, Descripcion = "Un diagrama compuesto de nodos y conexiones.", PreguntaId = 9, Flag = false },
                    new Respuesta { RespuestaId = 25, Descripcion = "Un gráfico matemático que se emplea para modelar problemas de la vida real.", PreguntaId = 9, Flag = false },
                    new Respuesta { RespuestaId = 26, Descripcion = "Múltiples nodos denominados vértices y caminos denominados marcos.", PreguntaId = 9, Flag = false },
                    new Respuesta { RespuestaId = 27, Descripcion = "El algoritmo de VanVourer.", PreguntaId = 10, Flag = false },
                    new Respuesta { RespuestaId = 28, Descripcion = "El algoritmo de Dijkstra.", PreguntaId = 10, Flag = true },
                    new Respuesta { RespuestaId = 29, Descripcion = "El algoritmo de Gauss.", PreguntaId = 10, Flag = false },



                    new Respuesta { RespuestaId = 30, Descripcion = "When is", PreguntaId = 11, Flag = true },
                    new Respuesta { RespuestaId = 31, Descripcion = "Who is", PreguntaId = 11, Flag = false },
                    new Respuesta { RespuestaId = 32, Descripcion = "Where is", PreguntaId = 11, Flag = false },
                    new Respuesta { RespuestaId = 33, Descripcion = "Isn't", PreguntaId = 12, Flag = false },
                    new Respuesta { RespuestaId = 34, Descripcion = "Are", PreguntaId = 12, Flag = true },
                    new Respuesta { RespuestaId = 35, Descripcion = "Was", PreguntaId = 12, Flag = false },
                    new Respuesta { RespuestaId = 36, Descripcion = "am", PreguntaId = 13, Flag = true },
                    new Respuesta { RespuestaId = 37, Descripcion = "is not", PreguntaId = 13, Flag = false },
                    new Respuesta { RespuestaId = 38, Descripcion = "where", PreguntaId = 13, Flag = false },
                    new Respuesta { RespuestaId = 39, Descripcion = "are", PreguntaId = 13, Flag = false },

                    new Respuesta { RespuestaId = 40, Descripcion = "washies", PreguntaId = 14, Flag = false },
                    new Respuesta { RespuestaId = 41, Descripcion = "washes", PreguntaId = 14, Flag = true },
                    new Respuesta { RespuestaId = 42, Descripcion = "washs", PreguntaId = 14, Flag = false },
                    new Respuesta { RespuestaId = 43, Descripcion = "sleep", PreguntaId = 15, Flag = false },
                    new Respuesta { RespuestaId = 44, Descripcion = "sleeps", PreguntaId = 15, Flag = true },
                    new Respuesta { RespuestaId = 45, Descripcion = "sleepes", PreguntaId = 15, Flag = false },
                    new Respuesta { RespuestaId = 46, Descripcion = "am", PreguntaId = 16, Flag = false },
                    new Respuesta { RespuestaId = 47, Descripcion = "are", PreguntaId = 16, Flag = false },
                    new Respuesta { RespuestaId = 48, Descripcion = "is", PreguntaId = 16, Flag = true },

                    new Respuesta { RespuestaId = 49, Descripcion = "leaving", PreguntaId = 17, Flag = false },
                    new Respuesta { RespuestaId = 50, Descripcion = "is leaving", PreguntaId = 17, Flag = true },
                    new Respuesta { RespuestaId = 51, Descripcion = "leaved", PreguntaId = 17, Flag = false },
                    new Respuesta { RespuestaId = 52, Descripcion = "are making", PreguntaId = 18, Flag = false },
                    new Respuesta { RespuestaId = 53, Descripcion = "is making", PreguntaId = 18, Flag = true },
                    new Respuesta { RespuestaId = 54, Descripcion = "is make", PreguntaId = 18, Flag = false },
                    new Respuesta { RespuestaId = 55, Descripcion = "do watching", PreguntaId = 19, Flag = false },
                    new Respuesta { RespuestaId = 56, Descripcion = "are watching", PreguntaId = 19, Flag = false },
                    new Respuesta { RespuestaId = 57, Descripcion = "am watching", PreguntaId = 19, Flag = true },



                    new Respuesta { RespuestaId = 58, Descripcion = "Es una cantidad escalar muy fácil de calcular.", PreguntaId = 20, Flag = false },
                    new Respuesta { RespuestaId = 59, Descripcion = "Se define como la fuerza por unidad de carga en un punto dado.", PreguntaId = 20, Flag = false },
                    new Respuesta { RespuestaId = 60, Descripcion = "Es un campo vectorial y sus unidades son newtons/coulombs.", PreguntaId = 20, Flag = true },
                    new Respuesta { RespuestaId = 61, Descripcion = "Es un concepto de poca utilidad en electrostática.", PreguntaId = 21, Flag = false },
                    new Respuesta { RespuestaId = 62, Descripcion = "Es un conjunto de espiras conectadas eléctricamente, a la manera de un resorte comprimido.", PreguntaId = 21, Flag = true },
                    new Respuesta { RespuestaId = 63, Descripcion = "Es un “anillo” conductor por el que circula la corriente eléctrica.", PreguntaId = 21, Flag = false },
                    new Respuesta { RespuestaId = 64, Descripcion = "Es una línea de campo eléctrico siempre paralela a la superficies. ", PreguntaId = 22, Flag = false },
                    new Respuesta { RespuestaId = 65, Descripcion = "Es un campo físico que se representa por medio de un modelo que describe la interacción entre cuerpos.", PreguntaId = 22, Flag = false },
                    new Respuesta { RespuestaId = 66, Descripcion = "Es un imán no permanente cuya acción dura mientras se produce el pasaje de la corriente por el solenoide.", PreguntaId = 22, Flag = true },

                    new Respuesta { RespuestaId = 67, Descripcion = "Es el equivalente de la resistencia en los circuitos eléctricos.", PreguntaId = 23, Flag = false },
                    new Respuesta { RespuestaId = 68, Descripcion = "Es el equivalente de la resistencia en los circuitos magnéticos.", PreguntaId = 23, Flag = false },
                    new Respuesta { RespuestaId = 69, Descripcion = "Es la facilidad con que un material inducido, adquiere las propiedades del material inductor. En definitiva es la facilidad que tiene una sustancia de magnetizarse.", PreguntaId = 23, Flag = true },
                    new Respuesta { RespuestaId = 70, Descripcion = "Cuestinario de Campo Magnético.", PreguntaId = 24, Flag = false },
                    new Respuesta { RespuestaId = 71, Descripcion = "Es el tiempo que dura magnetizada una sustancia.", PreguntaId = 24, Flag = true },
                    new Respuesta { RespuestaId = 72, Descripcion = "Es el valor de la temperatura en el que la sustancia pierde su propiedad Ferromagnética.", PreguntaId = 24, Flag = false },
                    new Respuesta { RespuestaId = 73, Descripcion = "Sí", PreguntaId = 25, Flag = false },
                    new Respuesta { RespuestaId = 74, Descripcion = "No.", PreguntaId = 25, Flag = true },
                    new Respuesta { RespuestaId = 75, Descripcion = "A veces.", PreguntaId = 25, Flag = false },

                    new Respuesta { RespuestaId = 76, Descripcion = "Al conjunto de ecuaciones que describen todos los fenómenos eléctricos.", PreguntaId = 26, Flag = false },
                    new Respuesta { RespuestaId = 77, Descripcion = "Al conjunto fundamental de ecuaciones que describen todos los fenómenos electromagnéticos.", PreguntaId = 26, Flag = true },
                    new Respuesta { RespuestaId = 78, Descripcion = "Al conjunto de ecuaciones que describen todos los fenómenos magnéticos.", PreguntaId = 26, Flag = false },
                    new Respuesta { RespuestaId = 79, Descripcion = "El campo gravitatorio.", PreguntaId = 27, Flag = true },
                    new Respuesta { RespuestaId = 80, Descripcion = "El campo magnético.", PreguntaId = 27, Flag = false },
                    new Respuesta { RespuestaId = 81, Descripcion = "El campo eléctrico.", PreguntaId = 27, Flag = false },
                    new Respuesta { RespuestaId = 82, Descripcion = "Se anula.", PreguntaId = 28, Flag = false },
                    new Respuesta { RespuestaId = 83, Descripcion = "Se duplica.", PreguntaId = 28, Flag = true },
                    new Respuesta { RespuestaId = 84, Descripcion = "Se reduce a la mitad.", PreguntaId = 28, Flag = false }

                    );
            }
            );

        }

        
    }
}
