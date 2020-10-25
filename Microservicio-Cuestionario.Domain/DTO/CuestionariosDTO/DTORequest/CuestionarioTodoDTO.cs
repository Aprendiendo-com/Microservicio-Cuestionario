using Microservicio_Cuestionario.Domain.DTO.PreguntasDTO;
using Microservicio_Cuestionario.Domain.DTO.PreguntasDTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.CuestionariosDTO.DTORequest
{
    public class CuestionarioTodoDTO
    {
        public string Descripcion { get; set; }
        public int ClaseId { get; set; }
        public List<PreguntaConRespuestaDTO> Preguntas{ get; set; }
    }
}
