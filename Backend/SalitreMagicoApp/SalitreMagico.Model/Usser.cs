using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Model
{
    public class Usser
    {
        public int IdUsser { get; set; }
        public string UsserName { get; set; }
        public string Password { get; set; }

        public Boolean IsActiveUsser { get; set; }
        public int IdEmployed { get; set; }

    }
}
