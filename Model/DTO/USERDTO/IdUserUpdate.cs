using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.USERDTO
{
    public class IdUserUpdate
    {
        public string id { get; set; }
        public UpdateStatusUserDTO updateStatusUserDTO { get; set; }
    }
    public class UpdateStatusUserDTO
    {
        public bool isActive { get; set; }
    }
}
