using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResponseDTO
{
    public class RegistroResponseDTO
    {
        public int RegistroId { get; set; }
        public int EstudianteId { get; set; }
        public int CuestionarioId { get; set; }
        public int ClaseId { get; set; }
        public float Calificacion { get; set; }

    }
}
