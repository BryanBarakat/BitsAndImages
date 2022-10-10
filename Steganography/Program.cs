using System;
using System.Drawing;

namespace Steganography
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap image = Utils.OpenImage("");

            string secret ="";

            Embed.EmbedMsg(Utils.TextToBin(secret), image);

            Console.WriteLine(Utils.BinToText(Exctract.ExtractMsg(image, 42)));

            Utils.SaveImage("", image);
        }
    }
}