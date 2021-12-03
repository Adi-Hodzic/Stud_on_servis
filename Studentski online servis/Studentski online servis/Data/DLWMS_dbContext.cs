using Microsoft.EntityFrameworkCore;
using Studentski_online_servis.IB190057.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_online_servis.Data
{
    public class DLWMS_dbContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { set; get; }
        public DLWMS_dbContext() { }
        public DLWMS_dbContext(DbContextOptions options) : base(options){}
       
    }
}
