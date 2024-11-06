using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatories.Base
{
    public interface IBaseRepository<T,U> where T : class
    {

        IQueryable<T> GetAll();
        T GetById(U id);
        T Find(Expression<Func<T,bool>> criteria);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(U id);
        void SaveChanges();

    }
}
