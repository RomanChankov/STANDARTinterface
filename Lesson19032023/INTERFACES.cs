using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson19032023
{
    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"\nФамилия: {LastName} Имя: {FirstName} Дата рождения: {BirthDate.ToLongDateString()}";
        }
    }
    abstract class Employee : Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nДолжность: {Position} Зарплата: {Salary}";
        }
    }
    public interface IWorker
    {
        // event EventHandler Workended;
        bool IsWorking { get; }
        string Work();
    }
    public interface IManager
    {
        List<IWorker> ListOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();

    }
    class Director : Employee, IManager
    {
        public List<IWorker> ListOfWorkers { get; set; }
        public void Organize()
        {
            WriteLine("Я организую работу магазина и сотрудников");
        }
        public void MakeBudget()
        {
            WriteLine("Я формирую бюджет");
        }
        public void Control()
        {
            WriteLine("Я контролирую работу магазина и сотрудников");
        }

    }
    class Seller : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Я продаю товар";
        }
    }

    class Cashier : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Я принимаю оплату за товар";
        }
    }
    class Storekeeper : Employee, IWorker
    {
        public bool isWorking = true;
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
        }
        public string Work()
        {
            return "Я принимаю и учитываю товар";
        }
    }
    internal class INTERFACES
    {
        static void Main(string[] args)
        {
            Director director = new Director
            {
                FirstName="Ray",LastName="Crock",BirthDate=new DateTime(1945,12,12),Position="Директор",Salary=50000
            };
            IWorker seller= new Seller
            {
                FirstName="Jim",LastName="Seller",BirthDate =new DateTime(1988,11,05),Position="Продавец",Salary=5000
            };

            if(seller is Employee)
            {
                Console.WriteLine($"Зарплата продавца: {(seller as Employee).Salary}");
                //Привидение интерфейсной ссыылки к классу Employee
            }
            director.ListOfWorkers=new List<IWorker>
            {
                seller,
                new Cashier
                {
                    FirstName="Elena",LastName="Anatoljeva",BirthDate=new DateTime(1917,10,15),Position="кассир",Salary=10000
                },
                new Storekeeper
                {
                     FirstName="Albert",LastName="Stepanov",BirthDate=new DateTime(1799,05,09),Position="хрантель",Salary=15000
                }
            };
            WriteLine(director);
            if(director is IManager)
            {
                director.Control();
            }
            foreach (IWorker item in director.ListOfWorkers)
            {
                WriteLine(item);
                if(item.IsWorking) 
                {
                    WriteLine(item.Work());
                }
            }
        }
    }
}
