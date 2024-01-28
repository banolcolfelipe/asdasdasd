using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Model
{
    public class ContactChildren
    {
        public int ContactId { get; set; }
        public string RelationshipContact { get; set; }
        public string ContactName { get; set; }
        public int PhoneContact { get; set; }
        public int ClientId { get; set; }
    }
}
