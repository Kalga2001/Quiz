using Microsoft.EntityFrameworkCore.Query;
using StefaniniQuiz.Domain.EntityInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task<ICollection<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> SetValues(TEntity existingQuiz, TEntity editedQuiz);
        Task<TEntity> RemoveExistingQuestion(TEntity existingQuestion);


    }
}
