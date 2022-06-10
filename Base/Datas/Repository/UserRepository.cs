﻿using Base.Common;
using Base.Datas.IRepository;
using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Datas.Repository
{
    public class UserRepository :RepositoryBase<User>, IUserRepository //HttpRequest<User>, IUserRepository
    {
        Context _context;
        public UserRepository(Context context)
            : base(context)
        {
            _context = context;
        }

        public void AddNew(User entity)
        {
            Create(entity);
        }
        public List<User> FindAllData()
        {
            List<User> datas = new List<User>();
            datas = FindAll().ToList();
            //datas.Sort();
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
        public string CheckUserInfo(string username,string email)
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
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}