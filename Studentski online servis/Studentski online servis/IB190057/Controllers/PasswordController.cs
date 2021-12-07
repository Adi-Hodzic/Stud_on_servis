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
    public class PasswordController
    {
        private DLWMS_dbContext _dbContext;
        public PasswordController(DLWMS_dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("{BrojDosijea}, {Lozinka}, {PonovnaLozinka}")]
        public string PromjeniPassword(string BrojDosijea, string Lozinka, string PonovnaLozinka)
        {
            var k = _dbContext.Korisnici.Where(x => x.KorisnickoIme == BrojDosijea).FirstOrDefault();
            if(k==null)
                return $"Pogresan broj dosijea!";
            if (Lozinka != PonovnaLozinka)
                return $"Pogresno ponovno upisivanje lozinke!";
            k.Lozinka = Lozinka;
            _dbContext.SaveChanges();
            return $"Lozinka uspjesno promjenjena!";
        }
    }
}
