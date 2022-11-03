using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab1_CDM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Set a = new Set();



            int exempl;
            bool entry = true;
            string passkey;
            Console.WriteLine("Enter index for A set");
            string indx = Console.ReadLine();
            Check_and_Do(indx, "A");
            Console.WriteLine("Enter index for B set");
            indx = Console.ReadLine();
            Check_and_Do(indx,"B");
            Console.WriteLine("Enter index for C set");
            indx = Console.ReadLine();
            Check_and_Do(indx,"C");
            a.Print();
            Console.WriteLine("Write the equation.If u want to quit,enter `q` " );
            while (entry)
            {
                a.Readline();
                Console.WriteLine();
            }
            



            //try to parse index
            void Check_and_Do(string index,string cur_set)
            {
                bool success = int.TryParse(indx, out exempl);
                while (!(success))
                {
                    //if index isn`t num
                    Console.WriteLine("Uncorect!Try again.");
                    indx = Console.ReadLine();
                    success = int.TryParse(indx, out exempl);
                }

                if (cur_set == "A")
                {
                    a.Add_A(Convert.ToInt16(indx));
                }
                if (cur_set == "B")
                {
                    a.Add_B(Convert.ToInt16(indx));
                }
                if (cur_set == "C")
                {
                    a.Add_C(Convert.ToInt16(indx));
                }
            }
        }
    }
}

