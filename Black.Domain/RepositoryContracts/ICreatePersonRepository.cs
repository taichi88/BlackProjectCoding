using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Black.Domain.Entities;

namespace Black.Domain.RepositoryContracts
{
    // In Black.Domain.RepositoryContracts
    public interface ICreatePersonRepository
    {
        Task<int> CreatePersonAsync(Person person); // Ensure the signature is here
    }

}
