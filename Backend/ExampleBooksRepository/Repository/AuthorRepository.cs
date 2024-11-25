using ExampleBooksRepository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        private readonly MainDbContext _dbContext;

        public AuthorRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Author entity)
        {
            await _dbContext.Authors.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var record = await GetById(id);

            if (record != null)
            {
                _dbContext.Authors.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Author>> GetAll()
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Author?> GetById(int id)
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task Update(Author entity)
        {
            var record = await GetById(entity.Id);

            if (record != null)
            {
                _dbContext.Authors.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}