using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.DI
{
    /// <summary>
    /// Менеджер для работы с зависимостями
    /// </summary>
    public class DependencyManager
    {
        private readonly IDependencyContainer _dependencyManager;

        private static DependencyManager? _manager;

        private static readonly object _locjObject = new();

        private DependencyManager()
        {
            _dependencyManager = new UnityDependencyContainer();
        }

        public static DependencyManager Instance
        {
            get
            {
                if (_manager == null) { lock (_locjObject) { _manager = new DependencyManager(); } }
                
                return _manager;
            }
        }

        //Иницализация библиотек, в которых идут установки зависомстей
        public static void InitDependency()
        {
            var ext = ServiceProviderLoader.GetImplementationExtensions();

            if (ext == null)
            {
                throw new ArgumentNullException("Отсутствуют компоненты для загрузки зависимостей по модулям");
            }

            //регистрируем зависимости хранилищ
            ext.RegisterServices();

			var extBusiness = ServiceProviderLoader.GetBusinessLogicImplementationExtensions();

			if (extBusiness == null)
			{
				throw new ArgumentNullException("Отсутствуют компоненты для загрузки зависимостей по модулям");
			}

			//регистрируем зависимости бизнес-логики
			extBusiness.RegisterServices();
		}

        //Регистрация логгера
        public void AddLogging(Action<ILoggingBuilder> configure) => _dependencyManager.AddLogging(configure);

        //Добавление зависимости
        public void RegisterType<T, U>(bool isSingle = false) where U : class, T where T : class => _dependencyManager.RegisterType<T, U>(isSingle);

        //Добавление зависимости
        public void RegisterType<T>(bool isSingle = false) where T : class => _dependencyManager.RegisterType<T>(isSingle);

        //Получение класса со всеми зависмостями
        public T Resolve<T>() => _dependencyManager.Resolve<T>();
    }

}
