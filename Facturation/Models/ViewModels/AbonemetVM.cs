using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models.ViewModels
{
    public class AbonemetVM
    {
        public Abonnement Abonnement { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
        public IEnumerable<SelectListItem> TypeDropDowns { get; set; }

    }
}
