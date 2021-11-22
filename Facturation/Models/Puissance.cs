using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class Puissance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName = "nvarchar(100)")]
        public String Libelle { get; set; }
    }
}
