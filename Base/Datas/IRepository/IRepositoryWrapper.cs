using Base.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Datas.IRepository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        //IHttpRequest<object> Http { get; }
        void Save();
    }
}
