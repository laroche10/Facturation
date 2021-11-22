using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class Tva
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public int Annee { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName = "nvarchar(100)")]
        public String Valeur { get; set; }


    }
}
