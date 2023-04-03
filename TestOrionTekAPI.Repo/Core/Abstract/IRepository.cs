using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestOrionTekAPI.Repo.Core.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entityList);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entityList);

        void RemoveAll(IEnumerable<TEntity> entities);

        Task RemoveAllAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        Task RemoveAsync(TEntity entity);

        TEntity Update(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        IEnumerable<TEntity> GetAll(string sortExpression = null);

        Task<IEnumerable<TEntity>> GetAllAsync(string sortExpression = null);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, string sortExpression = null);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, string sortExpression = null);

        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null);

        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null);

        IEnumerable<TResult> GetAll<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null);

        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null);

        int GetCount<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null);

        Task<int> GetCountAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null);

        TResult Get<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null);

        TResult GetSingle<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null);

        Task<TResult> GetSingleAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null);

        //Task<TResult> GetAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, string sortExpression = null);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

        bool Exists<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null);

        Task<bool> ExistsAsync<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null);

        bool Exists(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null);

        Task<bool> ExistsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null);

    }
}
