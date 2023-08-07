using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.DI
{

    //Интерфейс для регистрации зависимостей в модулях
    public interface IImplementationExtension
    {
        //для установления приоритета
        public int Priority { get; }

        //Регистрация сервисов
        public void RegisterServices();
    }

}
