using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WallpapererConsole.Bing
{
    public class WpStorage
    {
        const string fileName = "bing-wp.jpg";
        
        EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, 100L);
        ImageCodecInfo codecInfo;
        
        public string Path { get; private set; }

        public WpStorage()
        {
            codecInfo = GetEncoderInfo("image/jpeg");
        }
        
        public string SaveImage(Image image)
        {
            string folder = Directory.GetCurrentDirectory();
            
            Path = System.IO.Path.Combine(folder, fileName);
            
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = encoderParameter;
            
            image.Save(Path, codecInfo, encoderParameters);

            return Path;
        }
        
        static ImageCodecInfo GetEncoderInfo(String mimeType)
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