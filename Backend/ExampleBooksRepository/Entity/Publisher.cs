using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Entity
{

    [Table("Publisher", Schema = "ExampleBooksApp")]
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }

}