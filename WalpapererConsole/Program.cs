using System;
using WallpapererConsole;
using WallpapererConsole.Bing;
using WallpapererConsole.Core;
using WallpapererConsole.Core.Provider;

namespace WalpapererConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WpStorage storage = new WpStorage();
            Config config = Config.TryLoadFromLocalStorage();
            
            WallpaperProvider provider = WallpaperProvider.GetProvider(config.WallpaperProviderMode);

            var image = provider.GetImage();

            if (image == null)
            {
                Console.WriteLine("Image has not been provided.");
                return;
            }
            
            storage.SaveImage(image);
            WallpaperSetter.Set(storage.Path);
        }
    }
}
