using BlacksmithWorkshopContracts.DI;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopDatabaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement
{
    public class DataBaseImplementationExtension : IImplementationExtension
    {
        public int Priority => 2;

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
