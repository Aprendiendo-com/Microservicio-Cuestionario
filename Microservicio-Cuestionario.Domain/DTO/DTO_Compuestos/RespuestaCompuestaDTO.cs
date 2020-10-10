using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.DTO_Compuestos
{
    public class RespuestaCompuestaDTO
    {
        public string RespuestaAlumno { get; set; }
        public string RespuestaCorrecta {get; set;}
        public double CalificacionParcial { get; set; }
    }
}
