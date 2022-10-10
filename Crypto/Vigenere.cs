using System;
using System.IO.Compression;

namespace Crypto
{
    public class Vigenere
    {
        public static string Vigenere_encode(string msg, string key)
        {
            int i = 0;
            int j = 0;
            string s = "";
            int k = key.Length;
            key = key.ToLower();
            foreach (char c in msg) 
            {
                if (c != ' ')
                {
                    if (Char.IsUpper(c))
                    {
                        key = key.ToUpper();
                        j = (c + key[i % k] -65);
                        while (j>90)
                        {
                            j -= 26;
                        }
                        while (j<65)
                        {
                            j += 26;
                        }
                        i++;

                    }
                    else
                    {
                        j = (c + key[i % k] - 65);
                        while (j > 122)
                        {
                            j -= 26;
                        }
                        while (j < 97)
                        {
                            j += 26;
                        } 
                        i++;
                    }
                    s += ((char) j).ToString();
                }
                else
                {
                    s += " ";
                }
            }
            return s.ToUpper();
        }

        public static string Vigenere_decode(string msg, string key)
        {          
            int i = 0;
            int j = 0;
            string s = "";
            int k = key.Length;
            key = key.ToLower();
            foreach (char c in msg) 
            {
                if (c != ' ')
                {
                    if (Char.IsUpper(c))
                    {
                        key = key.ToUpper();
                        j = (c - key[i % k] -65);
                        while (j>90)
                        {
                            j -= 26;
                        }
                        while (j<65)
                        {
                            j += 26;
                        }
                        i++;

                    }
                    else
                    {
                        j = (c - key[i % k] - 65);
                        while (j > 122)
                        {
                            j -= 26;
                        }
                        while (j < 97)
                        {
                            j += 26;
                        } 
                        i++;
                    }
                    s += ((char) j).ToString();
                }
                else
                {
                    s += " ";
                }
            }
            return s;
        }
    }
}