using System;
using System.Configuration;
using System.Collections.Specialized;
using waifu2X_ncnn_gui;

namespace waifu2x_ncnn_gui
{
    class ConfigHandler
    {
        public static string GetWaifu2xLocation()
        {
            string Waifu2xLocation;

            Waifu2xLocation = ConfigurationManager.AppSettings["waifu2xloc"];

            if(string.IsNullOrEmpty(Waifu2xLocation))
            {
                Waifu2xLocation = "Location not set.";
            }

            return Waifu2xLocation;
        }

        public static void SetWaifu2xLocation(string loc)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["waifu2xloc"].Value = loc;
            config.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
