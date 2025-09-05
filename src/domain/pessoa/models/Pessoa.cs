using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiotminesttocs.src.domain.pessoa.models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}