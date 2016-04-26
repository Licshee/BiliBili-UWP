using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilibili2.Class
{
    class Converter
    {
        public static string ConvertToPlatform(int number)
        {
            switch (number)
            {
                case 2:
                    return "来自 Android";
                case 3:
                    return "来自 IOS";
                case 4:
                    return "来自 WindowsPhone";
                case 6:
                    return "来自 Windows";
                default:
                    return "";
            }
        }

        public static string ConvertToDate(long ticks)
        {
            return (new DateTime(1970, 1, 1) + new TimeSpan(ticks)).ToString();
        }

        public static string ConvertToLvPic(int lv)
        {
            switch (lv)
            {
                case 0:
                    return "ms-appx:///Assets/MiniIcon/ic_lv0_large.png";
                case 1:
                    return "ms-appx:///Assets/MiniIcon/ic_lv1_large.png";
                case 2:
                    return "ms-appx:///Assets/MiniIcon/ic_lv2_large.png";
                case 3:
                    return "ms-appx:///Assets/MiniIcon/ic_lv3_large.png";
                case 4:
                    return "ms-appx:///Assets/MiniIcon/ic_lv4_large.png";
                case 5:
                    return "ms-appx:///Assets/MiniIcon/ic_lv5_large.png";
                case 6:
                    return "ms-appx:///Assets/MiniIcon/ic_lv6_large.png";
                default:
                    return "";
            }
        }
    }
}
