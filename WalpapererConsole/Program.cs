using System;
using WallpapererConsole;
using WallpapererConsole.Bing;

namespace WalpapererConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WpStorage storage = new WpStorage();
            WallpaperProvider provider = WallpaperProvider.GetProvider(ProviderMode.DailyLockscreen);

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
