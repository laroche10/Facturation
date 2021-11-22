using Facturation.Datas;
using Facturation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Controllers
{
    public class PuissanceController : Controller
    {

        private readonly ApplicationDbContext _db;

        public PuissanceController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Puissance> objet = _db.Puissance;
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
            _db.Categorie.Add(objs);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        // GET-Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Puissance.Find(id);
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
            var obj = _db.Puissance.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Puissance.Remove(obj);
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
            var obj = _db.Puissance.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Puissance obj)
        {
            if (ModelState.IsValid)
            {
                _db.Puissance.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
