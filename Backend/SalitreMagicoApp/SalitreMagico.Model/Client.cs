using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Model
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public int IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public float Heightclient { get; set;}
        public int ClienteAge { get; set;}
        public string EntryDate { get; set; }
    }
}
