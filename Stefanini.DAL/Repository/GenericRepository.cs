using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StefaniniQuiz.DAL.Interfaces;
using StefaniniQuiz.Domain.EntityInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        
        protected readonly QuizDbContext _quizDbContext;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(QuizDbContext quizDbContext)
        {
            _quizDbContext = quizDbContext;
            _dbSet = _quizDbContext.Set<TEntity>();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _quizDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> Update(TEntity entity)
        {

            _quizDbContext.Update(entity);
            await _quizDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<ICollection<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {

            IQueryable<TEntity> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }



        public async Task<TEntity?> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;


            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(t => t.Id == id);


        }

        public async Task<TEntity> RemoveExistingQuestion(TEntity existingQuestion)
        {
            _dbSet.Remove(existingQuestion);
            return existingQuestion;

        }

        public async Task<TEntity> SetValues(TEntity existingEntity, TEntity editedEntity)
        {
            _quizDbContext.Entry(existingEntity).CurrentValues.SetValues(editedEntity);
            return existingEntity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var toDelete = await _dbSet.FindAsync(id);

                return await DeleteAsync(toDelete);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _quizDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}

