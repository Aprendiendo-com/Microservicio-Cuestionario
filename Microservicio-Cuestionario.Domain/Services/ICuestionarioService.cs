using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Cuestionario.Domain.Command.BaseServices;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.Entities;

namespace Microservicio_Cuestionario.Domain.Services
{
    public interface ICuestionarioService : IService
    {
        CuestionarioRespuestaDTO AddCuestionario(CuestionarioDTO cuestionarioDTO);
        List<CuestionarioDTO> GetAll();
        void Update(CuestionarioDTO cuestionarioDTO);


        //Modificado
        void DeleteCuestionario(CuestionarioDTO cuestionarioDTO);
        CuestionarioDTO FindCuestionarioById(int id);
        void DeleteCuestionarioById(int id);

    }
}
