using System;
using System.Drawing;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HideAndSeek
{
    public enum color_type
    {
        R = 0,
        G,
        B,
    }
    public class Seek
    {

        /// <summary>
        /// Decompress a value that was on 'n' bits to a value on 8 bits
        /// </summary>
        /// <param name="to_decompress"> The value to decompress</param>
        /// <param name="n"> On how many bits it has been compressed</param>
        /// <returns> The decompressed value</returns>
        public static int DecompressBits(int to_decompress, int n)
        {
            return ((to_decompress * Bits.GetMaxForNBits(8)) / Bits.GetMaxForNBits(n));
        }

        /// <summary>
        /// Seek a new image in the Bitmap image and in the color 'where_is_hidden' on 'n' bits
        /// </summary>
        /// <param name="image"> The image where it is hidden</param>
        /// <param name="where_is_hidden"> In which color it is hidden</param>
        /// <param name="n"> On how many bits it is hidden</param>
        /// <returns> The image found</returns>
        public static Bitmap SeekGrayScale(Bitmap image, color_type where_is_hidden, int n)
        {
            Color pixel_new_color;
            int dec_pixel;
            int hidden;
            Bitmap new_image = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (where_is_hidden == color_type.R)
                    {
                        hidden = Bits.GetLeastSignificantBits(image.GetPixel(x, y).R, n);
                        dec_pixel = DecompressBits(hidden, n);
                    }
                    else if (where_is_hidden == color_type.G)
                    {
                        hidden = Bits.GetLeastSignificantBits(image.GetPixel(x, y).G, n);
                        dec_pixel = DecompressBits(hidden, n);
                    }
                    else
                    {
                        hidden = Bits.GetLeastSignificantBits(image.GetPixel(x, y).B, n);
                        dec_pixel = DecompressBits(hidden, n);
                    }

                    pixel_new_color = Color.FromArgb(dec_pixel, dec_pixel, dec_pixel);
                    new_image.SetPixel(x, y, pixel_new_color);
                }
            }

            return new_image;
        }

        /// <summary>
        /// Seek a new image in the Bitmap image on 'n' bits
        /// </summary>
        /// <param name="image"> The image where it is hidden</param>
        /// <param name="n"> On how many bits it is hidden</param>
        /// <returns> The image found</returns>
        public static Bitmap SeekColor(Bitmap image, int n)
        {
            Color new_pixel_color;
            int Dec_R;
            int HiddenR;
            int Dec_G;
            int HiddenG;
            int Dec_B;
            int HiddenB;
            Bitmap new_image = new Bitmap(image.Width,image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    HiddenR = Bits.GetLeastSignificantBits(image.GetPixel(x, y).R,n);
                    Dec_R = DecompressBits(HiddenR,n);
                    HiddenG = Bits.GetLeastSignificantBits(image.GetPixel(x, y).G,n);
                    Dec_G = DecompressBits(HiddenG,n);
                    HiddenB = Bits.GetLeastSignificantBits(image.GetPixel(x, y).B,n);
                    Dec_B = DecompressBits(HiddenB,n);

                    new_pixel_color = Color.FromArgb(Dec_R, Dec_G, Dec_B);

                    new_image.SetPixel(x, y, new_pixel_color);
                }
            }

            return new_image;
        }
    }
}
