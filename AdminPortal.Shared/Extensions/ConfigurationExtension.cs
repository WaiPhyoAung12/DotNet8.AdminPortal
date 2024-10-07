using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.Shared.Extensions
{
    public static class ConfigurationExtension
    {
        public static IConfiguration AddStageConfig(this IConfigurationBuilder configurationBuilder, string contentRootPath)
        {
            IConfiguration configuration = (IConfiguration)configurationBuilder;
            var stage = configuration.GetSection("Stage")!.Value;
            string jsonFilePath = Path.Combine(contentRootPath, "..", "Config", $"custom-setting-{stage}.json");

            Console.WriteLine("Custom Setting Json Files Path: " + jsonFilePath);
            configurationBuilder.AddJsonFile(jsonFilePath, optional: false, reloadOnChange: true);
            return configurationBuilder.Build();
        }
    }
}
