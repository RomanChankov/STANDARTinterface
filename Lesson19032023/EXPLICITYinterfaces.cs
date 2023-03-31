using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson19032023
{
    //Проблемы сокрытия имен при наследовании интерфейсов

    interface IA
    {
        void Show();
    }
    interface IB
    {
        void Show();
    }
    interface IC
    {
        void Show();
    }
    class ExplicitRealization : IA, IB, IC
    {

        void IA.Show()
        {
            WriteLine("Interface IA");
        }
        void IB.Show()
        {
            WriteLine("Interface IB");
        }
        public void Show()
        {
            WriteLine("Interface IC");
        }
    }
    internal class INTERFACESpropANDindex
    {
        static void Main(string[] args)
        {
            ExplicitRealization er = new ExplicitRealization();
            er.Show(); // вызов метода интерфейса IC неявно
            ((IA)er).Show(); // вызов метода интерфейса IA 
                             // явно
            IB iB = new ExplicitRealization();
            iB.Show(); // вызов метода интерфейса IB через 
                       // ссылку
        }
    }
}
