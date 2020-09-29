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
        public float Calificacion { get; set; }
        public List<PreguntaConRespuestaDTO> PreguntaNavegator { get; set; }
    }
}
