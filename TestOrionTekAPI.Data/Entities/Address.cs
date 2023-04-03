using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrionTekAPI.Data.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string AddressName { get; set; }

        public Guid EmployeesId { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
