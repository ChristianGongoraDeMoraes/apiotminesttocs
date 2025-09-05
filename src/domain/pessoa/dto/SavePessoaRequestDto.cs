using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiotminesttocs.src.domain.pessoa.dto
{
    public record SavePessoaRequestDto
    {
        [Required]
        public string Nome;
        [Required]
        public string PasswordHash;
        [Required]
        public string Email;
    }
}