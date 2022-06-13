using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        public Context context { get; set; }
        public RepositoryBase(Context context)
        {
            this.context = context;
        }
        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
    }
}
