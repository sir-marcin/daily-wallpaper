using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpapererConsole.Bing
{
    class WpData
    {
        public List<WpImageData> Images { get; set; }
        public WpTooltipData WpTooltipData { get; set; }
    }

    class WpImageData
    {
        public string Startdate { get; set; }
        public string Fullstartdate { get; set; }
        public string Enddate { get; set; }
        public string Url { get; set; }
        public string Urlbase { get; set; }
        public string Copyright { get; set; }
        public string Copyrightlink { get; set; }
        public string Title { get; set; }
        public string Quiz { get; set; }
        public bool Wp { get; set; }
        public string Hsh { get; set; }
        public int Drk { get; set; }
        public int Top { get; set; }
        public int Bot { get; set; }
        public List<object> Hs { get; set; }
    }

    class WpTooltipData
    {
        public string Loading { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
        public string Walle { get; set; }
        public string Walls { get; set; }
    }
}
