using Microservicio_Cuestionario.AccessData.Command;
using Microservicio_Cuestionario.AccessData.Context;
using Microservicio_Cuestionario.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.AccessData.Queries
{
    public class RepuestaRepository  : GenericRepository, IRespuestaRepository
    {
        public RepuestaRepository(GenericContext context): base(context)
        {

        }
    }
}
