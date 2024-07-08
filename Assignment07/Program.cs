using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assignment07
{
    public enum Security
    {
        Guest,
        Developer,
        Secretary,
        DBA,
        SecurityOfficer
    }

    public class HireDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HireDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"[day: {Day}, month: {Month}, year: {Year}]";
        }
    }

    public class Employee
    {
        //static counter for id
        private static int count = 0;
        //fields
        private char gender;

        //props
        public int Id { get; }
        public string Name { get; set; }
        public Security SecurityLevel { get; set; }
        public decimal Salary { get; set; }
        public HireDate HiringDate { get; set; }
        public char Gender
        {
            get { return gender; }
            set { gender = (value == 'M' || value == 'F') ? value : 'M'; }
        }

        public Employee(string name, Security security, decimal salary, HireDate hireDate, char gender)
        {
            Id = count++;
            Name = name;
            SecurityLevel = security;
            Salary = salary;
            HiringDate = hireDate;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"id: {Id}\nname: {Name}\nsecurity: {SecurityLevel}\nsalary: {String.Format("{0:C}", Salary)}\nhiring date: {HiringDate}\ngender: {Gender}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee[] empArr = {new Employee("Mahmoud", Security.Guest, 2000, new HireDate(7,7,2024), 'M'),
                                    new Employee("Philo", Security.DBA, 8000, new HireDate(1,2,2024), 'M'),
                                    new Employee("Mai", Security.SecurityOfficer, 2000, new HireDate(1,7,2023), 'F')};

            //no boxing or unboxing occurs, we just take the values of the HiringDate class
            sortEmployees(empArr);
        }

        static void sortEmployees(Employee[] empArr)
        {
            for (int i = 0; i < empArr.Length; i++)
            {
                Employee minEmp = empArr[i];
                int minIdx = i;
                for (int j = i + 1; j < empArr.Length; j++)
                {
                    if (minEmp.HiringDate.Year > empArr[j].HiringDate.Year)
                    {
                        minEmp = empArr[j];
                        minIdx = j;
                    }
                    else if (minEmp.HiringDate.Year == empArr[j].HiringDate.Year)
                    {
                        if (minEmp.HiringDate.Month > empArr[j].HiringDate.Month)
                        {
                            minEmp = empArr[j];
                            minIdx = j;
                        }
                        else if (minEmp.HiringDate.Month == empArr[j].HiringDate.Month)
                        {
                            if (minEmp.HiringDate.Day > empArr[j].HiringDate.Day)
                            {
                                minEmp = empArr[j];
                                minIdx = j;
                            }
                        }
                    }
                }

                //switch the minimum with the current index
                Employee temp = empArr[i];
                empArr[i] = empArr[minIdx];
                empArr[minIdx] = temp;
            }
        }
    }
}