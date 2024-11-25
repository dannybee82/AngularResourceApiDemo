using ExampleBooksService.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBooksService.Services
{
    public interface IPublisherService
    {
        Task CreatePublisher(PublisherDto dto);

        Task UpdatePublisher(PublisherDto dto);

        Task DeletePublisher(int id);

        Task<List<PublisherDto>> GetAllPublishers();

        Task<PublisherDto> GetPublisherById(int id);
    }

}