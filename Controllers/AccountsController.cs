using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Projecto1.Models;
using System.Linq;
using System.Web.Security;


namespace Projecto1.Controllers
{
    public class AccountsController : Controller
    {
        Usuarios1Entities entity = new Usuarios1Entities();
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        
        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult RegistroMaterias()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            
            bool userExist = entity.Estudiante.Any(x => x.Email_estudiante == credentials.Email_estudiante && x.Password_estudiante == credentials.Password_estudiante);
            Estudiante u = entity.Estudiante.FirstOrDefault(x => x.Email_estudiante == credentials.Email_estudiante && x.Password_estudiante == credentials.Password_estudiante);


            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Email_estudiante, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Hay algo que esta mal");
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Estudiante userinfo)
        {
            entity.Estudiante.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult RegistroMaterias(Materias userinfo2)
        {
            entity.Materias.Add(userinfo2);
            entity.SaveChanges();
            return RedirectToAction("Index","Home");
        }



        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}