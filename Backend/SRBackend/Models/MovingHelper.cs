using SRBackend.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SRBackend.Modul0_Autentifikacija.Models
{
    public class MovingHelper
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(user))]
        public string userID { get; set; }
        public  UserProfile user { get; set; }
        public string queryPath { get; set; }
        public string postData { get; set; }
        public DateTime time { get; set; }
        public string ipAdress { get; set; }
        public string exceptionMessage { get; set; }
        public bool isException { get; set; }
    }
}
