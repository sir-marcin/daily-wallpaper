using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Wallpepper.Core.Provider;
using Wallpepper.Utils;

namespace Wallpepper.Storage
{
    public class LocalStorage
    {
        const string wallpapersFolder = "WallPEPPERs";
        
        EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, 100L);
        ImageCodecInfo codecInfo;
        bool wallpapersFolderAvailable;
        
        public string Path { get; private set; }

        public LocalStorage()
        {
            codecInfo = GetEncoderInfo("image/jpeg");

            if (!Directory.Exists(wallpapersFolder))
            {
                try
                {
                    Directory.CreateDirectory(wallpapersFolder);
                    wallpapersFolderAvailable = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not create wallpapers folder.");
                    Console.WriteLine(e.StackTrace);
                }
            }
            else
            {
                wallpapersFolderAvailable = true;
            }
        }
        
        public string SaveImage(Image image, ProviderMode providerMode)
        {
            string folder = wallpapersFolderAvailable ? wallpapersFolder : Directory.GetCurrentDirectory();
            
            Path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), folder, $"{DateUtils.Today()}_{providerMode}.jpg");

            var encoderParameters = new EncoderParameters(1)
            {
                Param = {[0] = encoderParameter}
            };

            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
            
            image.Save(Path, codecInfo, encoderParameters);

            return Path;
        }
        
        static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for(j = 0; j < encoders.Length; ++j)
            {
                if(encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}