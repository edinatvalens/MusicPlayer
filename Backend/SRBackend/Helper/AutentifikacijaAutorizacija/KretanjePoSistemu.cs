using System;
using SRBackend.Modul0_Autentifikacija.Models;
using SRBackend.Data;
using SRBackend.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace SRBackend.Helper.AutentifikacijaAutorizacija
{
    public class KretanjePoSistemu
    {
        public static int Save(HttpContext httpContext, IExceptionHandlerPathFeature exceptionMessage = null)
        {

            UserProfile korisnik = httpContext.GetLoginInfo().korisnickiNalog;

            var request = httpContext.Request;

            var queryString = request.Query;

            if (queryString.Count == 0 && !request.HasFormContentType)
                return 0;

            string detalji = "";
            if (request.HasFormContentType)
            {
                foreach (string key in request.Form.Keys)
                {
                    detalji += " | " + key + "=" + request.Form[key];
                }
            }

            var x = new MovingHelper
            {
                user = korisnik,
                time = DateTime.Now,
                queryPath = request.GetEncodedPathAndQuery(),
                postData = detalji,
                ipAdress = request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            if (exceptionMessage != null)
            {
                x.isException = true;
                x.exceptionMessage = exceptionMessage.Error.Message + " |" + exceptionMessage.Error.InnerException;
            }

            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            db.Add(x);
            db.SaveChanges();

            return x.id;
        }




    }
}
