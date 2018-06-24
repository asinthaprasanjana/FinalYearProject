using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Genaric repository implementation 
/// </summary>
namespace Max.MedicalLab.Data.Entity.Repository
{
    public abstract class MedLabRepository<T> : IRepository<T> where T : BaseEntity
    {
        
        protected readonly MedLabContext context;

        public MedLabRepository()
        {
            this.context = new MedLabContext();
        }

        public void Delete(T entity)
        {

            context.Set<T>().Remove(entity);
         
            this.Save();
           
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual T GetById<T2>(T2 id) where T2 : struct
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            var savedEntity = context.Set<T>().Add(entity);
            this.Save();

            return savedEntity;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> result = context.Set<T>().Where(predicate);

            return result;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            this.Save();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
