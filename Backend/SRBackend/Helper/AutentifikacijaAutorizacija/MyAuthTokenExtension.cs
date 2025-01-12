﻿using System.Linq;
using System.Text.Json.Serialization;
using SRBackend.Data;
using SRBackend.Models;
using SRBackend.ModelsAutentififkacija;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SRBackend.Helper.AutentifikacijaAutorizacija
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }

            [JsonIgnore]
            public UserProfile korisnickiNalog => autentifikacijaToken?.korisnickiNalog;

            public AutentifikacijaToken autentifikacijaToken { get; set; }

            public bool isLogiran => korisnickiNalog != null;

 
        }


        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }

        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();

            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AutentifikacijaToken korisnickiNalog = db.AutentificationToken
               .Include(s => s.korisnickiNalog)
               .SingleOrDefault(x => token != null && x.vrijednost == token);

            return korisnickiNalog;
        }


        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];

            return token;
        }

    }
}
