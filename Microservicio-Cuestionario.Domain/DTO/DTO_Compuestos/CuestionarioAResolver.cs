using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.DTO_Compuestos
{
    public class CuestionarioAResolver
    {
        public int ClaseId { get; set; }

        public List<PreguntaConRespuestaAlumnoDTO> Preguntas { get; set; }
    }
}
