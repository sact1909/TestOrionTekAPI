using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestOrionTekAPI.Data.Entities;
using TestOrionTekAPI.Repo.Core.Abstract;

namespace TestOrionTekAPI.Repo.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly OrionTekDbContext _context;
        private bool _Disposed = false;

        public UnitOfWork(OrionTekDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._Disposed)
            {
                if (disposing && _context != null)
                {
                    _context.Dispose();
                }

                _Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
