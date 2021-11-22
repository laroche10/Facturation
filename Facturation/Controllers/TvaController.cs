using Facturation.Datas;
using Facturation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Controllers
{
    public class TvaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TvaController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Tva> objet = _db.Tva;
            return View(objet);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tva objs)
        {
            _db.Tva.Add(objs);
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
            var obj = _db.Tva.Find(id);
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
            var obj = _db.Tva.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Tva.Remove(obj);
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
            var obj = _db.Tva.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Tva obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tva.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


    }
}
