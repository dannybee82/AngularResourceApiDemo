using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.DataTransferObjects
{
    public class AuthorDto
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; }

        public DateTime DayOfBirth { get; set; }

    }

}