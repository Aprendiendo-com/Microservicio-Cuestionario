using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Cuestionario.Domain.Command.BaseRepository;
using Microservicio_Cuestionario.Domain.DTO.CuestionariosDTO.DTORequest;
using Microservicio_Cuestionario.Domain.Entities;

namespace Microservicio_Cuestionario.Domain.Queries
{
    public interface ICuestionarioRepository : IRepository
    {
        public CuestionarioTodoDTO GetCuestionarioCompleto(Cuestionario c);
        public CuestionarioTodoDTO GetCuestionarioConRespuestasCorrectas(Cuestionario c);

    }
}
