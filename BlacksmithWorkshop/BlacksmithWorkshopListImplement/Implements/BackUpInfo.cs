using BlacksmithWorkshopContracts.StoragesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Implements
{
    public class BackUpInfo : IBackUpInfo
    {
        public List<T>? GetList<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public Type? GetTypeByModelInterface(string modelInterfaceName)
        {
            throw new NotImplementedException();
        }
    }
}
