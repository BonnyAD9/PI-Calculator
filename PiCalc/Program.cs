using System;
using System.IO;
using System.Text;

namespace PiCalc;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Invalid number of arguments");
            return;
        }

        if (!int.TryParse(args[0], out int digits) || digits <= 0)
        {
            Console.WriteLine("That is invalid a number");
            return;
        }

        PI pi = new PI(digits);
        foreach (byte b in pi.GetPi())
            Console.Write(b);
        Console.WriteLine();
    }
}
