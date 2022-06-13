using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.USERDTO
{
    public class UserDTO
    {
        public string id { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        
        public DateTime bith { get; set; }
        public bool isActive { get; set; }
    }
}
