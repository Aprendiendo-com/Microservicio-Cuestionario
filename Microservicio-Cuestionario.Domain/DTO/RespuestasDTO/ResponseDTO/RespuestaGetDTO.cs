using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResponseDTO
{
    public class RespuestaGetDTO
    {
        public bool Flag { get; set; }
        public int RespuestaId { get; set; }
        public string Descripcion { get; set; }
        public int PreguntaId { get; set; }
    }
}
