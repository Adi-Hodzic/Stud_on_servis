using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentski_online_servis.Data;
using Studentski_online_servis.IB190057.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_online_servis.IB190057.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {
        private DLWMS_dbContext dLWMS_Db;
        private VrstaKorisnika vrsta;
        private string _vrsta;
        private VrstaKorisnika NovaVrsta;
        public KorisnikController(DLWMS_dbContext dbContext)
        {
            dLWMS_Db = dbContext;
        }
        public class KorisnikVM
        {
            public string Ime { get; set; }
            public string KorisnickoIme { get; set; }
            public string Prezime { get; set; }
            public string Password { get; set; }
            public string Vrsta_Korisnika { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public DateTime DatumPrijave { get; set; }
        }
        [HttpPost]
        public string DodajKorisnika([FromBody] KorisnikVM NoviKorisnik)
        {
            if (NoviKorisnik.Vrsta_Korisnika.CompareTo("Profesor") == 0 || NoviKorisnik.Vrsta_Korisnika.CompareTo("profesor") == 0)
            {
                vrsta = VrstaKorisnika.Profesor;
                _vrsta = "Profesor";
            }
            else if (NoviKorisnik.Vrsta_Korisnika.CompareTo("Student") == 0 || NoviKorisnik.Vrsta_Korisnika.CompareTo("student") == 0)
            {
                vrsta = VrstaKorisnika.Student;
                _vrsta = "Student";
            }
            else if (NoviKorisnik.Vrsta_Korisnika.CompareTo("Referent") == 0 || NoviKorisnik.Vrsta_Korisnika.CompareTo("referent") == 0)
            {
                vrsta = VrstaKorisnika.Referent;
                _vrsta = "Referent";
            }
            Korisnik noviKorisnik = new Korisnik();
            noviKorisnik.Ime = NoviKorisnik.Ime;
            noviKorisnik.Prezime = NoviKorisnik.Prezime;
            noviKorisnik.Vrsta_Korisnika = vrsta;
            noviKorisnik.DatumRodjenja = NoviKorisnik.DatumRodjenja;
            noviKorisnik.DatumPrijave = NoviKorisnik.DatumPrijave;
            noviKorisnik.KorisnickoIme = NoviKorisnik.KorisnickoIme;
            noviKorisnik.Lozinka = NoviKorisnik.Password;

            dLWMS_Db.Korisnici.Add(noviKorisnik);
            dLWMS_Db.SaveChanges();
            return $"{_vrsta} uspjesno dodat";
        }
        [HttpGet]
        public object GetKorisnike(string? _VrstaKorisnika, string? Ime, string? Prezime)
        {
            if (_VrstaKorisnika != null)
            {
                if (_VrstaKorisnika.CompareTo("Profesor") == 0 || _VrstaKorisnika.CompareTo("profesor") == 0)
                    NovaVrsta = VrstaKorisnika.Profesor;
                else if (_VrstaKorisnika.CompareTo("Student") == 0 || _VrstaKorisnika.CompareTo("student") == 0)
                    NovaVrsta = VrstaKorisnika.Student;
                else if (_VrstaKorisnika.CompareTo("Referent") == 0 || _VrstaKorisnika.CompareTo("referent") == 0)
                    NovaVrsta = VrstaKorisnika.Referent;


                if (Ime != null && Prezime != null)
                    return dLWMS_Db.Korisnici.Where(x =>
                    (x.Vrsta_Korisnika == NovaVrsta && x.Ime.CompareTo(Ime) == 0 && x.Prezime.CompareTo(Prezime) == 0)).ToList();

                if (Ime == null && Prezime != null)
                    return dLWMS_Db.Korisnici.Where(x => x.Vrsta_Korisnika == NovaVrsta && x.Prezime.CompareTo(Prezime) == 0).ToList();

                if (Ime == null && Prezime == null)
                    return dLWMS_Db.Korisnici.Where(x => x.Vrsta_Korisnika == NovaVrsta).ToList();

                if (Ime != null && Prezime == null)
                    return dLWMS_Db.Korisnici.Where(x => x.Vrsta_Korisnika == NovaVrsta && x.Ime.CompareTo(Ime) == 0).ToList();
            }

            if (Ime == null && Prezime != null)
                return dLWMS_Db.Korisnici.Where(x => x.Prezime.CompareTo(Prezime) == 0).ToList();

            if (Ime != null && Prezime == null)
                return dLWMS_Db.Korisnici.Where(x => x.Ime.CompareTo(Ime) == 0).ToList();

            if (Ime != null && Prezime != null)
                return dLWMS_Db.Korisnici.Where(x => x.Ime.CompareTo(Ime) == 0 && x.Prezime.CompareTo(Prezime) == 0).ToList();

            return dLWMS_Db.Korisnici.ToList();
        }
    }

}
