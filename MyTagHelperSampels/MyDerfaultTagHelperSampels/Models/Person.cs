using System.ComponentModel.DataAnnotations;

namespace MyDerfaultTagHelperSampels.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; } = "User";
        [Required]
        public string LastName { get; set; } = "Family";
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
