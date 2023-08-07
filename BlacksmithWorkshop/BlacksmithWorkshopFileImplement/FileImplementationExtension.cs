using BlacksmithWorkshopContracts.DI;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopFileImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement
{
    //для реализации нужных нам зависимостей в данном варианте хранения информации
    public class FileImplementationExtension : IImplementationExtension
    {
        public int Priority => 1;

        public void RegisterServices()
        {
            DependencyManager.Instance.RegisterType<IClientStorage, ClientStorage>();

            DependencyManager.Instance.RegisterType<IWorkPieceStorage, WorkPieceStorage>();

            DependencyManager.Instance.RegisterType<IImplementerStorage, ImplementerStorage>();

            DependencyManager.Instance.RegisterType<IMessageInfoStorage, MessageInfoStorage>();

            DependencyManager.Instance.RegisterType<IOrderStorage, OrderStorage>();

            DependencyManager.Instance.RegisterType<IManufactureStorage, ManufactureStorage>();

			DependencyManager.Instance.RegisterType<IShopStorage, ShopStorage>();

			DependencyManager.Instance.RegisterType<IBackUpInfo, BackUpInfo>();
        }
    }
}
