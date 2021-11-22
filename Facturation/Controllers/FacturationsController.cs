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
    public class FacturationsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public FacturationsController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {


            IEnumerable<Facturations> objet = _db.Facturations;
            foreach (var az in objet)
            {
                az.Abonnement = _db.Abonnement.FirstOrDefault(u => u.Id == az.AbonnementId);
                az.Tva = _db.Tva.FirstOrDefault(u => u.Id == az.TvaId);
            }
            return View(objet);
        }

        public IActionResult Create()
        {
            FacturationsVM FacturationVM = new FacturationsVM()
            {
                Facturations = new Facturations(),
                TypeDropDown = _db.Abonnement.Select(i => new SelectListItem
                {
                    Text = i.Nom,
                    Value = i.Id.ToString()
                }),


                TypeDropDowns = _db.Tva.Select(i => new SelectListItem
                {
                    Text = i.Valeur,
                    Value = i.Id.ToString()
                }),

            };

            return View(FacturationVM);



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
        public IActionResult Create(FacturationsVM objs)
        {
            _db.Facturations.Add(objs.Facturations);
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
            var obj = _db.Facturations.Find(id);
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
            var obj = _db.Facturations.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Facturations.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET-Update
        public IActionResult Update(int? id)
        {

            FacturationsVM expenseVM = new FacturationsVM()
            {
                Facturations = new Facturations(),
                TypeDropDown = _db.Abonnement.Select(i => new SelectListItem
                {
                    Text = i.Nom,
                    Value = i.Id.ToString()
                }),


                TypeDropDowns = _db.Tva.Select(i => new SelectListItem
                {
                    Text = i.Valeur,
                    Value = i.Id.ToString()
                }),

            };


            if (id == null || id == 0)
            {
                return NotFound();
            }
            expenseVM.Facturations = _db.Facturations.Find(id);
            if (expenseVM.Facturations == null)
            {
                return NotFound();
            }
            return View(expenseVM);
        }
        // POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(FacturationsVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Facturations.Update(obj.Facturations);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
