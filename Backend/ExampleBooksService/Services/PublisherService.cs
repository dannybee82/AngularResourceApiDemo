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
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherEntityRepository;

        public PublisherService(IPublisherRepository publisherEntityRepository)
        {
            _publisherEntityRepository = publisherEntityRepository;
        }

        public async Task CreatePublisher(PublisherDto dto)
        {
            await _publisherEntityRepository.Create(PublisherMapper.Map(dto));
        }

        public async Task DeletePublisher(int id)
        {
            await _publisherEntityRepository.Delete(id);
        }

        public async Task<List<PublisherDto>> GetAllPublishers()
        {
            var records = await _publisherEntityRepository.GetAll();

            List<PublisherDto> list = new();

            foreach (var record in records)
            {
                list.Add(PublisherMapper.Map(record));
            }

            return list;
        }

        public async Task<PublisherDto> GetPublisherById(int id)
        {
            var record = await _publisherEntityRepository.GetById(id);
            return PublisherMapper.Map(record);
        }

        public async Task UpdatePublisher(PublisherDto dto)
        {
            await _publisherEntityRepository.Update(PublisherMapper.Map(dto));
        }

    }

}