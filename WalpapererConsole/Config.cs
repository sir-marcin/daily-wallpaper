using System;
using System.IO;
using Newtonsoft.Json;
using Wallpepper.Core.Provider;

namespace Wallpepper
{
    public class Config
    {
        public ProviderMode WallpaperProviderMode { get; set; }
        public string CustomSourceUrl { get; set; }
        public bool KeepOldWallpapers { get; set; }

        const string configFileName = "config.json";

        static Config defaultConfig => new Config()
        {
            WallpaperProviderMode = ProviderMode.Bing,
            CustomSourceUrl = string.Empty,
            KeepOldWallpapers = false
        };
        
        public static Config TryLoadFromLocalStorage()
        {
            if (!File.Exists(configFileName))
            {
                try
                {
                    File.WriteAllText(configFileName, JsonConvert.SerializeObject(defaultConfig));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not save config.");
                    Console.WriteLine(e.StackTrace);
                }

                return defaultConfig;
            }

            Config config;
            
            try
            {
                var fileContent = File.ReadAllText(configFileName);
                Console.WriteLine($"Config content: {fileContent}");
                config = JsonConvert.DeserializeObject<Config>(fileContent);
                Console.WriteLine($"Deserialized content: {config}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not load saved config.");
                Console.WriteLine(e);
                
                return defaultConfig;
            }

            return config;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}