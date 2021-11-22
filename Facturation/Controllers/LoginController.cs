using Facturation.Datas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Controllers
{
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
