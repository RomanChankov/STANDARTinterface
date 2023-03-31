using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson19032023
{
    interface IIndexer
    {
        string this[int index]
        {
            get;
            set;
        }
        string this[string index] 
        {
            get;
        } 
    }
    enum Numbers { one, two, three,four,five };
    class IndexerClass :IIndexer
    {
        string[]_names=new string[5];
        public string this[int index]
        {
            get
            {
                return _names[index];
            }
            set
            {
                _names[index] = value;
            }
        }
        public string this[string index]
        {
            get
            {
                if (Enum.IsDefined(typeof(Numbers), index))
                    return _names[(int)Enum.Parse(typeof(Numbers), index)];
                else
                    return "";
            }
        }
        public IndexerClass()
        {
            this[0] = "Bob";
            this[1] = "Candice";
            this[2] = "Jimmy";
            this[3] = "Joey";
            this[4] = "Nicole";
        }
    }
    internal class INTERFACESpropANDindex
    {
        static void Main(string[] args)
        {
           IndexerClass indexerClass = new IndexerClass();
            WriteLine("\t\tВывод значений\n");
            WriteLine("Использование индексатора с целочисленным параметром:");
            for (int i = 0; i < 5; i++)
            {
                WriteLine(indexerClass[i]);
            }
            WriteLine("\nИспользование индексаторасо строковым параметром:");
            foreach (string item in Enum.GetNames(typeof(Numbers)))
            {
                WriteLine(indexerClass[item]);
            }
        }
    }
}
