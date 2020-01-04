using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace WallpapererConsole.Bing
{
    public class DailyWallpaperProvider : WallpaperProvider
    {
        const string imagesPath = @"Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
        
        public override Image GetImage()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var localPath = Path.Combine(appDataPath, imagesPath);
            
            var files = Directory.GetFiles(localPath);
            var filesWithDates = new Dictionary<string, DateTime>();
            
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                filesWithDates.Add(file, fileInfo.CreationTime);
            }

            var ordered = filesWithDates.OrderByDescending(f => f.Value).Take(2);

            foreach (var imageData in ordered)
            {
                var path = $"{imageData.Key}";
                var image = Image.FromFile(path);

                var size = image.Size;

                if (size.Width > size.Height)
                {
                    // dimensions are good
                    return image;
                }
            }

            return null;
        }
    }
}