using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    public class Basics
    {
        /// <summary>
        /// As the name states it apply a filter function on each pixel of the image
        /// </summary>
        /// <param name="image"> The image to modify</param>
        /// <param name="filter"> The function to apply on each pixel</param>
        
        public static Bitmap ApplyFilter(Bitmap image, Func<Color, Color> filter)
        {
            for (int l = 0; l < image.Height; l++)
            {
                for (int h= 0; h < image.Width; h++)
                {
                    image.SetPixel(h,l,filter(image.GetPixel(h,l)));
                }

                
            }

            return image;
        }
        /// <summary>
        /// A Black and White filter
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color BlackAndWhite(Color color)
        {
            int colors = (color.B + color.R + color.G) / 3;
            if (colors > 127)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        /// <summary>
        /// A Yellow filter
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color Yellow(Color color)
        {
            int r = color.R;
            int b = color.B;
            int g = color.G;
            Color new_pixel_color = Color.FromArgb(r, b, 0);
            {
                return new_pixel_color;
            }
        }

        /// <summary>
        /// A Grayscale filter
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color Grayscale(Color color)
        {
            int r = color.R;
            int b = color.B;
            int g = color.G;
            int res = (int) (0.21 * r + 0.72 * g + 0.07 * b);
            Color new_pixel_color = Color.FromArgb(res, res, res);

            return new_pixel_color;
        }

        /// <summary>
        /// A Negative filter
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color Negative(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        /// <summary>
        /// Remove the maxes of the composants of the color
        /// </summary>
        /// <param name="color"> The color to modify </param>
        /// <returns> The new color</returns>
        public static Color RemoveMaxes(Color color)
        {
            int r = color.R;
            int b = color.B;
            int g = color.G;
            int maximum;

            if (g > b && g > r)
            {
                maximum = g;
            }

            if (r > g && r > b)
            {
                maximum = r;
            }
            else
            {
                maximum = b;
            }

            if (r == maximum)
            {
                r = 0;
            }

            if (g == maximum)
            {
                g = 0;
            }

            if (b == maximum)
            {
                b = 0;
            }

            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Create the new_image as if the image was seen in a mirror
        /// ....o.  =>  .o....
        /// ...o..  =>  ..o...
        /// ..o...  =>  ...o..
        /// .o....  =>  ....o.
        /// o.....  =>  .....o
        /// </summary>
        /// <param name="image"> The image to 'mirror'</param>
        /// <returns> The new image</returns>
        public static Bitmap Mirror(Bitmap image)
        {
            Bitmap mirror = new Bitmap(image);
            for (int i = 0; i < mirror.Height; i++)
            {
                for (int j = 0; j < mirror.Width; j++)
                {
                    Color new_pixel = image.GetPixel(j, i);
                    image.SetPixel(mirror.Width - j - 1,i,new_pixel);
                }
            }

            return mirror;
        }

        /// <summary>
        /// Apply a right rotation
        /// </summary>
        /// <param name="image"> The image to rotate</param>
        /// <returns> The new_image</returns>
        public static Bitmap RotateRight(Bitmap image)
        {
            Bitmap rotate = new Bitmap(image.Height,image.Width);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    rotate.SetPixel(rotate.Width-y-1,x,image.GetPixel(x,y));
                }
            }

            return rotate;
        }

        /// <summary>
        /// <!> Bonus <!>
        /// Rotate to the right n times
        /// </summary>
        /// <param name="image"> The image to rotate</param>
        /// <param name="n"> Number of rotation (n can be negative and thus must be handled properly)</param>
        /// <returns> The new_image</returns>
        public static Bitmap RotateN(Bitmap image, int n)
        {
            throw new NotImplementedException();
        }
    }
}
