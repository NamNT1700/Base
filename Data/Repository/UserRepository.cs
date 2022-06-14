using Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository: RepositoryBase<User>,IUserRepository
    {
        public UserRepository(Context context)
            : base(context)
        {
        }

        public void AddNew(User entity)
        {
            Create(entity);
        }
        public void DeleteUser(User entity)
        {
            Delete(entity);
        }
        public void UpdateUser(User entity)
        {
            Update(entity);
        }
        public List<User> FindAllData()
        {
            List<User> datas = new List<User>();
            datas = FindAll().ToList();
            return datas;
        }
        public User FindById(string id)
        {
            return FindByCondition(u => u.id.Equals(id)).FirstOrDefault();
        }
        public User FindByEmail(string email)
        {
            return FindByCondition(u => u.email.Equals(email)).FirstOrDefault();
        }
        public User FindByUsername(string username)
        {
            return FindByCondition(u => u.username.Equals(username)).FirstOrDefault();
        }
        public string CheckUserInfo(string username, string email)
        {
            User existUser = new User();
            existUser = FindByUsername(username);
            if (existUser != null)
                return "User already exist";
            existUser = FindByEmail(email);
            if (existUser != null)
                return "email already used";
            return null;
        }
        public User CheckPassword(string encPasswword)
        {
            return FindByCondition(u => u.password.Equals(encPasswword)).FirstOrDefault();
        }

        public string CheckUserLogin(string username, string password)
        {
            User isExist = FindByUsername(username);
            if (isExist == null)
                return "Wrong username";
            isExist = CheckPassword(password);
            if (isExist == null)
                return "Wrong password";
            return null;
        }

        public List<User> FindUsersActive()
        {
            return FindAll().Where(u => u.isActive.Equals("A")).ToList();
        }
        public List<User> FindUsersInactive()
        {
            return FindAll().Where(u => u.isActive.Equals("I")).ToList();
        }
    }
}
