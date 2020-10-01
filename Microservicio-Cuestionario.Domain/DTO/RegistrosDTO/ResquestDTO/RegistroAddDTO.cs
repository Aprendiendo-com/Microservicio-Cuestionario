using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResquestDTO
{
    public class RegistroAddDTO
    {
        public int EstudianteId { get; set; }
        public int CuestionarioId { get; set; }
        public float Calificacion { get; set; }
    }
}
