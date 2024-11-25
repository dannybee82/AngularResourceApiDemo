using ExampleBooksRepository.Entity;
using ExampleBooksService.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.Mappers
{
    public class AuthorMapper
    {

        public static Author Map(AuthorDto dto)
        {
            Author entity = new();

            if (dto.Id != null)
            {
                entity.Id = dto.Id ?? 0;
            }
            entity.FirstName = dto.FirstName;
            entity.MiddleName = dto.MiddleName;
            entity.LastName = dto.LastName;
            entity.DayOfBirth = dto.DayOfBirth;

            return entity;
        }

        public static AuthorDto Map(Author entity)
        {
            AuthorDto dto = new();
            dto.Id = entity.Id;
            dto.FirstName = entity.FirstName;
            dto.MiddleName = entity.MiddleName;
            dto.LastName = entity.LastName;
            dto.DayOfBirth = entity.DayOfBirth;

            return dto;
        }

    }

}