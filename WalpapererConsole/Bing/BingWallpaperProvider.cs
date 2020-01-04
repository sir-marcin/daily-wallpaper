using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using WallpapererConsole.Bing;

namespace WallpapererConsole
{
    class BingWallpaperProvider : WallpaperProvider
    {
        const string baseUrl = "https://bing.com";
        
        WpData wallpaperData;
        Image fetchedImage;

        public override Image GetImage()
        {
            FetchWpData();

            return fetchedImage;
        }
        
        void FetchWpData()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(@"https://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US").Result;

                Console.WriteLine("Response received");
                
                wallpaperData = JsonConvert.DeserializeObject<WpData>(response);

                var url = $"{baseUrl}{wallpaperData.Images[0].Url}";

                var imageStream = client.GetStreamAsync(url).Result;

                fetchedImage = Image.FromStream(imageStream);
            }
        }
    }
}
