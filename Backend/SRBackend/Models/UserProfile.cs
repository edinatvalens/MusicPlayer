
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SRBackend.Models
{
    [Table("UserProfile")]
    public abstract class UserProfile
    {
       
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public string Username { get; set; }
       
        public string Password { get; set; }

        [JsonIgnore]
        public User user => this as User;
               
    }
}
