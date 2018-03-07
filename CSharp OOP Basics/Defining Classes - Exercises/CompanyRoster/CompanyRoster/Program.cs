using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Department> departments = new List<Department>();
        int peopleCount = int.Parse(Console.ReadLine());

        for (int person = 0; person < peopleCount; person++)
        {
            string[] employeeInput = Console.ReadLine().Split();

            string name = employeeInput[0];
            decimal salary = decimal.Parse(employeeInput[1]);
            string position = employeeInput[2];
            string departmenName = employeeInput[3];

            string email = "n/a";
            int age = -1;

            if (employeeInput.Length == 6)
            {
                email = employeeInput[4];
                age = int.Parse(employeeInput[5]);
            }
            else if (employeeInput.Length == 5)
            {
                bool isAge = int.TryParse(employeeInput[4], out age);

                if (!isAge)
                {
                    email = employeeInput[4];
                    age = -1;
                }
            }

            

            if (!departments.Any(d => d.Name == departmenName))
            {
                Department dep = new Department(departmenName);
                departments.Add(dep);
            }
            var department = departments.FirstOrDefault(d => d.Name == departmenName);

            Employee employee = new Employee(name, position, salary, age, email);
            department.AddEmployee(employee);
            
        }

        var highestAverageDep = departments.OrderByDescending(d => d.AverageSalary).First();

        Console.WriteLine($"Highest Average Salary: {highestAverageDep.Name}");

        foreach (var emp in highestAverageDep.Employees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
        }
    }
}
