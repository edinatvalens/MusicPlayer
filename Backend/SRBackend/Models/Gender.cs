
using System.ComponentModel.DataAnnotations;


namespace SRBackend.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
