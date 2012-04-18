using System;
using System.Threading;

// Copyright (c) Farzad E. (@dNetGuru) 
// Order of execution and Race Condition Example for Nebula Talk
// Relased under MIT Licence

// $Id: RCOdExec.cs,v 0.3.1 Wed 04/18/2012 0:29:32.12 dNetGuru  Exp $



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

        static void Main()
        {
            while (true)
            {
                var i = 0;
                Console.Write("Which test to run ? [(R)ace Conditions / (O)rder of Exec / (RETN) to Exit] ");
                var consoleKey = Console.ReadKey(false).Key;
                if (consoleKey == ConsoleKey.Enter) return;
                var tS = (consoleKey == ConsoleKey.R);
                Console.Write("\nHow to Proceed ? [(A)sync/(S)ync] ");
                var aS = (Console.ReadKey(false).Key == ConsoleKey.A);
                Console.Write("\n# of iterations : ");
                if (!int.TryParse(Console.ReadLine(), out i)) continue;
                if (aS)
                {
                    try
                    {
                        while (i > 0)
                        {
                            if (tS) { new Thread(RCA).Start(); new Thread(RCB).Start(); }
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
                        if (tS) { RCA(); RCB(); }
                        else { A(); B(); }
                        i--;
                    }
                    Console.WriteLine();
                }
            }
        }


    }
}
