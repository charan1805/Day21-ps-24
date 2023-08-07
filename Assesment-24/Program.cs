using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EmpLib;

namespace Assignment24
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Emp Id");
            employee.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Emp Fname");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Emp LName");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Enter Emp Salary");
            employee.Salary = double.Parse(Console.ReadLine());
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("E:\\my details\\personal\\c sharp\\day21\\Assesment-24\\employee.bin", FileMode.Create))
            {
                formatter.Serialize(fs, employee);
            }
            Console.WriteLine("File created object is Serilized\n");
            using (FileStream fs = new FileStream("E:\\my details\\personal\\c sharp\\day21\\Assesment-24\\employee.bin", FileMode.Open))
            {
                //formatter.Serialize(fs, employee);
                {
                    Employee emp = (Employee)formatter.Deserialize(fs);
                    Console.WriteLine("Emp Id : " + emp.Id);
                    Console.WriteLine("Emp Name : " + emp.FirstName + " " + emp.LastName);
                    Console.WriteLine("Emp Salary : " + emp.Salary);
                }
            }
            Console.WriteLine("\nReadout & Serilized\n");
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("E:\\my details\\personal\\c sharp\\day21\\Assesment-24\\employee.Xml"))
            {
                serializer.Serialize(writer, employee);
            }
            Console.WriteLine("Xml Created\n");
            //  XmlSerializer serializer = new XmlSerializer(typeof(Player));
            Console.WriteLine("Xml Data Readout");
            using (TextReader reader = new StreamReader("E:\\my details\\personal\\c sharp\\day21\\Assesment-24\\employee.Xml"))
            {
                Employee emp = (Employee)serializer.Deserialize(reader);
                Console.WriteLine($"ID = {emp.Id},\nFirstName = {emp.FirstName},\nLastName = {emp.LastName},\nSalary = {emp.Salary}");

            }
            Console.ReadKey();

        }
    }
}