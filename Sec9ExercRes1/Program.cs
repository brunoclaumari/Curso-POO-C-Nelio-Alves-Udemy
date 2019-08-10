using System;
using System.Globalization;
using Sec9ExercRes1.Entities;
using Sec9ExercRes1.Entities.Enums;

namespace Sec9ExercRes1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level - (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("How many contracts to this worker?  ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                HourContract contract = new HourContract();
                Console.WriteLine("Enter #{0}º contract data: ",i);
                Console.Write("Date: (DD/MM/YYYY)");
                contract.Date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                contract.ValuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                contract.Hours = int.Parse(Console.ReadLine());

                worker.AddContract(contract);
            }
            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string dateDig = Console.ReadLine();
            int month = int.Parse(dateDig.Substring(0, 2));
            int year = int.Parse(dateDig.Substring(3));
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {dateDig}: {worker.Income(year,month).ToString("F2", CultureInfo.InvariantCulture)}");

            Console.ReadLine();


        }
    }
}
