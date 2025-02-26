using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Black.Domain.Entities;
using Black.Domain.RepositoryContracts;
 

using System.Threading.Tasks;
using Dapper;
 
using Black.Infrastructure.Helpers;
 


namespace Black.Infrastructure.Repositories
{
    public class CreatePersonRepository : ICreatePersonRepository
    {
        private readonly DapperHelper _dapperHelper;

        public CreatePersonRepository(DapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<int> CreatePersonAsync(Person person)
        {
            var sql = "INSERT INTO Person1 (name) VALUES (@Name)";

            // Ensure Dapper's ExecuteAsync method is being used
            var result = await _dapperHelper.ExecuteAsync(sql, new { Name = person.Name});
            
            return result;
        }
       
    }

}

