﻿namespace SolidPrinciples_Dot_Net_Series_1.DIP
{
    public class SalaryCalculator
    {
        public SalaryCalculator()
        {

        }
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
    }

    public class EmployeeDetails
    {
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public float GetSalary()
        {
            var salaryCalculator = new SalaryCalculator();
            return salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
        }
    }


    public interface ISalaryCalculator
    {
        float CalculateSalary(int hoursWorked, float hourlyRate);
    }

    public class SalaryCalculatorModified : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
    }

    public class FixSalaryCalculatorModified : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;

        public float CalculateSalary1(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;

        public float CalculateSalary2(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
    }

    public class EmployeeDetailsModified
    {
        private readonly ISalaryCalculator _salaryCalculator;
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public EmployeeDetailsModified(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }
        public float GetSalary()
        {
            return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
        }
    }
}
