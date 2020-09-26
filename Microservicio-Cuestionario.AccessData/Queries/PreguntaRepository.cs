using Microservicio_Cuestionario.AccessData.Command;
using Microservicio_Cuestionario.AccessData.Context;
using Microservicio_Cuestionario.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.AccessData.Queries
{
    public class PreguntaRepository : GenericRepository, IPreguntaRepository
    {
        public PreguntaRepository(GenericContext contexto) : base(contexto)
        {

        }
    }
}
