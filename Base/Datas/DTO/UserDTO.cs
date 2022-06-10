using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Datas.DTO
{
    public class UserDTO
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public DateTime bith { get; set; }
    }
}
