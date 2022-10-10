using System;
using System.Collections.Generic;

namespace Crypto
{
    public class Transposition
    {
        public static int[] Permutation_rule(string key)
        {
            key = key.ToUpper();
            int[] tot = new int[key.Length];
            int ind = 1;
            for (int i = 65; i < 91; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == (char) i)
                    {
                        tot[j] = ind;
                        ind += 1;
                    }
                }
            }

            return tot;
        }

        public static char[,] Create_table_encrypt(string message, string key, int size)
        {
            char[,] tot = new char[size, key.Length];
            int ind = 0;
            foreach (char c in message)
            {
                if (c != ' ')
                {
                    tot[ind / key.Length, ind % key.Length] = c;
                    ind += 1;
                }
            }

            return tot;
        }
        

        public static string Permutation_encrypt(string message, string key)
        {
            string tot = "";
            char[,] table = Create_table_encrypt(message, key, message.Length / key.Length);

            int[] rule = Permutation_rule(key);

            foreach (int i in rule)
            {
                for (int j = 0; j < (message.Length / key.Length); j++)
                {
                    tot += table[j, rule.Length - i];
                }

                tot += " ";
            }

            return tot;
        }

        public static char[,] Create_table_decrypt(string message, string key, int size)
        {
            message.ToUpper();
            key.ToUpper();
            int[] rule = Permutation_rule(key);
            char[,] tot = new char[size, key.Length];
            int ind = 0;
            foreach (char c in message)
            {
                tot[ind % size, rule.Length - rule[ind / size]] = c;
                ind += 1;
            }

            return tot;
        }

        public static string Permutation_decrypt(string message, string key)
        {
            string tot = "";
            char[,] mat = Transposition.Create_table_decrypt(message, key, message.Length / key.Length);
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    tot += (mat[i, j]);
                }
            }

            return tot;
        }
    }
}
