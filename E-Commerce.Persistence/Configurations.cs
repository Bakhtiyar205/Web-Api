using System;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.Persistence
{
	public static class Configurations
	{
		public static string ConnectionString
		{
			get
			{
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/E-Commerce.Api"));
                configurationManager.AddJsonFile("appsettings.json");

				return configurationManager.GetConnectionString("SqlServer")!;
            }
		}
	}
}

