using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO
{
    public class PreguntaDTO
    {
        public string Descripcion { get; set; }
        public int CuestionarioId { get; set; }
    }
}
