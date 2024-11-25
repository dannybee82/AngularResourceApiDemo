using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.DataTransferObjects
{
    public class BookDto
    {

        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public AuthorDto? Author { get; set; }

        public PublisherDto? Publisher { get; set; }

        public DateTime DateCreated { get; set; }

    }

}