using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.DTO_Compuestos
{
    public class PreguntaConRespuestaAlumnoDTO
    {
        public string Descripcion { get; set; }
        public double CalificacionParcial { get; set; }
        public RespuestaAlumnoDTO Respuesta { get; set; }
    }
}
