using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.SearchModels
{
    public class ClientSearchModel
    {
        public int? Id { get; set; }

        public string? ClientFIO { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
