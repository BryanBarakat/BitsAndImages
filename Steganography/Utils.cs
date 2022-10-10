using System;
using System.Collections.Generic;
using System.Drawing;

namespace Steganography
{
    public class Utils
    {
        // This Quantization table is used to determine the number of bits to use to hide a message in a pixel.
        static public Dictionary<int[] , int> QuantizationTable = new Dictionary<int[], int>()
        {
            { new int[] {0, 1}, 1},
            { new int[] {2, 32}, 2},
            { new int[] {33, 64}, 3},
            { new int[] {65, 255}, 4}
        };

        // This function converts a string into an array of bits.
        public static int[] TextToBin(string secret)
        {
            int[] outp = new int[secret.Length*8];
            string d;
            int ind = 0;
            foreach (char c in secret)
            {
                d = Convert.ToString(c, 2);
                d = new String('0', 8-d.Length) + d;
                for (int i = 0; i < 8; i++)
                {
                    outp[ind] = Int32.Parse(d[i].ToString());
                    ind++;
                }
            }
            return outp;
        }

        // This function converts an array of bits into a string.
        // We consider that the array length is a multiple of 8.
        public static string BinToText(int[] bin)
        {
            string outp = "";
            string s = "";
            for (int i = 0; i < bin.Length/8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    s += bin[i*8+j];
                }
                outp += (char)Convert.ToInt32(s, 2);
                s = "";
            }
            return outp;
        }

        // This function extract the nbBits bits beginning from the index position from the secret array.
        // It is also converting the binary result into decimal.
        public static int ExtractBits(int[] secret, int index, int nbBits)
        {
            string d = "";
            for (int i = 0; i < secret.Length; i++)
            {
                d += secret[i].ToString();
            }
            d += new String('0', nbBits);
            return Convert.ToInt32(d.Substring(index, nbBits), 2);
        }

        // This function translates the int value (in decimal) into binary in the secret array.
        public static void InsertBits(int[] secret, int index, int nbBits, int value)
        {
            throw new NotImplementedException();
        }

        // Assuming we already have grey pixels (R = G = B).
        // This is | pixel1.R - pixel2.R |.
        public static int GetDifference(Color pixel1, Color pixel2)
        {
            return (pixel1.R - pixel2.R);
        }

        
        // This function opens an image.
        public static Bitmap OpenImage(string path)
        {
            return new Bitmap(path);
        }

        // This function saves the image into the file 'name'.
        public static void SaveImage(string name, Bitmap image)
        {
            image.Save(name);
            image.Dispose();
        }
        
        // This function clears the nbBits LSB of the int color.
        public static int ClearLSB(int color, int nbBits)
        {
            if (color <= 0)
                return color;
            color >>= nbBits;
            color <<= nbBits;
            return color;
        }
        
        // This function replaces the nbBits LSB by newLSB.
        public static int ReplaceLSB(int color, int nbBits, int newLSB)
        {
            color = ClearLSB(color, nbBits);

            return color + newLSB;
        }
        
        // This function saves ONLY the nbBits LSB of the int color.
        public static int SaveLSB(int color, int nbBits)
        {
            if (color <= 0)
                return color;
            color <<= 8 - nbBits;
            color %= 256;
            color >>= 8 - nbBits;
            return color;
        }
    }
}