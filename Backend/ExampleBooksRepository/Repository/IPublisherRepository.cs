using ExampleBooksRepository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Repository
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAll();

        Task<Publisher?> GetById(int id);

        Task Create(Publisher entity);

        Task Update(Publisher entity);

        Task Delete(int id);
    }

}
