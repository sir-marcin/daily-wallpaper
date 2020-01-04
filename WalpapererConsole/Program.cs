using System;
using Wallpepper.Core;
using Wallpepper.Core.Provider;
using Wallpepper.Storage;

namespace Wallpepper
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalStorage localStorage = new LocalStorage();
            Config config = Config.TryLoadFromLocalStorage();
            
            Console.WriteLine($"Config: {config}");
            
            WallpaperProvider provider = WallpaperProvider.GetProvider(config.WallpaperProviderMode);

            var image = provider.GetImage();

            if (image == null)
            {
                Console.WriteLine("Image has not been provided.");
                return;
            }
            
            string imagePath = localStorage.SaveImage(image, config.WallpaperProviderMode);
            WallpaperSetter.Set(imagePath);
            Console.WriteLine($"Saved at {imagePath}");
        }
    }
}
