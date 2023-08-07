using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.StoragesContracts
{
    //интерфейс получения данных по всем сущностям
    public interface IBackUpInfo
    {
        //метод получения данных по всем сущностям
        List<T>? GetList<T>() where T : class, new();

        Type? GetTypeByModelInterface(string modelInterfaceName);
    }

}
