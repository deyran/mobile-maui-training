using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaApp.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
