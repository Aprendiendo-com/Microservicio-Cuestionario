using Microservicio_Cuestionario.Domain.Command.BaseServices;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.PreguntasDTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Domain.Services
{
    public interface IPreguntaService : IService
    {
        List<PreguntaGetDTO> GetAll();
        PreguntaRespuestaDTO Add(PreguntaDTO preguntaDTO);
        void Delete(int id);
        void Edit(PreguntaUpdateDto preguntaUpdateDto);
    }
}
