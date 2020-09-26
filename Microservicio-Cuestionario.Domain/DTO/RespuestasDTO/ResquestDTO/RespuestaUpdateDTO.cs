using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResquestDTO
{
    public class RespuestaUpdateDTO
    {
        public int RespuestaId { get; set; }
        public string Descripcion { get; set; }
        public int PreguntaId { get; set; }
    }
}
