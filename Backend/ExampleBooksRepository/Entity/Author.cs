using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Entity
{

    [Table("Author", Schema = "ExampleBooksApp")]
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DayOfBirth { get; set; }
    }

}
