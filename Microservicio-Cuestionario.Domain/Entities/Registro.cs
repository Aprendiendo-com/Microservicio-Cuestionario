using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.Entities
{
    public class Registro
    {
        public int RegistroId { get; set; }
        public int EstudianteId { get; set; }
        public int CuestionarioId { get; set; }

        public Cuestionario Cuestionario { get; set; }
    }
}
