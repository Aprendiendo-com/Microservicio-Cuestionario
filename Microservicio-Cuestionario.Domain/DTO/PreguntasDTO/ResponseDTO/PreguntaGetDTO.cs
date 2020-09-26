using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.PreguntasDTO.ResponseDTO
{
    public class PreguntaGetDTO
    {
        public int PreguntaId { get; set; }
        public string Descripcion { get; set; }
        public int CuestionarioId { get; set; }
    }
}
