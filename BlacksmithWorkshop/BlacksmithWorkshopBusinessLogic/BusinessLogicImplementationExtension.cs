using BlacksmithWorkshopBusinessLogic.BusinessLogic;
using BlacksmithWorkshopBusinessLogic.MailWorker;
using BlacksmithWorkshopBusinessLogic.OfficePackage.Implements;
using BlacksmithWorkshopBusinessLogic.OfficePackage;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic
{
	public class BusinessLogicImplementationExtension : IBusinessLogicImplementationExtension
	{
		public int Priority => 0;

		public void RegisterServices()
		{
			DependencyManager.Instance.RegisterType<IWorkPieceLogic, WorkPieceLogic>();
			DependencyManager.Instance.RegisterType<IOrderLogic, OrderLogic>();
			DependencyManager.Instance.RegisterType<IManufactureLogic, ManufactureLogic>();
			DependencyManager.Instance.RegisterType<IReportLogic, ReportLogic>();
			DependencyManager.Instance.RegisterType<IClientLogic, ClientLogic>();
			DependencyManager.Instance.RegisterType<IImplementerLogic, ImplementerLogic>();
			DependencyManager.Instance.RegisterType<IMessageInfoLogic, MessageInfoLogic>();
			DependencyManager.Instance.RegisterType<IShopLogic, ShopLogic>();

			DependencyManager.Instance.RegisterType<AbstractSaveToExcel, SaveToExcel>();
			DependencyManager.Instance.RegisterType<AbstractSaveToWord, SaveToWord>();
			DependencyManager.Instance.RegisterType<AbstractSaveToPdf, SaveToPdf>();

			DependencyManager.Instance.RegisterType<IWorkProcess, WorkModeling>();
			DependencyManager.Instance.RegisterType<AbstractMailWorker, MailKitWorker>(true);

			DependencyManager.Instance.RegisterType<IBackUpLogic, BackUpLogic>();
		}
	}
}
