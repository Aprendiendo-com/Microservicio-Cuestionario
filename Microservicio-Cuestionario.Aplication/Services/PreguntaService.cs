using AutoMapper;
using Microservicio_Cuestionario.Aplication.Services.Base;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.PreguntasDTO.ResponseDTO;
using Microservicio_Cuestionario.Domain.Entities;
using Microservicio_Cuestionario.Domain.Queries;
using Microservicio_Cuestionario.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservicio_Cuestionario.Aplication.Services
{
    public class PreguntaService : GenericService , IPreguntaService
    {
        public PreguntaService( IPreguntaRepository repository, IMapper mapper) :base(repository, mapper)
        {

        }

        public PreguntaRespuestaDTO Add(PreguntaDTO preguntaDTO)
        {
            var pregunta = this._mapper.Map<Pregunta>(preguntaDTO);

            var preguntaDb = this.Repository.Add(pregunta);

            return this._mapper.Map<PreguntaRespuestaDTO>(preguntaDb);
        }

        public void Delete(int id)
        {
            this.Repository.DeleteBy<Pregunta>(id);
        }

        public void Edit(PreguntaUpdateDto preguntaUpdateDto)
        {
            var pregunta = this._mapper.Map<Pregunta>(preguntaUpdateDto);

            this.Repository.Update(pregunta);
        }

        public List<PreguntaGetDTO> GetAll()
        {
            var list = this.Repository.Traer<Pregunta>();

            var listDto = this._mapper.Map<List<PreguntaGetDTO>>(list);

            return listDto;
        }
    }
}
