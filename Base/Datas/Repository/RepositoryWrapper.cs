using Base.Datas.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Datas.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
         Context _context;
        IUserRepository userRepository;
        public RepositoryWrapper(Context context)
        {
            _context = context;
        }
        public IUserRepository User
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_context);
                return userRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
