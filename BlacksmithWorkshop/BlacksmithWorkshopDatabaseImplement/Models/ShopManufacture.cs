using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    public class ShopManufacture
    {
        public int Id { get; set; }

        [Required]
        public int ShopId { get; set; }

        [Required]
        public int ManufactureId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Shop Shop { get; set; } = new();

        public virtual Manufacture Manufacture { get; set; } = new();
    }
}
