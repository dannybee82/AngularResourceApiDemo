using ExampleBooksRepository.Repository;
using ExampleBooksService.DataTransferObjects;
using ExampleBooksService.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public BookService(
            IBookRepository bookEntityRepository, 
            IAuthorRepository authorRepository,
            IPublisherRepository publisherRepository)
        {
            _bookRepository = bookEntityRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task CreateBook(BookDto dto)
        {
            await _bookRepository.Create(BookMapper.Map(dto));
        }

        public async Task DeleteBook(int id)
        {
            await _bookRepository.Delete(id);
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            var records = await _bookRepository.GetAll();

            List<BookDto> list = new();

            foreach (var record in records)
            {
                list.Add(BookMapper.Map(record));
            }

            return list;
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var record = await _bookRepository.GetById(id);

            if (record == null)
            {
                throw new Exception("Null Returned");
            }

            return BookMapper.Map(record);
        }

        public async Task UpdateBook(BookDto dto)
        {
            var entity = BookMapper.Map(dto);

            if(entity.Author != null)
            {
                if(entity.Author.Id > 0)
                {
                    entity.AuthorId = entity.Author.Id;
                    await _authorRepository.Update(entity.Author);
                }
            }
            else
            {
                entity.AuthorId = null;
            }

            if(entity.Publisher != null) 
            {
                if(entity.Publisher.Id > 0)
                {
                    entity.PublisherId = entity.Publisher.Id;
                    await _publisherRepository.Update(entity.Publisher);
                }
            }
            else
            {
                entity.PublisherId = null;
            }

            await _bookRepository.Update(entity);
        }

    }

}