﻿using System;
using System.Collections.Generic;
using System.Text;
using Microservicio_Cuestionario.Domain.Command.BaseServices;
using Microservicio_Cuestionario.Domain.DTO;
using Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResponseDTO;
using Microservicio_Cuestionario.Domain.DTO.RegistrosDTO.ResquestDTO;
using Microservicio_Cuestionario.Domain.Entities;

namespace Microservicio_Cuestionario.Domain.Services
{
    public interface IRegistroService : IService
    {
        //cuest respuesta

        RegistroRespuestaDTO AddRegistro(RegistroAddDTO registroDTO);
        RegistroRespuestaDTO AddRegistroConClase(RegistroRequestDTO registroAddDTO);

        List<RegistroDTO> GetAll();

        List<RegistroResponseDTO> GetAllConClase();

        //void DeleteRegistroById(int id);
        //void Update(RegistroDTO registroDTO);


    }
}
