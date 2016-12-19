using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_1
{
    class RangeOfArray
    {
        public int lowerBount;
        public int upperBount;
        public int [] Arr;          
        public RangeOfArray (int upperIndex, int lowerIndex)
        {
            this.lowerBount = lowerIndex;
            this.upperBount = upperIndex;
            Arr=new int[Math.Abs(upperIndex - lowerIndex) +1];  
        }   
        public void Print(RangeOfArray mass, int lowerIndex)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Console.WriteLine($"{i + lowerIndex} элемент массива равен = " + Arr[i]);
            }  
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Введите нижний индекс диапазона массива");
            int lowerIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите верхний индекс диапазона массива");
            int uperIndex = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (!(lowerIndex > uperIndex))
            {
                Console.WriteLine("Нижний индекс равен {0} верхний индекс равен {1}", lowerIndex, uperIndex);   
                RangeOfArray array = new RangeOfArray(uperIndex, lowerIndex);   
                for (int i = 0; i < array.Arr.Length; i++)
                {
                    array.Arr[i] = rand.Next(10);
                }
                array.Print(array, lowerIndex);  
            }
            else
            {
               Console.WriteLine("Введены не корректные индексы"); 
            }  
        }
    }
}
