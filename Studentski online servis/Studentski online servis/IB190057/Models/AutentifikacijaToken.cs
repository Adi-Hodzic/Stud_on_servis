using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_online_servis.IB190057.Models
{
    public class AutentifikacijaToken
    {
        [Key]
        public int ID { get; set; }
        public string Vrijednost { get; set; }
        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public virtual KorisnickiNalog KorisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IP_Adresa { get; set; }
    }
}
