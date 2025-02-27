using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for related Cards (One-to-Many relationship)
        public List<Accounts> Accounts { get; set; }
    }

}
