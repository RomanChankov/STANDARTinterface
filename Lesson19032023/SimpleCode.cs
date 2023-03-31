using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lesson19032023
{
    interface IDataProvider
    {
        string GetData();
    }
    interface IDataProcessor
    {
        void ProcessorData(IDataProvider dataProvider);
    }
    class ConsoleDataProcessor : IDataProcessor
    {
        public void ProcessorData(IDataProvider dataProvider)
        {
           Write(dataProvider.GetData() );
        }
    }
    class DbDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Данные из БД";
        }
    }
    class FileDAtaProvider : IDataProvider
    {
        public string GetData()
        {
            return "\nДанные из файла";
        }
    }
    class APIDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "\nДанные из API";
        }
    }

    internal class INTERFACESpropANDindex
    {
        static void Main(string[] args)
        {
           IDataProcessor dataprocessor = new ConsoleDataProcessor();
            dataprocessor.ProcessorData(new DbDataProvider());
            dataprocessor.ProcessorData(new FileDAtaProvider());
            dataprocessor.ProcessorData(new APIDataProvider());
        }
    }
}
