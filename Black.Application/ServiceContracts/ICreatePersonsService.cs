using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Black.Domain.Entities;

namespace Black.Application.ServiceContracts
{
    public interface ICreatePersonService
    {
        Task CreatePersonAsync(Person person);
    }
}
