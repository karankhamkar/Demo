using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface IPerson
    {
        void ShowMyName();

    }
    public interface ISupplier : IPerson
    {
        void Export();

    }
    public interface IDoctor : IPerson
    {
        void Surgery();

    }
    public interface Ifather : IPerson
    {
        void EntertainChild();

    }
    public class Program
    {
        class Person
        {
            public virtual void ShowMyName()
            {
                Console.WriteLine("My Name is Karan.");
            }
        }
        class Father :Person
        {
            public void EntertainChild()
            {
                Console.WriteLine("Entertain Child The Child.");
            }
        }
        class Doctor : Father
        {
            public void Surgury()
            {
                Console.WriteLine("Doctor Do Surgery.");
            }
        }
        class Supplier : Doctor
        {
            public void Export()
            {
                Console.WriteLine("Export The .");
            }
        }

        class DoctorSupplier : IDoctor, ISupplier
        {
            public void Export()
            {
                throw new NotImplementedException();
            }

            public void ShowMyName()
            {
                throw new NotImplementedException();
            }

            public void Surgery()
            {
                throw new NotImplementedException();
            }
        }

        public void KuchBhi(ISupplier iSupplier)
        {
            iSupplier.ShowMyName();
        }

        static void Main(string[] args)
        {
            //Person p = new Person();
            //Doctor doctor = new Doctor();
            //doctor.Surgury();
            ////((Person)doctor).Surgury();
            ////((Doctor)p).Surgury(); // System.InvalidCastException: 'Unable to cast object of type 'Person' to type 'Doctor'.' => RunTime ErrorS
            //Console.WriteLine();
            //Person person= new Supplier();
            //((Supplier)person).Surgury();
            //((Supplier)person).Export();
            //((Supplier)person).ShowMyName();
            //Console.WriteLine();

            //Person p1 = new Doctor();
            //((Doctor)p1).Surgury();
            //((Doctor)p1).EntertainChild();
            //((Doctor)p1).ShowMyName();
            //Console.WriteLine();

            //Person p2 = new Father();
            //((Father)p2).EntertainChild();
            //((Father)p2).ShowMyName();
            //Console.WriteLine();

            
            Console.ReadLine();
        }

       
    }

}
