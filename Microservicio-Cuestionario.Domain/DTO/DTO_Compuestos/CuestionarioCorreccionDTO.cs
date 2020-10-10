using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.DTO_Compuestos
{
    public class CuestionarioCorreccionDTO
    {
        public double CalificacionTotal { get; set; }
        public List<RespuestaCompuestaDTO> Respuestas { get; set; } 
    }
}
