using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microservicio_Cuestionario.AccessData.Command;
using Microservicio_Cuestionario.AccessData.Context;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace Microservicio_Cuestionario.AccessData.Queries
{
    public class CuestionarioRepository : GenericRepository, ICuestionarioRepository
    {
        public CuestionarioRepository(GenericContext contexto) : base(contexto)
        {
        }

        public List<Respuesta> RespuestasCorrectas(int id)
        {
            var preguntas = this.Context.Preguntas.Include("RespuestaNavegator");

            var queryRespuestasCorrectas = preguntas.Where(x => x.CuestionarioId == id)
                .Select(x => x.RespuestaNavegator.Where(x => x.Flag == true).FirstOrDefault()).ToList();

            return queryRespuestasCorrectas;
        }
    }
}
