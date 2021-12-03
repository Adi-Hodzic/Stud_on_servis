using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_online_servis.IB190057.Models
{
    public enum VrstaKorisnika
    {
        Student,
        Profesor,
        Referent
    }
    public class Korisnik : KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public VrstaKorisnika Vrsta_Korisnika { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumPrijave { get; set; }
    }
}
