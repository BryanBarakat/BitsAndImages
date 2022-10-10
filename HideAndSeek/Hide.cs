using System.Drawing;
using System;

namespace HideAndSeek
{
    public class Hide
    {

        /// <summary>
        /// Compress a value that was on 8 bits into a value on 'n' bits
        /// </summary>
        /// <param name="to_compress"> The value to compress</param>
        /// <param name="n"> On how many bits it must be compressed</param>
        /// <returns> The compressed value</returns>
        public static int CompressBits(int to_compress, int n)
        {
            return (to_compress * Bits.GetMaxForNBits(n) / Bits.GetMaxForNBits(8));
        }

        /// <summary>
        /// Hides the image 'to_hide' which is supposed to be a grayscale in the color 'where_to_hide'
        /// of the image 'image'
        /// </summary>
        /// <param name="image"> The image where you have to hide the image</param>
        /// <param name="to_hide"> The image to hide</param>
        /// <param name="where_to_hide"> In which of composant R, G or B you want to hide it</param>
        /// <param name="n"> The number of bits you want to hide</param>
        public static void HideGrayScale(Bitmap image, Bitmap to_hide, color_type where_to_hide, int n)
        {
            Bitmap new_image = new Bitmap(image.Width,image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int pixel_R = image.GetPixel(x, y).R;
                    int pixel_G = image.GetPixel(x, y).G;
                    int pixel_B = image.GetPixel(x, y).B;
                    if (where_to_hide == color_type.R)
                    {
                        Bits.SetLeastSignificantBits(ref pixel_R, CompressBits(to_hide.GetPixel(x, y).R, n), n);
                    }
                    else if (where_to_hide == color_type.G)
                    {
                        Bits.SetLeastSignificantBits(ref pixel_G, CompressBits(to_hide.GetPixel(x, y).G, n), n);
                    }
                    else
                    {
                        Bits.SetLeastSignificantBits(ref pixel_B, CompressBits(to_hide.GetPixel(x, y).B, n), n);
                    }
                    new_image.SetPixel(x, y, Color.FromArgb(pixel_R, pixel_G, pixel_B));
                }
            }
            image = new_image;
        }

        /// <summary>
        /// Hides the image 'to_hide' in the image 'image'
        /// Red color of 'to_hide' is hidden in Red color of image
        /// Green color of 'to_hide' is hidden in Green color of image
        /// And Blue color of 'to_hide' is hidden in Blue color of image
        /// </summary>
        /// <param name="image"> The image where you have to hide the image</param>
        /// <param name="to_hide"> The image to hide</param>
        /// <param name="n"> The number of bits you want to hide</param>
        public static void HideColor(Bitmap image, Bitmap to_hide, int n)
        {
            Bitmap new_image = new Bitmap(image.Width,image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    int pixel_B = image.GetPixel(x, y).B;
                    int pixel_G = image.GetPixel(x, y).G;
                    int pixel_R = image.GetPixel(x, y).R;
                    Bits.SetLeastSignificantBits(ref pixel_R, CompressBits(to_hide.GetPixel(x, y).R, n), n);
                    Bits.SetLeastSignificantBits(ref pixel_G, CompressBits(to_hide.GetPixel(x, y).G, n), n);
                    Bits.SetLeastSignificantBits(ref pixel_B, CompressBits(to_hide.GetPixel(x, y).B, n), n);
                    new_image.SetPixel(x, y, Color.FromArgb(pixel_R, pixel_G, pixel_B));
                }
            }
            image = new_image;
        }
    }
}
