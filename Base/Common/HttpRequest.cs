using Base.Datas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Common
{
    public class HttpRequest<T>: RepositoryBase<T>, IHttpRequest<T> where T: class
    {
        private Context _context;
        public HttpRequest(Context context)
           : base(context)
        {
            _context = context;
        }
        //public void AddNew(T entity)
        //{
        //    Create(entity);
        //}
        //public void UpdateData(T entity)
        //{
        //    Update(entity);
        //}
        //public void DeleteData(T entity)
        //{
        //    Delete(entity);
        //}
        //public List<T> FindAllData()
        //{
        //    List<T> datas = new List<T>();
        //    datas = FindAll().ToList();
        //    datas.Sort();
        //    return datas;
        //}

    }
}
