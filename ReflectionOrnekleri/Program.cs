using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionOrnekleri
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                
                Name = "emirhan",
                Age = "10"
            };

            Console.WriteLine(Control.Check(person));

            Console.ReadLine();
        }
    }
    public class Person
    {
        [Zorunlu]
        public string Name;
        [Zorunlu]
        public int Id;
        [Zorunlu]
        public string Age;
    }
    public class ZorunluAttribute : Attribute { }


    public class Control
    {

        public static bool Check(Person person)
        {
            Type type = typeof(Person);
            foreach (var item in type.GetFields())
            {
                object[] attribute = item.GetCustomAttributes(typeof(ZorunluAttribute), false);

                if (attribute.Length != 0)
                {
                    if (item.GetValue(person).GetType() == typeof(Int32))
                    {
                        if ((int)item.GetValue(person) == 0)
                        {
                            return false;
                        }
                    }
                    if (item.GetValue(person) == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


    }
}
