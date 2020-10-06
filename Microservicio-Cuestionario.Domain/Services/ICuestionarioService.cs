using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Cuestionario.Domain.Command.BaseServices;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.CuestionariosDTO;
using Microservicio_Cuestionario.Domain.DTO.CuestionariosDTO.DTORequest;
using Microservicio_Cuestionario.Domain.DTO.DTOResponse;
using Microservicio_Cuestionario.Domain.Entities;

namespace Microservicio_Cuestionario.Domain.Services
{
    public interface ICuestionarioService : IService
    {
        CuestionarioRespuestaDTO AddCuestionario(CuestionarioDTO cuestionarioDTO);
        CuestionarioRespuestaDTO AddCuestionario(CuestionarioTodoDTO cuestionarioTodoDTO);

        List<CuestionarioGetDTO> GetAll();
        void Update(CuestionarioUpdateDTO cuestionarioUpdateDTO);

        List<CuestionarioTodoDTO> GetCompleto();
        List<CuestionarioTodoDTO> GetCompletoConRespuestasCorrectas();


        //Modificado
        void DeleteCuestionario(CuestionarioDTO cuestionarioDTO);
        CuestionarioDTO FindCuestionarioById(int id);
        void DeleteCuestionarioById(int id);

    }
}
