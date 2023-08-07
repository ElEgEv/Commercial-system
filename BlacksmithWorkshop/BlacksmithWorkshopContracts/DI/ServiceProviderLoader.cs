using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.DI
{
    //Загрузчик данных
    public static partial class ServiceProviderLoader
    {
        //Загрузка всех классов-реализаций IImplementationExtension
        public static IImplementationExtension? GetImplementationExtensions()
        {
            IImplementationExtension? source = null;

            var files = Directory.GetFiles(TryGetImplementationExtensionsFolder(), "*.dll", SearchOption.AllDirectories);
            
            foreach (var file in files.Distinct())
            {
                Assembly asm = Assembly.LoadFrom(file);

                foreach (var t in asm.GetExportedTypes())
                {
                    if (t.IsClass && typeof(IImplementationExtension).IsAssignableFrom(t))
                    {
                        if (source == null)
                        {
                            source = (IImplementationExtension)Activator.CreateInstance(t)!;
                        }
                        else
                        {
                            var newSource = (IImplementationExtension)Activator.CreateInstance(t)!;
                            
                            if (newSource.Priority > source.Priority)
                            {
                                source = newSource;
                            }
                        }
                    }
                }
            }

            return source;
        }

        private static string TryGetImplementationExtensionsFolder()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            
            while (directory != null && !directory.GetDirectories("ImplementationExtensions", 
                SearchOption.AllDirectories).Any(x => x.Name == "ImplementationExtensions"))
            {
                directory = directory.Parent;
            }

            return $"{directory?.FullName}\\ImplementationExtensions";
        }

		public static IBusinessLogicImplementationExtension? GetBusinessLogicImplementationExtensions()
		{
			IBusinessLogicImplementationExtension? source = null;

			var files = Directory.GetFiles(TryGetBusinessLogicImplementationExtensionsFolder(), "*.dll", SearchOption.AllDirectories);
			
            foreach (var file in files.Distinct())
			{
				Assembly asm = Assembly.LoadFrom(file);

				foreach (var t in asm.GetExportedTypes())
				{
					if (t.IsClass && typeof(IBusinessLogicImplementationExtension).IsAssignableFrom(t))
					{
						if (source == null)
						{
							source = (IBusinessLogicImplementationExtension)Activator.CreateInstance(t)!;
						}
						else
						{
							var newSource = (IBusinessLogicImplementationExtension)Activator.CreateInstance(t)!;
							
                            if (newSource.Priority > source.Priority)
							{
								source = newSource;
							}
						}
					}
				}
			}

			return source;
		}

		private static string TryGetBusinessLogicImplementationExtensionsFolder()
		{
			var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
			
            while (directory != null && !directory.GetDirectories("BusinessLogicImplementationExtensions", SearchOption.AllDirectories).Any(x => x.Name == "BusinessLogicImplementationExtensions"))
			{
				directory = directory.Parent;
			}

			return $"{directory?.FullName}\\BusinessLogicImplementationExtensions";
		}
	}
}
