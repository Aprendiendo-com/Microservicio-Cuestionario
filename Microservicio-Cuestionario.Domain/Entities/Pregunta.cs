using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.Entities
{
    public class Pregunta
    {
        public int PreguntaId { get; set; }
        public string  Descripcion { get; set; }
        public int CuestionarioId { get; set; }

        public Cuestionario CuestionarioNavegator { get; set; }
        public Respuesta RespuestaNavegator { get; set; }
    }
}
