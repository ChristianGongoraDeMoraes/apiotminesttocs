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
                Sender = dto.Sender,
                Receiver = dto.Receiver,
            };
        }
         public static Recado UpdateToEntity(this UpdateRecadoRequestDto dto)
        {
            return new Recado
            {
                Texto = dto.Texto,
                Sender = dto.Sender,
                Receiver = dto.Receiver,
                Lido = dto.Lido,
            };
        }
        public static SaveRecadoRequestDto ToSaveRecadoRequestDto(this Recado entity)
        {
            return new SaveRecadoRequestDto
            {
                Texto = entity.Texto,
                Sender = entity.Sender,
                Receiver = entity.Receiver
            };
        }
         public static UpdateRecadoRequestDto ToUpdateRecadoRequestDto(this Recado entity)
        {
            return new UpdateRecadoRequestDto
            {
                Texto = entity.Texto,
                Sender = entity.Sender,
                Receiver = entity.Receiver,
                Lido = entity.Lido
            };
        }
    }
}