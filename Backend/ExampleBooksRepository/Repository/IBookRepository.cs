using ExampleBooksRepository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<Book?> GetById(int id);

        Task Create(Book entity);

        Task Update(Book entity);

        Task Delete(int id);
    }

}