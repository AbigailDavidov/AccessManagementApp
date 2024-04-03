using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessManagementApp.Models;

namespace AccessManagementApp.Models
{
    public class UserType
    {
        public string user_type { get; set; }

        public UserType(string ut)
        {
            this.user_type = ut;
        }

        public bool IsAdmin()
        {
            if (this.user_type != "admin")
                return false;
            else
                return true;
        }
        
    }
}
