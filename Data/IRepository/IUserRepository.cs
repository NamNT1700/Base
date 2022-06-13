using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserRepository: IRepositoryBase<User>
    {
        public User FindById(string id);
        public User FindByEmail(string email);
        string CheckUserInfo(string username, string email);
        public void AddNew(User entity);
        public List<User> FindAllData();
        public User FindByUsername(string username);
        public User CheckPassword(string passwword);
        public string CheckUserLogin(string username, string password);
    }
}
