using Facturation.Datas;
using Facturation.Models;
using Facturation.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Controllers
{
    public class AbonnementController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AbonnementController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {

           
            IEnumerable<Abonnement> objet = _db.Abonnement;
            foreach ( var az in objet)
            {
                az.Categories = _db.Categorie.FirstOrDefault(u => u.Id == az.CategorieId);
                az.Puissances = _db.Puissance.FirstOrDefault(u => u.Id == az.PuissanceId);
            }
                return View(objet);
        }

        public IActionResult Create()
        {
            AbonemetVM expenseVM = new AbonemetVM()
            {
                Abonnement = new Abonnement(),
                TypeDropDown = _db.Categorie.Select(i => new SelectListItem
                {
                    Text = i.Libelle,
                    Value = i.Id.ToString()
                }),


                TypeDropDowns = _db.Puissance.Select(i => new SelectListItem
                {
                    Text = i.Libelle,
                    Value = i.Id.ToString()
                }),

            };

            return View(expenseVM);



         /*   IEnumerable<SelectListItem> TypeDropDown = _db.Categorie.Select(i => new SelectListItem
            {
                Text = i.Libelle,
                Value = i.Id.ToString()
            });
            ViewBag.TypeDropDown = TypeDropDown;

            IEnumerable<SelectListItem> TypeDropDowns = _db.Puissance.Select(i => new SelectListItem
            {
                Text = i.Libelle,
                Value = i.Id.ToString()
            });
            ViewBag.TypeDropDowns = TypeDropDowns;


            return View();*/
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AbonemetVM objs)
        {
            _db.Abonnement.Add(objs.Abonnement);
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
            var obj = _db.Abonnement.Find(id);
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
            var obj = _db.Abonnement.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Abonnement.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET-Update
        public IActionResult Update(int? id)
        {

            AbonemetVM expenseVM = new AbonemetVM()
            {
                Abonnement = new Abonnement(),
                TypeDropDown = _db.Categorie.Select(i => new SelectListItem
                {
                    Text = i.Libelle,
                    Value = i.Id.ToString()
                }),


                TypeDropDowns = _db.Puissance.Select(i => new SelectListItem
                {
                    Text = i.Libelle,
                    Value = i.Id.ToString()
                }),

            };


            if (id == null || id == 0)
            {
                return NotFound();
            }
            expenseVM.Abonnement = _db.Abonnement.Find(id);
            if (expenseVM.Abonnement == null)
            {
                return NotFound();
            }
            return View(expenseVM);
        }
        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(AbonemetVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Abonnement.Update(obj.Abonnement);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
