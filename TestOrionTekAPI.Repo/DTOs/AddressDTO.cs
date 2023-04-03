using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOrionTekAPI.Data.Entities;

namespace TestOrionTekAPI.Repo.DTOs
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string AddressName { get; set; }
    }
}
