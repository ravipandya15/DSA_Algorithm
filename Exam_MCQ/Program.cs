using System;
using System.Collections;

namespace Exam_MCQ
{
    class Program
    {

        //concept need to check

        // Single return type
        // Yeild in C#
        static void Main(string[] args)
        {
            Console.WriteLine("Exam MCQ");
            //Example ex = new Example();

            try
            {
                //hack1 h = new hack1();
                //hack2 h4 = h2;

                hack1 h1 = new hack2(); // correct
                hack2 h2 = new hack1(); // incorrect

            }
            catch (Exception ex)
            {

            }
        }
    }

    public class hack1
    {
        public virtual void h()
        {
            Console.WriteLine("h1");
        }
    }

    public class hack2 : hack1
    {
        new void h()
        {
            Console.WriteLine("hello");
        }
    }

    //public class Example
    //{
    //    char[] xyz = { 'W', 'X', 'Y', 'Q' };
    //    public void getEnumerator()
    //    {
    //        foreach (char ch in xyz)
    //        {
    //        }
    //    }
    //}
}
