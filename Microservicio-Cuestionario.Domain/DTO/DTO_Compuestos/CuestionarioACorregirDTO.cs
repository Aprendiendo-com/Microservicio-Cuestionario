using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.DTO_Compuestos
{
    public class CuestionarioACorregirDTO
    {
        public int CuestionarioId { get; set; }
        public List<RespuestaAlumnoDTO> Respuestas { get; set; }
    }
}
