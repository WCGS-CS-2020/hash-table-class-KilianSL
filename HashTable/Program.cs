using System;

namespace HashTable
{
    class program
    {
        static void Main(string[] args)
        {
            HashTable hash = new HashTable(17);
            string[] testStrings = new string[] { "a", "b", "asd2", "adethte", "tjyrth", "234", "ergfb", "afeg", "qwfqw", "343rwgv", "nnmbf" };
            foreach (var item in testStrings)
            {
                hash.Add(item);
            }
            Console.WriteLine(hash.ToString());
            hash.Remove("a");
            hash.Remove("b");
            Console.WriteLine(hash.ToString());
            Console.WriteLine(hash.Search("asd2"));
            Console.WriteLine(hash.GetLoadFactor() + "%");
        }
    }
}
