using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCP_MOULDS
{
    public class colors
    {
        public string text { get; set; }
        public static List<colors> Getcolors()
        {
            List<colors> color = new List<colors>();
            color.Add(new colors { text = "AliceBlue" });
            color.Add(new colors { text = "AntiqueWhite" });
            color.Add(new colors { text = "Black" });
            color.Add(new colors { text = "Blue" });
            color.Add(new colors { text = "Brown" });
            color.Add(new colors { text = "Chocolate" });
            color.Add(new colors { text = "Cyan" });
            color.Add(new colors { text = "DarkBlue" });
            color.Add(new colors { text = "DarkGreen" });
            color.Add(new colors { text = "DarkRed" });
            color.Add(new colors { text = "ForestGreen" });
            color.Add(new colors { text = "Fuchsia" });
            color.Add(new colors { text = "LemonChiffon" });
            color.Add(new colors { text = "Lime" });
            color.Add(new colors { text = "Magenta" });
            color.Add(new colors { text = "Olive" });
            color.Add(new colors { text = "Orange" });
            color.Add(new colors { text = "OrangeRed" });
            color.Add(new colors { text = "Pink" });
            color.Add(new colors { text = "Purple" });
            color.Add(new colors { text = "PowderBlue" });
            color.Add(new colors { text = "Red" });
            color.Add(new colors { text = "RosyBrown" });
            color.Add(new colors { text = "RoyalBlue" });
            color.Add(new colors { text = "Silver" });
            color.Add(new colors { text = "SkyBlue" });
            color.Add(new colors { text = "SlateGray" });
            color.Add(new colors { text = "Tan" });
            color.Add(new colors { text = "Teal" });
            color.Add(new colors { text = "Turquoise" });
            color.Add(new colors { text = "Violet" });
            color.Add(new colors { text = "Wheat" });
            color.Add(new colors { text = "Yellow" });
            color.Add(new colors { text = "YellowGreen" });
            return color;
        }
    }
}