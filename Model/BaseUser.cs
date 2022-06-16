using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseUser
    {
        // user id
        public string id { get; set; }
        // user name 
        public string username { get; set; }
        // name user
        public string name { get; set; }
        // token 
        public string token { get; set; }

        private string _defaultapp;
        
        private string _langcode;
       
    }
}
