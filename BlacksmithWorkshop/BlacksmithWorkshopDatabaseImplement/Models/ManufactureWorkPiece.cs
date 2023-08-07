using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class ManufactureWorkPiece
    {
        public int Id { get; set; }

        [Required]
        public int ManufactureId { get; set; }

        [Required]
        public int WorkPieceId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual WorkPiece WorkPiece { get; set; } = new();

        public virtual Manufacture Manufacture { get; set; } = new();
    }
}
