using ExampleBooksService.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.Services
{
    public interface IAuthorService
    {
        Task CreateAuthor(AuthorDto dto);

        Task UpdateAuthor(AuthorDto dto);

        Task DeleteAuthor(int id);

        Task<List<AuthorDto>> GetAllAuthors();

        Task<AuthorDto> GetAuthorById(int id);
    }

}