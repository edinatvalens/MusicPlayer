using System;

namespace SRBackend.ViewModels
{
    public class UserAddVM
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int City_id { get; set; }
        public int Gender_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


    }
}
