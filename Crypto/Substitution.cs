using System;
using System.Collections.Generic;
using System.Linq;

namespace Crypto
{
    public class Substitution
    {
        public static Dictionary<string, char> Morse = Utils.Morse;
        
        public static string Morse_decode(string message)
        {
            string s = "";
            string[] msgsplit = message.Split();
            foreach (string msgs in msgsplit)
            {
                if (Morse.ContainsKey(msgs))
                {
                    s += Morse[msgs];
                }
                else
                {
                    return null;
                }
            }

            return s;
        }
        
        public static string Morse_encode(string message)
        {
            string s = "";
            foreach (char letter in message)
            {
                bool res = false;
                foreach (KeyValuePair<string, char> alph in Morse)
                {
                    if (alph.Value == letter)
                    {
                        s += alph.Key + " ";
                        res = true;
                    }
                } 
                if (res == false)
                {
                    return null;
                }
            }

            return s;
        }
    }
}