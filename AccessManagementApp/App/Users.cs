using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessManagementApp.Models;
using System.Collections;

namespace AccessManagementApp.App
{
    public class Users
    {
        public ArrayList users = new ArrayList();

        public Users()
        {
            UserType admin = new UserType("admin");
            UserType guest = new UserType("guest");
            User u1 = new User("Ron", "gh@gmail.com", "22334#", admin);
            User u2 = new User("Karen", "lh@gmail.com", "2884#", guest);
            User u3 = new User("Anna", "kh@gmail.com", "3434*", guest);
            users.AddRange(new[] { u1, u2, u3 });
        }

        public User check_user_exict(User uu) {
            foreach(User item in users)
            {
              if(uu.Equals(item))
                {
                    return item;
                }
            }
            throw new Exception("user not found");
        }

        public bool change_password(User u, string newp) {
            foreach (User item in users)
            {
                if (item.email == u.email && item.password == u.password)
                {
                    item.password = newp;
                    return true;
                }
            }
            throw new Exception("anouthrized");
        }

        public bool add_user(User u)
        {
            try {
                users.Add(u);
                return true;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message); }
        }

        public bool delete_user(User u)
        {
            try
            {
                users.Remove(u);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
