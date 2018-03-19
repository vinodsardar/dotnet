using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace StructureMapDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(_ =>
            {
                _.For<DummyClass>().Use<DummyClass>();
                
            });

            DummyClass dummyClass = container.GetInstance<DummyClass>();

            dummyClass.Display();
        }
    }

    public class DummyClass
    {
        public void Display()
        {
            Console.WriteLine("Display my data !!");
        }
    }
 

}
