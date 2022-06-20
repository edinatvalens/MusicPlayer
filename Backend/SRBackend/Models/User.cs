using System;

using System.ComponentModel.DataAnnotations.Schema;


namespace SRBackend.Models
{
    [Table("User")]
    public class User : UserProfile
    {
        
       
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Adress { get; set; }
        [ForeignKey(nameof(city))]
        public int City_id { get; set; }
        public City city { get; set; }

        [ForeignKey(nameof(gender))]
        public int Gender_id { get; set; }
        public Gender gender { get; set; }

    }
}
