using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Genaric repository interface
/// </summary>
/// 
namespace Max.MedicalLab.Data.Entity.Repository
{
    interface IRepository<T> where T : BaseEntity
    {
        T Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate); //predicate is the searching criteria//
        IQueryable<T> GetAll();
        T GetById<T2>(T2 id) where T2 : struct;
        void Save();
    }

}
