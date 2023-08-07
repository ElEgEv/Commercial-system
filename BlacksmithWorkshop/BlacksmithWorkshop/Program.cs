using BlacksmithWorkshopBusinessLogic.BusinessLogic;
using BlacksmithWorkshopBusinessLogic.OfficePackage.Implements;
using BlacksmithWorkshopBusinessLogic.OfficePackage;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.DI;
using BlacksmithWorkshopContracts.StoragesContracts;
using BlacksmithWorkshopDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using BlacksmithWorkshopBusinessLogic.MailWorker;
using BlacksmithWorkshopContracts.BindingModels;

namespace BlacksmithWorkshop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font;
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            InitDependency();

            try
			{
                var mailSender = DependencyManager.Instance.Resolve<AbstractMailWorker>();
                mailSender?.MailConfig(new MailConfigBindingModel
				{
					MailLogin = System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ?? string.Empty,
					MailPassword = System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ?? string.Empty,
					SmtpClientHost = System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ?? string.Empty,
					SmtpClientPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
				    PopHost = System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
				    PopPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
				});

				// создаем таймер
				var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
			}
			catch (Exception ex)
			{
				var logger = DependencyManager.Instance.Resolve<ILogger>();

                logger?.LogError(ex, "Ошибка работы с почтой");
			}


            Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }

        private static void InitDependency()
        {
            DependencyManager.InitDependency();

            DependencyManager.Instance.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });

            DependencyManager.Instance.RegisterType<FormMain>();
            DependencyManager.Instance.RegisterType<FormWorkPiece>();
            DependencyManager.Instance.RegisterType<FormWorkPieces>();
            DependencyManager.Instance.RegisterType<FormCreateOrder>();
            DependencyManager.Instance.RegisterType<FormManufacture>();
            DependencyManager.Instance.RegisterType<FormManufactureWorkPiece>();
            DependencyManager.Instance.RegisterType<FormManufactures>();
            DependencyManager.Instance.RegisterType<FormReportManufactureWorkPieces>();
            DependencyManager.Instance.RegisterType<FormReportOrders>();
            DependencyManager.Instance.RegisterType<FormClients>();
            DependencyManager.Instance.RegisterType<FormImplementer>();
            DependencyManager.Instance.RegisterType<FormImplementers>();
            DependencyManager.Instance.RegisterType<FormMails>();
			DependencyManager.Instance.RegisterType<FormAnswerMail>();
			DependencyManager.Instance.RegisterType<FormMails>();
			DependencyManager.Instance.RegisterType<FormSellManufacture>();
			DependencyManager.Instance.RegisterType<FormReportGroupedOrders>();
			DependencyManager.Instance.RegisterType<FormReportShopManufactures>();
			DependencyManager.Instance.RegisterType<FormShops>();
			DependencyManager.Instance.RegisterType<FormShop>();
		}

        private static void MailCheck(object obj) => DependencyManager.Instance.Resolve<AbstractMailWorker>()?.MailCheck();
    }
}