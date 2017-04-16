using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Lab10_ASP_Database.Models;
using MongoDB.Bson;

namespace Lab10_ASP_Database.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersRepository usersRepository;
 
        public HomeController()
        {
            usersRepository = new UsersRepository();
        }

        public IActionResult Index()
        {
            ViewBag.Collections = Get();
            return View();
        }

        public List<User> Get()
        {
            return usersRepository.AllUsers();
        }

        [HttpPost]
        public IActionResult Insert(User user)
        {
            if (ModelState.IsValid)
            {
                usersRepository.Add(user);
                return RedirectToAction("Index");
            }
            ViewBag.Collections = Get();
            return View("Index");
        }

        [HttpPost]
        public IActionResult Edit(string id, User user)
        {
            user.Id = new ObjectId(id);
            if (user.Id != null)
            {
                if (ModelState.IsValid)
                {
                    usersRepository.Update(user);
                    return RedirectToAction("Index");

                }
                ViewBag.Collections = Get();
                return View("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                User user = usersRepository.GetUser(new ObjectId(id));
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                usersRepository.Remove(new ObjectId(id));
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
