﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Models
{
    public interface IClientModel : IId
    {
        string ClientFIO { get; }

        string Email { get; }

        string Password { get; }
    }
}
