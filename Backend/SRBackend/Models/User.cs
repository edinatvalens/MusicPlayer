using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
