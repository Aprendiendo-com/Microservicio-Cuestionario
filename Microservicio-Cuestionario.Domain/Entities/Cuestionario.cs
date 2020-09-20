using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.Entities
{
    public class Cuestionario
    {
        public int CuestionarioID { get; set; }
        public string Descripcion { get; set; }
        public float Calificacion { get; set; }

        public ICollection<Registro> Registros { get; set; }
        public ICollection<Pregunta> PreguntaNavegator { get; set; }
    }
}
