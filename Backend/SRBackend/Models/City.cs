
using System.ComponentModel.DataAnnotations;


namespace SRBackend.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostalNumber { get; set; }
    }
}
