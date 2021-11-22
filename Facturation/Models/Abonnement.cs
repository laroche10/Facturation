using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class Abonnement
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Cni { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Nom { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Prenom { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Adresse { get; set; }


        public int CategorieId { get; set; }


        public Categorie Categories { get; set; }

        public int PuissanceId { get; set; }

        public Puissance Puissances { get; set; }
    }
}
