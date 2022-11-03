using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Lab1_CDM
{
    public class Set
    {
        public List<string> a = new List<string>();
        public List<string> b = new List<string>();
        public List<string> c = new List<string>();
        public List<string> u = new List<string>();
        public List<string> A = new List<string>();
        public List<string> B = new List<string>();
        public List<string> C = new List<string>();
        public List<string> U = new List<string>();
        public List<string> line = new List<string>();
        public List<string> element = new List<string>();
        public List<string> sign = new List<string>() { "!", "^", "+", "-" };
        
        private string item;
        public void Add_A(int index)
        {
            while (index != 0)
            {
                Console.WriteLine("Enter num");
                item = Console.ReadLine();
                a.Add(item);
                index--;
            }
        }
        
        public void Add_B(int index)
        {
            while (index != 0)
            {
                Console.WriteLine("Enter num");
                item = Console.ReadLine();
                b.Add(item);
                index--;
            }
            
        }
        public void Add_C(int index)
        {
            while (index != 0)
            {
                Console.WriteLine("Enter num");
                item = Console.ReadLine();
                c.Add(item);
                index--;
            }
        }

        public void Readline()
        {
            string first = null;
            string second = null;
            string answ = null;
            string readon = Console.ReadLine();
            line = new List<string>(readon.Split(' '));

            for (int i = 0; i < line.Count; i++)
            {
                foreach (var operand in sign)
                {
                    if (line[i] == "q")
                    {
                        Environment.Exit(0);
                    }
                    if (line[i] == operand)
                    {
                        if (operand == "+")
                        {
                            first += line[i - 1];
                            second +=  line[i + 1];
                            Union(first,second);
                        }
                        if (operand == "-")
                        {
                            first += line[i - 1];
                            second +=  line[i + 1];
                            Difference(first,second);
                        }
                        if (operand == "^")
                        {
                            first += line[i - 1];
                            second +=  line[i + 1];
                            Intersection(first,second);
                        }
                        if (line[i] == operand)
                        {
                            if (operand == "!")
                            {
                                second +=  line[i + 1];
                                Compliment(second);
                            }
                        }
                    }
                }
            }
        }

        public void Print()
        {
            //SET A
            A = a.Distinct().ToList();
            Console.Write("Set A : ( ");
            foreach (var elem in A)
            {
                u.Add(elem);
                Console.Write(elem + " ");
            }
            Console.WriteLine(")\n");
            //SET B
            B = b.Distinct().ToList();
            Console.Write("Set B : ( ");
            foreach (var elem in B)
            {
                u.Add(elem);
                Console.Write(elem + " ");
            }
            Console.WriteLine(")\n");
            //SET C
            C = c.Distinct().ToList();
            Console.Write("Set C : ( ");
            foreach (var elem in C)
            { 
                u.Add(elem);
                Console.Write(elem + " ");
            }
            Console.WriteLine(")\n");
            //UNIVERSAL SET
            U = u.Distinct().ToList();
            Console.Write("Set U : ( ");
            foreach (var elem in U)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine(")\n");
        }
        
        public void Union(string fst,string secnd)
            {
                List<string> aunion = new List<string>();
                foreach (var elem in A)
                {
                    aunion.Add(elem);
                }

                List<string> bunion = new List<string>();
                foreach (var elem in B)
                {
                    bunion.Add(elem);
                }

                int value = 0;
                if (fst == "0" || secnd == "0")
                {
                    Console.WriteLine("Did u want to quit? 1 - yes,2 - no");
                    if (fst == "1" || secnd == "1")
                    {
                        Console.WriteLine("bye-bye");
                        Environment.Exit(0);
                    }
                }
                
                if (fst == "A" && secnd == "B" || fst == "B" && secnd == "A")
                {
                    foreach (var num in B)
                    {
                        aunion.Add(num);
                    }

                    aunion = aunion.Distinct().ToList();
                    Console.Write(fst + "u" + secnd+ " ");
                    foreach (var elem in aunion)
                    {
                        Console.Write(elem + "  ");
                    }

                    Console.Write("\n");
                }

                if (fst == "B" && secnd == "C" || fst  == "C" && secnd == "B")
                {
                    foreach (var num in C)
                    {
                        bunion.Add(num);
                    }

                    aunion = bunion.Distinct().ToList();
                    Console.Write(fst + "u" + secnd + " ");
                    foreach (var elem in bunion)
                    {
                        Console.Write(elem + "  ");
                    }

                    Console.Write("\n");
                }

                if (fst == "A" && secnd == "C" || fst == "C" &&  secnd == "A")
                {
                    foreach (var num in C)
                    {
                        aunion.Add(num);
                    }

                    aunion = aunion.Distinct().ToList();
                    Console.Write(fst + "u" + secnd + " ");
                    foreach (var elem in aunion)
                    {
                        Console.Write(elem + "  ");
                    }

                    Console.Write("\n");
                }
            }
        public void Intersection(string frst,string secnd)
            {
                bool emptylist = true;
                Console.WriteLine("Write first set for checking intersections ");
                frst = Console.ReadLine();
                Console.WriteLine("Write second set for checking intersections ");
                secnd = Console.ReadLine();
                List<string> I = new List<string>();
                if (frst == "0" || secnd == "0")
                {
                    Console.WriteLine("Did u want to quit? 1 - yes,2 - no");
                    if (frst == "1" || secnd == "1")
                    {
                        Console.WriteLine("bye-bye");
                        Environment.Exit(0);
                    }
                }
                if (frst == "A" && secnd == "B" || secnd == "A" && frst == "B")
                {
                    foreach (string i in A)
                    {
                        foreach (string elem in B)
                        {
                            if (i == elem)
                            {
                                I.Add(i);
                                emptylist = false;
                            }
                        }
                    }
                }

                if (frst == "B" && secnd == "C" || secnd == "B" && frst == "C")
                {
                    foreach (string i in B)
                    {
                        foreach (string elem in C)
                        {
                            if (i == elem)
                            {
                                I.Add(i);
                                emptylist = false;
                            }
                        }
                    }
                }

                if (frst == "A" && secnd == "C" || secnd == "C" && frst == "A")
                {
                    foreach (string i in A)
                    {
                        foreach (string elem in C)
                        {
                            if (i == elem)
                            {
                                I.Add(i);
                                emptylist = false;
                            }
                        }
                    }

                }

                if (emptylist)
                {
                    Console.WriteLine("Intersection is empty");
                }
                else
                {
                    List<string> intersection = I.Distinct().ToList();
                    Console.Write("Intersection is ( ");

                    foreach (var elem in intersection)
                    {
                        Console.Write(elem + " ");
                    }

                    Console.Write(")\n");
                }

            }
        
        public void Compliment( string variable)
            {
                List<string> U_rez = new List<string>();
                if (variable == "A")
                {
                    for (int i = 0; i < U.Count; i++)
                    {
                        foreach (string elem in A)
                        {
                            if (elem == U[i])
                            {
                                U_rez.Add(U[i]);
                                U.Remove(U[i]);
                                
                            }
                        }
                    }

                    Console.Write(variable + "` = (");
                    foreach (var elem in U)
                    {
                        Console.Write(elem + " ");
                    }

                    Console.Write(")\n");
                }

                if (variable == "B")
                {
                    for (int i = 0; i < U.Count; i++)
                    {
                        foreach (string elem in B)
                        {
                            if (elem == U[i])
                            {
                                U_rez.Add(U[i]);
                                U.Remove(U[i]);
                            }
                        }
                    }

                    Console.Write(variable + "` = ( ");
                    foreach (var elem in U)
                    {
                        Console.Write(elem + " ");
                    }

                    Console.Write(")\n");
                }

                if (variable == "C")
                {
                    for (int i = 0; i < U.Count; i++)
                    {
                        foreach (string elem in C)
                        {
                            if (elem == U[i])
                            {
                                U_rez.Add(U[i]);
                                U.Remove(U[i]);
                            }
                        }
                    }

                    Console.Write(variable + "` = ( ");
                    foreach (var elem in U)
                    {
                        Console.Write(elem + " ");
                    }

                    Console.Write(")\n");
                }

                foreach (var elem in U_rez)
                {
                    U.Add(elem);
                }
            }
        public void Difference( string frst,string scnd)
            {
                List<string> a_dif = new List<string>();
                foreach (var elem in A)
                {
                    a_dif.Add(elem);
                }

                List<string> b_dif = new List<string>();
                foreach (var elem in B)
                {
                    b_dif.Add(elem);
                }

                List<string> c_dif = new List<string>();
                foreach (var elem in C)
                {
                    c_dif.Add(elem);
                }

                bool emptylist = true;
                string sign = @"\";
                if (frst == "A" && scnd == "B")
                {
                    for (int i = 0; i < A.Count; i++)
                    {
                        foreach (string elem in B)
                        {
                            if (elem == A[i])
                            {
                                a_dif.Remove(A[i]);
                            }
                        }
                    }

                    Console.Write(frst + sign + scnd + " = ( ");
                    foreach (string i in a_dif)
                    {
                        Console.Write(i + " ");
                    }

                    Console.Write(")\n");
                }

                if (frst == "B" && scnd == "A")
                {
                    for (int i = 0; i < B.Count; i++)
                    {
                        foreach (string elem in A)
                        {
                            if (elem == B[i])
                            {
                                b_dif.Remove(B[i]);
                            }
                        }
                    }

                    Console.Write(frst + sign + scnd + " = ( ");
                    foreach (string i in b_dif)
                    {
                        Console.Write(i + " ");
                    }

                    Console.Write(")\n");
                }

                if (frst == "A" && scnd == "C")
                {
                    for (int i = 0; i < A.Count; i++)
                    {
                        foreach (string elem in C)
                        {
                            if (elem == A[i])
                            {
                                a_dif.Remove(A[i]);
                            }
                        }
                    }

                    Console.Write(frst + sign + scnd + " = ( ");
                    foreach (string i in a_dif)
                    {
                        Console.Write(i + " ");
                    }

                    Console.Write(")\n");
                }

                if (frst == "C" && scnd == "A")
                {
                    for (int i = 0; i < C.Count; i++)
                    {
                        foreach (string elem in A)
                        {
                            if (elem == C[i])
                            {
                                c_dif.Remove(C[i]);
                            }
                        }
                    }

                    Console.Write(frst + sign + scnd + " = ( ");
                    foreach (string i in c_dif)
                    {
                        Console.Write(i + " ");
                    }

                    Console.Write(")\n");
                }

                if (frst == "B" && scnd == "C")
                {
                    for (int i = 0; i < B.Count; i++)
                    {
                        foreach (string elem in C)
                        {
                            if (elem == B[i])
                            {
                                b_dif.Remove(B[i]);
                            }
                        }
                    }

                    Console.Write(frst + sign + scnd + " = ( ");
                    foreach (string i in b_dif)
                    {
                        Console.Write(i + " ");
                    }

                    Console.Write(")\n");
                }

                if (frst == "C" && scnd == "B")
                {
                    for (int i = 0; i < C.Count; i++)
                    {
                        foreach (string elem in B)
                        {
                            if (elem == C[i])
                            {
                                c_dif.Remove(C[i]);
                            }
                        }
                    }

                    Console.Write(frst + sign + scnd + " = ( ");
                    foreach (string i in c_dif)
                    {
                        Console.Write(i + " ");
                    }

                    Console.Write(")\n");
                }

            }

    }
}
