using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiotminesttocs.src.domain.recados.dto
{
    public record SaveRecadoRequestDto
    {
        [Required]
        public string Texto;
        [Required]
        public string Sender;
        [Required]
        public string Receiver;
    }
}