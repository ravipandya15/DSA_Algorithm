using System;
using System.Collections;

namespace OOP_Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArrayList arrList = new ArrayList();
            arrList.Add(1);
            arrList.Add(4);
            arrList.Add(3);
            arrList.Add(2);
            arrList.Add(6);
            arrList.Add(9);
            arrList.Add(5);
            // sort is required otherwise it will return some non negative number if value is still present.
            arrList.Sort();
            // returns the index of element
            int index = arrList.BinarySearch(4);
            Console.WriteLine($"INdex is {index}");
            //PermenentEmployee permenentEmployee = new PermenentEmployee();
            //permenentEmployee.Hello();
            //Employee employee = new PermenentEmployee();
            //employee.Hello();

            Most_Valuable_Employee mvEmployee = new Most_Valuable_Employee();
            mvEmployee.Hello();
        }
    }

    public class Employee
    {
        public Employee()
        {
            Console.WriteLine("constructor of Employee");
        }
        public virtual void Hello()
        {
            Console.WriteLine("Hello from Employee Class");
        }
    }

    public class PermenentEmployee : Employee
    {
        public PermenentEmployee()
        {
            Console.WriteLine("constructor of PermenentEmployee");
        }
        public override void Hello()
        {
            base.Hello();
            Console.WriteLine("Hello from PermenentEmployee Class");
        }
    }

    public class Most_Valuable_Employee : PermenentEmployee
    {
        public Most_Valuable_Employee()
        {
            Console.WriteLine("constructor of Most_Valuable_Employee");
        }

        public override void Hello()
        {
            base.Hello();
            Console.WriteLine("Hello from Most_Valuable_Employee Class");
        }
    }
}
