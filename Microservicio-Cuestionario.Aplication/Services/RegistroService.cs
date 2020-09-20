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
    public class RegistroService : GenericService, IRegistroService
    {
        public RegistroService(IRegistroRepository repository) : base(repository)
        {

        }

        public RegistroRespuestaDTO AddRegistro(RegistroDTO registroDTO)
        {
            var registro = new Domain.Entities.Registro()
            {
                EstudianteId = registroDTO.EstudianteId,
                CuestionarioId = registroDTO.CuestionarioId
            };

            var respuesta = Repository.Add(registro);

            return new RegistroRespuestaDTO() { RegistroId = respuesta.RegistroId };
        }
        public List<RegistroDTO> GetAll()
        {
            var registros = this.Repository.Traer<Domain.Entities.Registro>();

            var registrosDTO = new List<RegistroDTO>();

            foreach (var reg in registros)
            {
                var dto = new RegistroDTO()
                {
                    EstudianteId = reg.EstudianteId,
                    CuestionarioId = reg.CuestionarioId
                };

                registrosDTO.Add(dto);
            }
            return registrosDTO;
        }

        public void Update(RegistroDTO registroDTO)
        {
            var registro = new Domain.Entities.Registro()
            {
                EstudianteId = registroDTO.EstudianteId,
                CuestionarioId = registroDTO.CuestionarioId
            };
            this.Repository.Update(registro);
        }

        public void DeleteRegistroById(int id)
        {
            var registros = this.Repository.Traer<Domain.Entities.Registro>();

            foreach (var registro in registros)
            {
                if (registro.RegistroId == id)
                {
                    this.Repository.Delete(registro);
                }
            }
        }
    }
}
