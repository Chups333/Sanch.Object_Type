using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bb = System.Int32;

namespace Sanch.Object_Type
{
    class Program //: System.Object - не надо (неявное наследование)
    {
        static void Main(string[] args)
        {
            //обджект - базовый класс (тип)
            //есть методы которые помогают правильно работать

            //System.Object == object
            //System.Int64 === int

            object obj = new object();
            //obj.Equals - позволяет выполнять сравнение (если значимые то сравниваем по значению
            //если ссылочные - то сравниваем ссылки(адреса)

            int i = 5;
            int j = 5;
            Console.WriteLine(i.Equals(j));// - сравниваем значения 

            object oi = (object)i;//упаковка (boxing)
            object oj = (object)j;//упаковка (boxing)

            Console.WriteLine(oi.Equals(oj)); //сравнение ссылочных

            var p1 = new Point() { X = 5 };
            var p2 = new Point() { X = 5 };

            Console.WriteLine(p1.Equals(p2)); //сравнение ссылочных ( но мы переделали на сравнение по значению)


            Console.WriteLine();
            Console.WriteLine(i.GetHashCode());//число
            Console.WriteLine(oi.GetHashCode());//число
            Console.WriteLine(new MyClass().GetHashCode());//адрес памяти
            Console.WriteLine(p1.GetHashCode());//число которое мы преопределили

            Console.WriteLine();
            Console.WriteLine(i.ToString()); //число в строковом формате
            Console.WriteLine(p1.ToString()); //преопределили строковое значение

            Console.WriteLine();
            Console.WriteLine(i.GetType()); // будет возвращен тип
            Console.WriteLine(oi.GetType()); //тип упакованный
            Console.WriteLine(p1.GetType()); //наш тип
            Console.WriteLine(typeof(Point) == p1.GetType());  //typeof(class) - получаем тип класса

            Console.WriteLine();
            //object.ReferenceEquals - сравниваем объекты по ссылке - игнор значения
            Console.WriteLine(Object.Equals(5, 5));
            Console.WriteLine(Object.ReferenceEquals(5, 5)); //false - потому что две разные переменные в памяти ( разные ссылки) 
            Console.WriteLine(Object.ReferenceEquals(p2, p2)); //один и тот же участок памяти

            Console.WriteLine();
            //MemberwiseClone() - позволяет создавать дубликаты объектов (используется только внутри класса)
            //клоны - дополнительный скопированный объект который будет содержать все те же поля которые 
            //содержались в исходном, но это будет поддельный другой объект 

            var pp = new Point() { X = 7, Y = new Point() };
            var pp2 = pp; //участок памяти один и тот же (будут изменять все если изменить что то в другом) 
            // а если сделать дубликат - то они будут независимы друг от друга
            pp2.X= 77; // поменяется и у pp
            pp2.Y = new Point
            {
                X = 99
            };
            Console.WriteLine(pp);
            Console.WriteLine(pp.Y);
            var pp3 = pp.Clone();
            pp3.X = 88; //поменяется только pp3
            pp3.Y.X = 222; //поменялось и у pp так как это ссылочный тип
            
            Console.WriteLine(pp.Y);


            Console.ReadKey();


        }
    }
}
