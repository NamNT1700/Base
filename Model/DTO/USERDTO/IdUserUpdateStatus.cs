using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.USERDTO
{
    public class IdUserUpdateStatus
    {
        public List<string> ids { get; set; }
        //public UpdateStatusUserDTO updateStatusUserDTO { get; set; }
    }
    public class UpdateStatusUserDTO
    {
        public string isActive { get; set; }
    }
}
