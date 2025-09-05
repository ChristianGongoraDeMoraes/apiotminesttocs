using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiotminesttocs.src.domain.pessoa.dto
{
    public class LoginRequestDto
    {
        [Required]
        public string Email;
        [Required]
        public string PasswordHash;
    }
}