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
    public class FakultetController
    {
        private DLWMS_dbContext _dbContext;
        public FakultetController(DLWMS_dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("{Naziv},{Grad}")]
        public string DodajFakultet(string Naziv, string Grad)
        {
            Fakultet x = new Fakultet(Naziv, Grad);
            _dbContext.Fakulteti.Add(x);
            _dbContext.SaveChanges();
            return $"Fakultet uspjesno dodat";
        }
        [HttpGet]
        public object GetFakulteti(string Naziv)
        {
            return _dbContext.Fakulteti.Where(x =>Naziv==null 
            || x.Naziv.ToLower().StartsWith(Naziv) 
            || x.Grad.ToLower().StartsWith(Naziv)).ToList();
        }
    }
}
