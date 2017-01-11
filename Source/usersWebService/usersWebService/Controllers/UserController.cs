using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using usersWebService.Models;
using Repositories1;


namespace usersWebService.Controllers
{
    public class UserController : Controller
    {

       //private AdminEntities udb = new AdminEntities();
        private IUserRepository userrepository;

        public UserController()
        {
            this.userrepository = new UserRepository(new AdminEntities());
        }

        // GET: User
        public ActionResult Index()
        {
            var Users = userrepository.Admin;
            return View(Users);
        }

        //GET: User/Create
        public ActionResult Create()
        {
            var records = userrepository.Admin;
            ViewBag.user = new SelectList(records, "ID", "User");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(usersWebService.Admin un)
        {
            try
            {
                
                    userrepository.Admin.Add(un);
                    userrepository.SaveChanges();
                    return RedirectToAction("Index");
                
             //   return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return View(un);
            }
        }

        //GET: User/Edit
        public ActionResult Edit(int id)
        {
            Admin users = userrepository.Admin.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Edit
        [HttpPost]
        public ActionResult Edit(
            [Bind(
                Include =
                    "ID, User"
                )] Admin users)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    userrepository.Entry(users).State = EntityState.Modified;
                    userrepository.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.user = new SelectList(userrepository.Admin, "ID", "User",
                    users.ID);
                return View(users);
            }
        }
          
    }

}