using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson19032023
{
    public class User: IComparable<User>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public User(string name,int age)
        { 
            this.Name = name;
            this.Age = age;
        }
        public override string ToString()
        {
            return $"Имя: {Name}\tвозраст: {Age}";
        }
        public int CompareTo(User other)
        {
            return Age.CompareTo(other.Age);
        }

        //public int CompareTo(object obj)
        //{
        //    if(obj is User)
        //    {
        //        return Age.CompareTo((obj as User).Age);
        //    }
        //    throw new NotImplementedException();
        //}

    }
    public class UserStorage :IEnumerable
    {
        private readonly User[] users;
        public UserStorage(User[] users)
        {
            this.users = users;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return users.GetEnumerator();
        }
    }


    internal class INTERFACESpropANDindex
    {
        static void Main(string[] args)
        {
           User user1 = new User("Josef",36);
           User user2 = new User("Mark",27);
            User user3 = new User("Mark", 19);
            //UserStorage userStorage=new UserStorage(new User[] {user1,user2});
            User[] users = new User[] { user1, user2,user3 };

            foreach (User i in users)
            {
                Console.WriteLine(i);
            }

            Array.Sort(users);

            Console.WriteLine("После сотировки по ворасту\n");

            foreach (User i in users)
            {
                Console.WriteLine(i);
            }
        }
    }
}
