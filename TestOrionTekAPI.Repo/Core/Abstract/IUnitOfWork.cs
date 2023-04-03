using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOrionTekAPI.Repo.Core.Abstract
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
