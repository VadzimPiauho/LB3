using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_1
{
    class RangeOfArray
    {
        public int LowerBount;
        public int UpperBount;
        public int [] Arr;          
        public RangeOfArray (int UpperIndex, int LowerIndex)
        {
            this.LowerBount = LowerIndex;
            this.UpperBount = UpperIndex;
            Arr=new int[Math.Abs(UpperIndex-LowerIndex)+1];  
        }   
        public void Print(RangeOfArray mass, int LowerIndex)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Console.WriteLine($"{i + LowerIndex} элемент массива равен = " + Arr[i]);
            }  
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Введите нижний индекс диапазона массива");
            int LowerIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите верхний индекс диапазона массива");
            int UpperIndex = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (!(LowerIndex>UpperIndex))
            {
                Console.WriteLine("Нижний индекс равен {0} верхний индекс равен {1}", LowerIndex, UpperIndex);   
                RangeOfArray Array = new RangeOfArray(UpperIndex, LowerIndex);   
                for (int i = 0; i < Array.Arr.Length; i++)
                {         
                    Array.Arr[i] = rand.Next(10);
                }
                Array.Print(Array, LowerIndex);  
            }
            else
            {
               Console.WriteLine("Введены не корректные индексы"); 
            }  
        }
    }
}
