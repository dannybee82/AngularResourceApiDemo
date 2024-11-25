using ExampleBooksService.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.Services
{
    public interface IBookService
    {
        Task CreateBook(BookDto dto);

        Task UpdateBook(BookDto dto);

        Task DeleteBook(int id);

        Task<List<BookDto>> GetAllBooks();

        Task<BookDto> GetBookById(int id);
    }

}