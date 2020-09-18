using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Cuestionario.Aplication.Services.Base;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microservicio_Cuestionario.Domain.Services;

namespace Microservicio_Cuestionario.Aplication.Services
{
    public class CuestionarioService : GenericService, ICuestionarioService
    {
        public CuestionarioService(ICuestionarioRepository repository):base(repository)
        {

        }

        public CuestionarioRespuestaDTO AddCuestionario(CuestionarioDTO cuestionarioDTO)
        {
            var cuestionario = new Domain.Entities.Cuestionario()
            {
                Descripcion = cuestionarioDTO.Descripcion,
                Calificacion = cuestionarioDTO.Calificacion
            };

            var respuesta = Repository.Add(cuestionario);

            return new CuestionarioRespuestaDTO() { CuestionarioID = respuesta.CuestionarioID };
        }

        public List<CuestionarioDTO> GetAll()
        {
            var cuestionarios = this.Repository.Traer<Domain.Entities.Cuestionario>();

            var cuestionariosDTO = new List<CuestionarioDTO>();

            foreach (var c in cuestionarios)
            {
                var dto = new CuestionarioDTO()
                {
                    Descripcion = c.Descripcion,
                    Calificacion = c.Calificacion
                };

                cuestionariosDTO.Add(dto);
            }
            return cuestionariosDTO;
        }

        public void Update(CuestionarioDTO cuestionarioDTO)
        {
            var cuestionario = new Domain.Entities.Cuestionario()
            {
                Calificacion = cuestionarioDTO.Calificacion,
                Descripcion = cuestionarioDTO.Descripcion
            };
            this.Repository.Update(cuestionario);
        }
    }
}
