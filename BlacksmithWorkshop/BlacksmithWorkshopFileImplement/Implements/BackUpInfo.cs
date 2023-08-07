using BlacksmithWorkshopContracts.StoragesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement.Implements
{
    public class BackUpInfo : IBackUpInfo
    {
        public List<T>? GetList<T>() where T : class, new()
        {
            var source = DataFileSingleton.GetInstance();

            return (List<T>?)source.GetType().GetProperties()
                .FirstOrDefault(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericArguments()[0] == typeof(T))
                ?.GetValue(source);
        }

        public Type? GetTypeByModelInterface(string modelInterfaceName)
        {
            var assembly = typeof(BackUpInfo).Assembly;
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.IsClass && type.GetInterface(modelInterfaceName) != null)
                {
                    return type;
                }
            }

            return null;
        }
    }
}
