using AccessManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AccessManagementApp.App;
using System.Text.Json;

namespace AccessManagementApp.Controllers
{
    public class HomeController : Controller
    {
        public class RoleResponse
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public class HelperUser
        {
            public string name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string ut { get; set; }
        }


        Users ulist = new Users();
        static User logged;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] User o)
        {
            try { 
                logged = ulist.check_user_exict(o);
                string role = logged.ut.user_type;
                Response.StatusCode = 200;
                return Json(new RoleResponse() { code = 200, message = role });
            }
            catch (Exception ex)
            {
                if(ex.Message == "user not found")
                {
                    Response.StatusCode = 400;
                    return Json(new RoleResponse() { code = 400, message = "couldn't find user" });
                }
                throw new Exception(ex.Message);
            }
        }

        [HttpGet, Route("actions")]
        public IActionResult Actions()
        {
            return View();
        }

        [HttpPut, Route("actions")]
        public IActionResult Actions([FromBody] string newp)
        {
            try
            {
                bool change = ulist.change_password(logged, newp);
                return Json(new RoleResponse() { code = 200, message = "password changed" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "anouthrized")
                {
                    Response.StatusCode = 401;
                    return Json(new RoleResponse() { code = 401, message = "can't change password for another user" });
                }
                throw new Exception(ex.Message);
            }
        }

        [HttpPost, Route("actions")]
        public IActionResult Actions([FromBody] HelperUser u)
        {
            UserType ut = new UserType(u.ut);
            User us = new User(u.name, u.email, u.password, ut);
            try
            {
                ulist.add_user(us);
                return Json(new RoleResponse() { code = 200, message = "user added" });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete, Route("actions")]
        public IActionResult Actions([FromBody] User us)
        {
            try
            {
                ulist.delete_user(us);
                return Json(new RoleResponse() { code = 200, message = "user deleted" });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
