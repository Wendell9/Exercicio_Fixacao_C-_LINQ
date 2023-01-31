using Exercicio_de_Fixacao.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_de_Fixacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path, name, email;
            double salary, salaryE;
            List<Employee> list = new List<Employee>();

            Console.Write("Enter full path: ");
            path = Console.ReadLine();
            Console.Write("Enter salary: ");
            salary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] lines = sr.ReadLine().Split(',');
                    name = lines[0];
                    email = lines[1];
                    salaryE = double.Parse(lines[2], CultureInfo.InvariantCulture);

                    list.Add(new Employee(name, email, salaryE));
                }
            }

            List<string> emaillist = list.Where(e => e.Salary > salary).Select(e=>e.Email).ToList();

            double sum = list.Where(e => e.Name[0] == 'M').Select(e => e.Salary).Aggregate((x, y) => x + y);
            Console.WriteLine($"Email of those salary is more than {salary}");
            foreach (string item in emaillist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sum.ToString("F2",CultureInfo.InvariantCulture)}");
        }
    }
}
