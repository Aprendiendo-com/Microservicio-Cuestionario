using Microservicio_Cuestionario.Domain.Command.BaseServices;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResponseDTO;
using Microservicio_Cuestionario.Domain.DTO.RespuestasDTO.ResquestDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.Services
{
    public interface IRepuestaService : IService
    {
        List<RespuestaGetDTO> GetAll();
        RespuestaAddDTO Add(RepuestaDTO repuestaDTO);
        void Edit(RespuestaUpdateDTO respuestaUpdateDTO);
    }
}
