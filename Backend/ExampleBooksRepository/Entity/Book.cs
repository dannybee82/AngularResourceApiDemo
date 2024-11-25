using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Entity
{

    [Table("Book", Schema = "ExampleBooksApp")]
    public class Book
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ISBN { get; set; } = string.Empty;

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }

        public Author? Author { get; set; }

        [ForeignKey("Publisher")]
        public int? PublisherId { get; set; }

        public Publisher? Publisher { get; set; }

        public DateTime DateCreated { get; set; }

    }

}