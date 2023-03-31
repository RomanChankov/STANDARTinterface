using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson19032023
{
    // Наследование интерфейсов
   interface IA
    {
        string A1(int n);
    }
    interface IB
    {
        int B1(int n);
        void B2();
    }
    interface IC : IA,IB
    {
        void C1(int n);
    }

    class InherInterface :IC
    {
        public void C1(int n)
        {
            throw new NotImplementedException();
        }
        public string A1(int n)
        {
            throw new NotImplementedException ();
        }
        public int B1(int n)
        {
            throw new NotImplementedException () ;
        }
        public void B2() 
        { 
            throw new NotImplementedException ();
        }
    }

    internal class INTERFACESpropANDindex
    {
        static void Main(string[] args)
        {
           
        }
    }
}
