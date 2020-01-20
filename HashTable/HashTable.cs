using System;
using System.Text;
using DataStructures;

namespace HashTable
{
    class HashTable  //hash table implementation for string values
    {
        private LinkedList<string>[] values;
        private int count;
        private int Size;

        public HashTable(int size)
        {
            count = 0;
            Size = size;
            values = new LinkedList<string>[size];
        }

        public void Add(string item)
        {
            int index = Hash(item);
            if (values[index] == null)
            {
                values[index] = new LinkedList<string>();
                values[index].Add(item);
            }
            else
            {
                values[index].Add(item);
            }
            count++;
        }

        public bool Search(string item)
        {
            int index = Hash(item);
            return values[index].Contains(item);
        }

        public void Remove(string item)
        {
            int index = Hash(item);
            values[index].Remove(item);
            count--;
        }

        public LinkedList<string>[] GetValues()
        {
            return values;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Size; i++)
            {
                str += $"->Hash Value: {i}";
                str += Environment.NewLine;
                if (values[i] != null)
                {
                    for (int j = 0; j < values[i].Count; j++)
                    {
                        str += $"    - {values[i].GetItemAt(j)}";
                        str += Environment.NewLine;
                    }
                    str += Environment.NewLine;
                }
                else
                {
                    str += Environment.NewLine;
                }
            }
            return str;
        }

        private int Hash(string item) //returns a hash code that can be used for the array indexer
        {
            int hash = 0;
            byte[] bytes = Encoding.UTF8.GetBytes(item);
            foreach (var b in bytes)
            {
                hash += b;
            }
            return hash % Size;
        }

        public double GetLoadFactor()
        {
            double lf = Convert.ToDouble(count) / Convert.ToDouble(Size);
            return lf * 100;
        }
    }
}
