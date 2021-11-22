using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Models
{
    public class Facturations
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Numero_facture { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Montant_hors_taxe { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String Montant_ttc { get; set; }

        public int TvaId { get; set; }
        public Tva Tva { get; set; }

        public int AbonnementId { get; set; }
        public Abonnement Abonnement { get; set; }
    }
}
