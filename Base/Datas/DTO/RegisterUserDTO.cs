using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Datas.DTO
{
    public class RegisterUserDTO
    {
        public Guid id { get => new Guid();}
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public DateTime bith { get; set; }
    }
}
