﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.DTO
{
    public class CuestionarioUpdateDTO
    {
        public int CuestionarioID { get; set; }
        public string Descripcion { get; set; }
        public float Calificacion { get; set; }
    }
}
