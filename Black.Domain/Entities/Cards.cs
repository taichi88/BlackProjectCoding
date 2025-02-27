using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black.Domain.Entities
{
    public class Cards
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string PinCode { get; set; }

        // Foreign key to Person table
        public int AccountId { get; set; }

        // Navigation property for related Person
        
    }

}
