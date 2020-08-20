using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Object_Type
{
    class Point
    {
        public int X { get; set; }
        //можно сравнивать не по памяти (смотри ниже)
        public Point Y { get; set; }

        public override bool Equals(object obj)
        {
            //никогда нельзя делать(реализовывать) exseption (всегда либо тру либо фолс)
            if (obj == null) //проверка на null
            {
                return false;
            }
            //is as / is - возвращает булевое значение если этот тип является тем же типом с которым мы сравниваем
            //as - является типом который мы указали то переменная приводится в этот тип, иначе null

            if (obj is Point point) // var point = obj as Point;
            {
                //сравнение которое нам нужно
                return point.X == X; //сравниваем не по памяти а по значению
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode() //Equals на минималках (должа быть быстрой)
        {
            return X; //быстро возвращает значение
        }
        public override string ToString() //приведение к строковому значению (число в формате строки)
        {
            return X.ToString();
        }

        public new Type GetType() //можем преопределить метод с помощью "new" - не надо так делать (но такое возможно)
        {
            return typeof(UInt16);
        }
        
        public Point Clone()
        {
            return MemberwiseClone() as Point;//-неглубокое копирование (продублируются значимые переменные и они разные (например X))
            // если есть ссылочные переменные, то они будут одни и те же таи и там      
        }


    }
}
