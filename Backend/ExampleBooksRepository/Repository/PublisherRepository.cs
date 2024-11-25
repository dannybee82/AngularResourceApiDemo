using ExampleBooksRepository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Repository
{
    public class PublisherRepository : IPublisherRepository
    {

        private readonly MainDbContext _dbContext;

        public PublisherRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Publisher entity)
        {
            await _dbContext.Publishers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var record = await GetById(id);

            if (record != null)
            {
                _dbContext.Publishers.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Publisher>> GetAll()
        {
            return await _dbContext.Publishers
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Publisher?> GetById(int id)
        {
            return await _dbContext.Publishers
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task Update(Publisher entity)
        {
            var record = await GetById(entity.Id);

            if (record != null)
            {
                _dbContext.Publishers.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}