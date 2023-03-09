using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    public class Program
    {
      
        static void Main(string[] args)
        {
            // Object obj = "KAran";
            // Object obj1 = 10;
            // Object obj2 = 20;
            Display(10);
            // Display(10,10);
            //// Display<M>(M obj1,M)
            //Display<int,bool,string>(60,true,20,false,"Karan");
            Console.ReadLine();
        }

        private static void Display(object obj)
        {
           //S Console.WriteLine(obj*obj);
        }
        //private static void Display(object obj1, object obj2)
        //{
        //    if (obj1.GetType() == obj2.GetType())
        //    {
        //        Console.WriteLine(obj1.ToString()+obj2);
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid Input");
        //    }
        //}

        //private static void Display<M,T,N>(M obj1, T obj2, M obj3, T obj4, N obj5)
        //{
        //    Console.WriteLine(obj1+obj2+obj3+obj4+obj5);
        //}
        
    }
}
