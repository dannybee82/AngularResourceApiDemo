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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task CreateAuthor(AuthorDto dto)
        {
            await _authorRepository.Create(AuthorMapper.Map(dto));
        }

        public async Task DeleteAuthor(int id)
        {
            await _authorRepository.Delete(id);
        }

        public async Task<List<AuthorDto>> GetAllAuthors()
        {
            var records = await _authorRepository.GetAll();

            List<AuthorDto> list = new();

            foreach (var record in records)
            {
                list.Add(AuthorMapper.Map(record));
            }

            return list;
        }

        public async Task<AuthorDto> GetAuthorById(int id)
        {
            var record = await _authorRepository.GetById(id);
            return AuthorMapper.Map(record);
        }

        public async Task UpdateAuthor(AuthorDto dto)
        {
            await _authorRepository.Update(AuthorMapper.Map(dto));
        }

    }

}