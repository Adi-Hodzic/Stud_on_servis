using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentski_online_servis.Data;
using Studentski_online_servis.Helper;
using Studentski_online_servis.IB190057.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_online_servis.IB190057.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaLoginController : ControllerBase
    {
        private DLWMS_dbContext _dbContext;
        public AutentifikacijaLoginController(DLWMS_dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public class AutentifikacijaLoginPostVM
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class AutentifikcijaLoginResultVM
        {
            public string Poruka { get; set; }
            public string TokenString { get; set; }
            public string Username { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
        }

        [HttpPost]
        public IActionResult Login([FromBody] AutentifikacijaLoginPostVM x)
        {
            var k = _dbContext.Korisnici.Where(s => s.KorisnickoIme == x.Username && s.Lozinka == x.Password).SingleOrDefault();
            if (k == null)
                return Unauthorized();

            string tokenString = TokenGenerator.Generate(5);
            _dbContext.Add(new AutentifikacijaToken
            {
                KorisnickiNalogId = k.ID,
                VrijemeEvidentiranja = DateTime.Now,
                Vrijednost = tokenString
            });
            _dbContext.SaveChanges();
            return Ok(new AutentifikcijaLoginResultVM
            {
                Poruka = "Ispravan login",
                TokenString = tokenString,
                Username = k.KorisnickoIme,
                Ime = k.Ime,
                Prezime = k.Prezime
            });
        }


        [HttpDelete]
        public IActionResult Logout()
        {
            KorisnickiNalog k = HttpContext.GetKorisnikOfAuthToken();
            if (k != null)
            {
                _dbContext.Remove(k);
                _dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
