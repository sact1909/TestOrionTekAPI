using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrionTekAPI.Data.Entities
{
    public class Employees
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CompanyID { get; set; }
        public string Position { get; set; }
        public virtual ICollection<Address> Address { get; set; }

    }
}
