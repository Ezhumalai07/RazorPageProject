using System.ComponentModel.DataAnnotations;

namespace Hub.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
