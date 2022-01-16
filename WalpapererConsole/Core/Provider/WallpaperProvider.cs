using System;
using System.Drawing;

namespace Wallpepper.Core.Provider
{
    public abstract class WallpaperProvider
    {
        public abstract Image GetImage();

        public static WallpaperProvider GetProvider(ProviderMode mode)
        {
            switch (mode)
            {
                case ProviderMode.Bing:
                    return new BingWallpaperProvider();
                case ProviderMode.DailyLockscreen:
                    return new DailyWallpaperProvider();
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}