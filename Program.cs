using System;
using System.Diagnostics;

namespace Solid.OpenClosed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Start*****");
            var watch = Stopwatch.StartNew();
            Employee E1 = new PermanantEmployee(1, "Sagar");
            Employee E2 = new ContractEmployee(2, "John");
            Console.WriteLine($"Employee : {E1.ToString()} Bonus ={E1.CalculateBonus(10000)}");
            Console.WriteLine($"Employee : {E2.ToString()} Bonus ={E2.CalculateBonus(10000)}");
            Console.WriteLine($"{E1.EmpName} has benifit : {new PermanantEmployee(E1.EmpId, E1.EmpName).Healthbenifit()}");
            watch.Stop();
            Console.WriteLine($"Execution time in Milliseconds: {watch.ElapsedMilliseconds}");
            Console.WriteLine("*****End*****");
            Console.ReadKey();
        }
    }

    public abstract class  Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public string EmpSalary { get; set; }

        public Employee(int empId,string empName)
        {
            this.EmpId = empId;
            this.EmpName = empName;
        }

       public abstract decimal CalculateBonus(decimal EmplSalary);

        public override string ToString()
        {
            return string.Format($"EmpId :{EmpId} , Employee Name :{EmpName }");
        }
    }

    public class PermanantEmployee : Employee, IBenifit
    {
        public PermanantEmployee(int empId, string empName) : base (empId,empName)
        {

        }
        public override decimal CalculateBonus(decimal EmplSalary)
        {
            return EmplSalary * .1M;
        }

        public string Healthbenifit()
        {
            return "Health Insurance";
        }
    }
    public class ContractEmployee : Employee
    {
        public ContractEmployee(int empId, string empName) : base(empId, empName)
        {

        }
        public override decimal CalculateBonus(decimal EmplSalary)
        {
            return EmplSalary * .05M;
        }
    }

    public interface IBenifit
    {
        string Healthbenifit();
    }
}
