using ExampleBooksRepository.Entity;
using ExampleBooksService.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.Mappers
{
    public class PublisherMapper
    {
        public static Publisher Map(PublisherDto dto)
        {
            Publisher entity = new();

            if (dto.Id != null)
            {
                entity.Id = dto.Id ?? 0;
            }

            entity.Name = dto.Name;

            return entity;
        }

        public static PublisherDto Map(Publisher entity)
        {
            PublisherDto dto = new();
            dto.Id = entity.Id;
            dto.Name = entity.Name;

            return dto;
        }

    }

}