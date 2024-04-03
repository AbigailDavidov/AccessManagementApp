using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AccessManagementApp.Models
{
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UserType ut { get; set; }

        public User()
        {
            this.name = "";
            this.email = "";
            this.password = "";
        }

        public User(string name, string email, string password, UserType ut)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.ut = ut;
        }

        public User(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.ut = new UserType("guest");
        }

        public bool CheckPassword(string email, string password)
        {
            if (this.email == email && this.password == password)
                return true;
            else
                return false;
        }

        public bool Equals(User u)
        {
            if (this.name == u.name && this.email == u.email && this.password == u.password)
                return true;
            else
                return false;
        }

        public bool IsAdmin()
        {
            return this.ut.IsAdmin();
        }

    }


}
