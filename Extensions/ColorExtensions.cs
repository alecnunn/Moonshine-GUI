using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonshine.gui.Extensions
{
    public static class ColorExtensions
    {
        public static Color FromArgb (int a, int r, int g, int b)
        {
            return Color.FromNonPremultiplied (r, g, b, a);
        }

        public static Color FromRgbString (string str)
        {
            int r = 0, g = 0, b = 0;
            if (str.Count ((c) => c == ',') == 2)
            {
                string[] parts = str.Split (new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 3)
                {
                    if (!int.TryParse (parts[0], out r))
                        return FromArgb (255, 0, 0, 0);
                    if (!int.TryParse (parts[1], out g))
                        return FromArgb (255, 0, 0, 0);
                    if (!int.TryParse (parts[2], out b))
                        return FromArgb (255, 0, 0, 0);
                    return FromArgb (255, r, g, b);
                }
            }
            return FromArgb (255, 0, 0, 0);
        }

        public static Color FromRgbaString (string str)
        {
            int r = 0, g = 0, b = 0, a = 0;
            if (str.Count ((c) => c == ',') == 3)
            {
                string[] parts = str.Split (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 4)
                {
                    if (!int.TryParse (parts[0], out r))
                        return FromArgb (255, 0, 0, 0);
                    if (!int.TryParse (parts[1], out g))
                        return FromArgb (255, 0, 0, 0);
                    if (!int.TryParse (parts[2], out b))
                        return FromArgb (255, 0, 0, 0);
                    if (!int.TryParse (parts[3], out a))
                        return FromArgb (255, 0, 0, 0);
                    return FromArgb (a, r, g, b);
                }
            }
            return FromArgb (255, 0, 0, 0);
        }
    }
}
