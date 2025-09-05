using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.recados.dto;
using apiotminesttocs.src.domain.recados.models;

namespace apiotminesttocs.src.domain.recados.mapper
{
    public static class mapperRecados
    {
        public static Recado SaveToEntity(this SaveRecadoRequestDto dto)
        {
            return new Recado
            {
                Texto = dto.Texto,
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
            };
        }
         public static Recado UpdateToEntity(this UpdateRecadoRequestDto dto)
        {
            return new Recado
            {
                Texto = dto.Texto,
                Lido = dto.Lido,
            };
        }
        public static SaveRecadoRequestDto ToSaveRecadoRequestDto(this Recado entity)
        {
            return new SaveRecadoRequestDto
            {
                Texto = entity.Texto,
                SenderId = entity.SenderId,
                ReceiverId = entity.ReceiverId,
            };
        }
    }
}