using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Datas.IRepository
{
    public interface IUserRepository
    {
        public User FindById(string id);
        public User FindByEmail(string email);
        string CheckUserInfo(string username, string email);
        public void AddNew(User entity);
        public void Save();
        public IEnumerable<User> FindAllData();
    }
}
