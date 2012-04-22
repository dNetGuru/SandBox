using System;
using System.Threading;

// Copyright (c) Farzad E. (@dNetGuru) 
// Order of execution and Race Condition Example for Nebula Talk
// Relased under MIT Licence

// $Id: RCOdExec.cs,v 0.4.2 Wed 04/18/2012 0:29:32.12 dNetGuru  Exp $



namespace SandBox
{
    class Program
    {
        private static int resA = 0, resB = 1;
        private static string resC = "";

        static void A()
        {
            Console.Write("A");
            Thread.Sleep(new Random((int)DateTime.Now.Ticks).Next(100)); // some time consuming job !!!
            Console.Write("B");
            Console.Write("C");
            Console.Write("D");
        }

        static void B()
        {
            Console.Write("X");
            Console.Write("Y");
            Thread.Sleep(new Random((int)DateTime.Now.Ticks).Next(100)); // some time consuming job !!!
            Console.Write("Z");
        }

        static void RCA()
        {
            Console.Write("A");
            resC = ((char)new Random((int)DateTime.Now.Ticks).Next(97, 123)).ToString(); // pick a random letter !
            Thread.Sleep(new Random((int)DateTime.Now.Ticks).Next(100)); // some time consuming job !!!
            Console.Write("R" + resC); // print the random letter !
            Console.Write(resA);
            Console.Write("B");
        }

        static void RCB()
        {
            Console.Write("Y");
            const string superSecretPasswd = "a";
            resC = "not-a"; // the user entered something but not "a" which is our passwd !
            resB = new Random((int)DateTime.Now.Ticks).Next(100);
            Console.Write("WI" + resB);
            Thread.Sleep(resB); // some time consuming job !!!
            Console.Write("WF" + resB);
            if (resC == superSecretPasswd) // passwd check ! will always fail :( !
            {
                Console.Write("\n ******** PASSWORD MATCH ********\n");
                resA++;
            }
            Console.Write(resA);
            Console.Write("Z");
        }

        static void sRCA()
        {
            Console.Write("A");
            lock (resC)
            {
                resC = ((char)new Random((int)DateTime.Now.Ticks).Next(97, 123)).ToString(); // pick a random letter !
                Thread.Sleep(new Random((int)DateTime.Now.Ticks).Next(100)); // some time consuming job !!!
                Console.Write("R" + resC); // print the random letter !
            }
            Console.Write(resA);
            Console.Write("B");
        }

        static void sRCB()
        {
            Console.Write("Y");
            const string superSecretPasswd = "a";
            lock (resC)
            {
                resC = "not-a"; // the user entered something but not "a" which is our passwd !
                resB = new Random((int)DateTime.Now.Ticks).Next(100);
                Console.Write("WI" + resB);
                Thread.Sleep(resB); // some time consuming job !!!
                Console.Write("WF" + resB);
                if (resC == superSecretPasswd) // passwd check ! will always fail :( !
                {
                    Console.Write("\n ******** PASSWORD MATCH ********\n");
                    resA++;
                }
            }
            Console.Write(resA);
            Console.Write("Z");
        }

        static void Main()
        {
            Console.WriteLine("Order of Execution / Race Condition / Locks Demo by Farzad E. (@dNetGuru)");
            while (true)
            {
                var i = 0;
                Console.Write("> SELECT MODE FROM [(R)ace Conditions / (O)rder of Exec / (RETN) to Exit] ");
                var mod = Console.ReadKey(false).Key;
                if (mod == ConsoleKey.Enter) return;
                Console.Write("\nHow to Proceed ? [(A)sync/(S)ync" + (mod == ConsoleKey.R ? "/Sa(f)e Async" : string.Empty) + "] ");
                var type = Console.ReadKey(false).Key;
                Console.Write("\n# of iterations : ");
                if (!int.TryParse(Console.ReadLine(), out i)) continue;
                if (type == ConsoleKey.A)
                {
                    try
                    {
                        while (i > 0)
                        {
                            if (mod == ConsoleKey.R)
                            {
                                if (type == ConsoleKey.F) { new Thread(sRCA).Start(); new Thread(sRCB).Start(); }
                                else { new Thread(RCA).Start(); new Thread(RCB).Start(); }
                            }
                            else { new Thread(A).Start(); new Thread(B).Start(); }
                            i--;
                        }
                    }
                    catch { } // Nevermind then !
                    Console.ReadLine();
                }
                else
                {
                    while (i > 0)
                    {
                        if (mod == ConsoleKey.R) { RCA(); RCB(); }
                        else { A(); B(); }
                        i--;
                    }
                    Console.WriteLine();
                }
            }
        }


    }
}