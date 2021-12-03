using Microsoft.AspNetCore.Http;
using Studentski_online_servis.Data;
using Studentski_online_servis.IB190057.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studentski_online_servis.Helper
{
    public static class MyAuthTokenExtension
    {
        private static DLWMS_dbContext dlwms;

        public static KorisnickiNalog GetKorisnikOfAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            return GetKorisnikOfAuthToken(token);
        }

        public static KorisnickiNalog GetKorisnikOfAuthToken(string token)
        {
            KorisnickiNalog korisnickiNalog = dlwms.AutentifikacijaToken.Where(x => token != null && x.Vrijednost == token).Select(s => s.KorisnickiNalog).SingleOrDefault();
            return korisnickiNalog;
        }

        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["MojAutentifikacijaToken"];
            return token;
        }
    }
}
