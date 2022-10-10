using System;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Transposition.Create_table_encrypt("ENCRYPTION ALGORITHMS","GOAL",5));
        }
    }
}