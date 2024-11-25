using ExampleBooksRepository.Entity;
using ExampleBooksService.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.Mappers
{
    public class BookMapper
    {
        public static Book Map(BookDto dto)
        {
            Book entity = new();

            if (dto.Id != null)
            {
                entity.Id = dto.Id ?? 0;
            }

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.ISBN = dto.ISBN;

            if (dto.Author != null)
            {
                entity.Author = AuthorMapper.Map(dto.Author);
            }
            else
            {
                entity.AuthorId = null;
            }

            if (dto.Publisher != null)
            {
                entity.Publisher = PublisherMapper.Map(dto.Publisher);
            }
            else
            {
                entity.PublisherId = null;
            }

            entity.DateCreated = dto.DateCreated;

            return entity;
        }

        public static BookDto Map(Book entity)
        {
            BookDto dto = new();
            dto.Id = entity.Id;
            dto.Title = entity.Title;
            dto.Description = entity.Description;
            dto.ISBN = entity.ISBN;

            if (entity.AuthorId != null && entity.Author != null)
            {
                dto.Author = AuthorMapper.Map(entity.Author);
            }

            if (entity.PublisherId != null && entity.Publisher != null)
            {
                dto.Publisher = PublisherMapper.Map(entity.Publisher);
            }

            dto.DateCreated = entity.DateCreated;

            return dto;
        }

    }

}