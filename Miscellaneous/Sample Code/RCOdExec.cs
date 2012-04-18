using System;
using System.Threading;

// Farzad E. (@dNetGuru) 
// Order of execution Example for Nebula Talk

namespace SandBox
{
    class Program
    {
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

        static void Main()
        {
            while (true)
            {
                string readLine;
                Console.Write("How to Proceed ? [(A)sync/(S)ync] ");
                if ((readLine = Console.ReadLine()) == "" || readLine == null) return;
                var aS = (readLine.Substring(0, 1).ToLower() == "a");
                Console.Write("# of iterations : ");
                var i = Convert.ToInt32(Console.ReadLine());
                if (aS)
                {
                    try { while (i > 0) { new Thread(A).Start(); new Thread(B).Start(); i--; } }
                    catch { } // Nevermind then !
                    Console.ReadLine();
                }
                else
                {
                    while (i > 0) { A(); B(); i--; }
                    Console.WriteLine();
                }
            }
        }
    }
}
