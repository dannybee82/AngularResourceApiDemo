using ExampleBooksRepository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksRepository.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly MainDbContext _dbContext;

        public BookRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var record = await GetById(id);

            if (record != null)
            {
                _dbContext.Books.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetAll()
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Book?> GetById(int id)
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task Update(Book entity)
        {
            var record = await GetById(entity.Id);

            if (record != null)
            {
                _dbContext.Books.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}