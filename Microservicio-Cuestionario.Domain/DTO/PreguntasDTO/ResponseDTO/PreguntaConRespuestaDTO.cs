using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResquestDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.PreguntasDTO.ResponseDTO
{
    public class PreguntaConRespuestaDTO
    {
        public string Descripcion { get; set; }
        public List<RespuestaDescripcionDTO>  Respuestas { get; set; }
    }
}
