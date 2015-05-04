using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SteamCreator
{
    /// <summary>
    /// Check window with pixel
    /// </summary>
    class Pixel
    {




        /// <summary>
        /// Return Image from file
        /// </summary>
        /// <param name="fileName">path to file</param>
        /// <returns>Image</returns>
        public static Image LoadImage(string fileName)
        {
            var img = Image.FromFile(fileName);
            return img;
        }
        
    }


}
