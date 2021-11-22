using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Vous ne pouvez pas depasser 10 caractères")]
        [Column(TypeName = "nvarchar(100)")]
        public String Libelle { get; set; }
    }
}
