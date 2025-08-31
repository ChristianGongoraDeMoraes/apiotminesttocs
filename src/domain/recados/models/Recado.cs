using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiotminesttocs.src.domain.recados.models
{
    public class Recado
    {
        public int Id { get; set; }
        public string Texto { get; set; } = "";
        public string Sender { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public bool Lido { get; set; } = false;
        public DateTime Data { get; set; } = DateTime.Now;
    }
}