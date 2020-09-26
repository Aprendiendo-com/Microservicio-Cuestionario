using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO
{
    public class PreguntaUpdateDto
    {
        public int PreguntaId { get; set; }
        public string Descripcion { get; set; }
        public int CuestionarioId { get; set; }
    }
}
