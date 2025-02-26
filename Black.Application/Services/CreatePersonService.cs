using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Black.Application.ServiceContracts;
using Black.Domain.Entities;
using Black.Domain.RepositoryContracts;

namespace Black.Application.Services
{
    public class CreatePersonService : ICreatePersonService
    {
        private readonly ICreatePersonRepository _personCreateRepository; // Assume this exists

        public CreatePersonService(ICreatePersonRepository personRepository)
        {
            _personCreateRepository = personRepository;
        }
        public async Task CreatePersonAsync(Person person)
        {
            // Logic to create a person, such as validation, then saving it to the database
            await _personCreateRepository.CreatePersonAsync(person);
        }
    }
}
