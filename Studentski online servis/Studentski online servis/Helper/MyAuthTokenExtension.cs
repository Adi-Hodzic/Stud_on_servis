using Microsoft.AspNetCore.Http;
using Studentski_online_servis.Data;
using Studentski_online_servis.IB190057.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace Studentski_online_servis.Helper
{
    public static class MyAuthTokenExtension
    {

        public static AutentifikacijaToken GetKorisnikOfAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            DLWMS_dbContext db = httpContext.RequestServices.GetService<DLWMS_dbContext>();
            AutentifikacijaToken tokenNalog= db.AutentifikacijaToken.Where(x => token != null && x.Vrijednost == token).SingleOrDefault();
            return tokenNalog;
        }

        //public static KorisnickiNalog GetKorisnikOfAuthToken(string token)
        //{
        //    //KorisnickiNalog korisnickiNalog = dlwms.AutentifikacijaToken.Where(x => token != null && x.Vrijednost == token).Select(s => s.KorisnickiNalog).SingleOrDefault();
        //    //return korisnickiNalog;
        //}

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["Token"];
            return token;
        }
    }
}
