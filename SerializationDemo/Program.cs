using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{
    public class Program
    {
        [Serializable]
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Student(int id,string name)
            {
                this.Id = id;
                this.Name = name;
            }

        }

        static void Main(string[] args)
        {
            
            string path = @"C:\Training\Pitech\Pune Training\C#\Day 6\Sample.pdf";
            Student student = new Student(101, "Rayaba");
            FileStream stram = new FileStream(path,FileMode.OpenOrCreate);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(stram, student);
            stram.Close();
            Console.WriteLine("File Created Successfully" + path); 
            Console.ReadLine();
        }
    }
}
