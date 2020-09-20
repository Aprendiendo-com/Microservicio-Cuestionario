using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.Entities
{
    public class Respuesta
    {
        public int RespuestaId { get; set; }
        public string Descripcion { get; set; }
        public int PreguntaId { get; set; }

        public Pregunta PreguntaNavegator { get; set; }
    }
}
