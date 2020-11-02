using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResquestDTO
{
    public class RegistroRequestDTO
    {
        public int EstudianteId { get; set; }
        public int ClaseId { get; set; }
        public float Calificacion { get; set; }
    }
}
