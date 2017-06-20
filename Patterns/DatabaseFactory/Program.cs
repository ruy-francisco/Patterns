using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseFactory.ConcreteClass;

namespace DatabaseFactory
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool success = DatabaseHandler.CreateTable("teste");
            Console.ReadKey();
        }
    }
}
