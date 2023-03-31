using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson19032023
{
    // Анализ стандартных интерфейсов
    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенческий билет: {Series} {Number}";
        }

    }
    class Student : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Cours { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }


        public override string ToString()
        {
            return $"Имя: {FirstName}, Фамилия: {LastName}, Курс - {Cours},  Дата рождения: {BirthDate.ToLongDateString()}" + StudentCard.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return LastName.CompareTo((obj as Student).LastName);
            }
            throw new NotImplementedException();

        }
       


        class Auditory : IEnumerable
        {
            Student[] students =
              {
                new Student
                {
                FirstName ="John",
                LastName ="Miller",
                Cours=3,
                BirthDate =new DateTime(1997,3,12),
                StudentCard =new StudentCard
                {
                    Number=189356,
                    Series="AB"
                }
                },
                new Student
                {
                FirstName ="Candice",
                LastName ="Leman",
                Cours=6,
                BirthDate =new DateTime(1998,7,22),
                StudentCard = new StudentCard
                {
                    Number=345185,
                    Series="XA"
                }
                },
                new Student
                {
                FirstName ="Joey",
                LastName ="Finch",
                Cours=4,
                BirthDate = new DateTime(1996,11,30),
                StudentCard = new StudentCard
                {
                    Number=258322,
                    Series="AA"
                }
                },

                new Student
                {
                FirstName ="Nicole",
                LastName ="Taylor",
                Cours=5,
                BirthDate = new DateTime(1996,5,10),
                StudentCard = new StudentCard
                {
                    Number=513484,
                    Series="AA"
                }
                },
                new Student
                {
                FirstName ="Conor",
                LastName ="MacGregor",
                Cours=2,
                BirthDate = new DateTime(1985,5,10),
                StudentCard = new StudentCard
                {
                    Number=513480,
                    Series="NV"
                }
                },
                new Student
                {
                FirstName ="Boris",
                LastName ="Fetrov",
                Cours=1,
                BirthDate = new DateTime(2000,8,10),
                StudentCard = new StudentCard
                {
                    Number=577480,
                    Series="CW"
                }
                }
        };

            public void Sort()
            {
                Array.Sort(students);
            }
          
            public void Sort(IComparer comp)
            {
                Array.Sort(students, comp);
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return students.GetEnumerator();
            }
        }
        class DataComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Student && y is Student)
                {
                    return DateTime.Compare((x as Student).BirthDate, (y as Student).BirthDate);
                }
                throw new NotImplementedException();
            }
        }

        class FirstNameComparer : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                if (x is Student && y is Student)
                {
                    return string.Compare((x as Student).FirstName, (y as Student).FirstName);
                }
                throw new NotImplementedException();
            }
        }


        class CoursComparer : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Student student1 = x as Student;
                Student student2 = y as Student;
                if (student1.Cours > student2.Cours)
                    return 1;
                if (student1.Cours < student2.Cours)
                    return -1;
                else
                    return 0;
            }
        }

        //class CoursComparer : IComparer
        //{
        //    int IComparer.Compare(object x, object y)
        //    {
        //        if (x is Student && y is Student)
        //        {
        //            return  ((x as Student).Cours, (y as Student).Cours);
        //        }
        //        throw new NotImplementedException();
        //    }
        //}



        internal class INTERFACESpropANDindex
        {
            static void Main(string[] args)
            {
                Auditory auditory = new Auditory();
                WriteLine("Список студентов");
                foreach (Student student in auditory)
                {
                    WriteLine(student);
                }
                WriteLine("\nСписок студентов  по фамилии после сортировки:");
                auditory.Sort();

                foreach (Student student in auditory)
                {
                    WriteLine(student);
                }
                WriteLine("\nСписок студентов по дате рождения после сортировки:");
                auditory.Sort(new DataComparer());
                foreach (Student student in auditory)
                {
                    WriteLine(student);
                }
                WriteLine("\nСписок студентов по имени после сортировки:");
                auditory.Sort(new FirstNameComparer());
                foreach (Student student in auditory)
                {
                    WriteLine(student);
                }
                WriteLine("\nСписок студентов по номеру курса после сортировки:");
                auditory.Sort(new CoursComparer());
                foreach (Student student in auditory)
                {
                    WriteLine(student);
                }
            }
        }
    }
}
