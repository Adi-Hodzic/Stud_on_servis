using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_online_servis.IB190057.Models
{
    public class KorisnickiNalog
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
    }
}
