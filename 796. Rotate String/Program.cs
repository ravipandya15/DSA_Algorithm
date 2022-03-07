using System;

namespace _796._Rotate_String
{
    class Program
    {
        // asked in Qualcomm
        static void Main(string[] args)
        {
            Console.WriteLine("796. Rotate String");
        }

        public bool RotateString(string s, string goal)
        {
            return ((s.Length == goal.Length) && (s + s).IndexOf(goal) != -1);
        }
    }
}
