using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Cuestionario.AccessData.Command;
using Microservicio_Cuestionario.AccessData.Context;
using Microservicio_Cuestionario.Domain.Queries;

namespace Microservicio_Cuestionario.AccessData.Queries
{
    class CuestionarioRepository : GenericRepository, ICuestionarioRepository
    {
        public CuestionarioRepository(GenericContext contexto) : base(contexto)
        {
        }
    }
}
