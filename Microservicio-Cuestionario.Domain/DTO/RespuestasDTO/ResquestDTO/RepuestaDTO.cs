using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO
{
    public class RepuestaDTO
    {
        public int PreguntaId { get; set; }
        public string Descripcion { get; set; }
    }
}
