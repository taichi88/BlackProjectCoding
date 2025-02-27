using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black.Domain.Entities
{
    public class Accounts
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int  PersonId { get; set; }
        public List<Cards> Cards { get; set; }

        // Navigation property for related Person
        
    }
}
