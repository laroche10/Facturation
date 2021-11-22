using Facturation.Datas;
using Facturation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Controllers
{
    public class CategorieController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategorieController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Categorie> objet = _db.Categorie;
            return View(objet);
        }

        public IActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie objs)
        {
            if (ModelState.IsValid)
            {
                _db.Categorie.Add(objs);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(objs);
        }


        // GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categorie.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categorie.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categorie.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET-Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categorie.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Categorie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categorie.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
