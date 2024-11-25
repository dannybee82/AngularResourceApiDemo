using ExampleBooksRepository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();

        Task<Author?> GetById(int id);

        Task Create(Author entity);

        Task Update(Author entity);

        Task Delete(int id);
    }

}
