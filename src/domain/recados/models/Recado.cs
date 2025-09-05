using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiotminesttocs.src.domain.pessoa.models;

namespace apiotminesttocs.src.domain.recados.models
{
    public class Recado
    {
        public int Id { get; set; }
        public string Texto { get; set; } = "";
        public Pessoa Sender { get; set; } = new Pessoa();
        public int SenderId { get; set; } = 0;
        public Pessoa Receiver { get; set; } = new Pessoa();
        public int ReceiverId { get; set; } = 0;
        public bool Lido { get; set; } = false;
        public DateTime Data { get; set; } = DateTime.Now;
    }
}