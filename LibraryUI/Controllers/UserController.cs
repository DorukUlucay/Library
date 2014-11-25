using LibraryUI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Data;

namespace LibraryUI.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/


        public ActionResult UserList()
        {
            List<User> Users;

            using (Models.LIBRARYEntities db = new Models.LIBRARYEntities())
            {
                Users = db.User.ToList();
            }

            return View(Users);
        }

        public ActionResult UpdateUser(int ID)
        {
            User user;

            using (LIBRARYEntities db = new LIBRARYEntities())
            {
                user = db.User.FirstOrDefault(p => p.UserId == ID);
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            using (DataAccessLayer.DataAccessManager DAM = new DataAccessLayer.DataAccessManager())
            {
                List<DataParameter> D = new List<DataParameter>();
                D.Add(new DataParameter { Name = "IsActive", Value = user.IsActive, Type = DbType.Boolean });
                List<DataParameter> C = new List<DataParameter>();
                C.Add(new DataParameter { Name = "UserId", Value = user.UserId, Type = DbType.Int16 });

                DAM.Update(D, C, "User");

                return RedirectToAction("UserList");
            }
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            using (LIBRARYEntities db = new LIBRARYEntities())
            {
                db.User.Add(user);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //TODO: isimler çakıştığı için bu "Do"Login oldu. başka bir yolu yok mu ?
        public JsonResult DoLogin(User user)
        {
            User x = null;
            using (LIBRARYEntities db = new LIBRARYEntities())
            {
                x = db.User.Where(o => o.Username == user.Username && o.IsActive == true).FirstOrDefault();
            }

            if (x != null)
            {
                Session.Add("Username", x.Username);
                Session.Add("IsAdmin", x.IsAdmin == null ? false : x.IsAdmin);
                Session.Add("UserId", x.UserId);
                return Json(new { Ok = true, Username = user.Username });
            }
            else
            {
                return Json(new { Ok = false, ErrorMessage = 'X' });
            }
        }
    }
}
