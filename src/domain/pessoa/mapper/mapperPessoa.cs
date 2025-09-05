using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.pessoa.dto;
using apiotminesttocs.src.domain.pessoa.models;
using apiotminesttocs.src.infra;
using Microsoft.AspNetCore.Identity;

namespace apiotminesttocs.src.domain.pessoa.mapper
{
    public static class mapperPessoa
    {

        public static Pessoa SaveToEntity(this SavePessoaRequestDto dto)
        {
            return new Pessoa
            {
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = ConfigHash.GetStringSha256Hash(dto.PasswordHash),
            };
        }   

        public static Pessoa UpdateToEntity(this UpdatePessoaRequestDto dto)
        {
            return new Pessoa
            {
                Nome = dto.Nome,
                Email = dto.Email,
            };
        }   
    }
}