using System;
using System.IO;
using System.Text;

namespace PiCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            // 100000 518 s 20 MB RAM
            Console.Write("Enter here how many digits of pi you want to calculate (including 3): ");
            int digits = 0;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out digits))
                {
                    Console.WriteLine("That is invalid number");
                    Console.Write("Enter valid number: ");
                }
                if ((digits > 100000) || (digits <= 0))
                {
                    Console.WriteLine("This number is out of range");
                    Console.Write("Enter number between 0 and 100001: ");
                }
                else break;
            }
            Console.Write("Calculating (this may take up to 10 minutes)... ");
            PI pi = new PI(digits);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pi.GetPi())
                sb.Append(b);
            File.WriteAllText($"pi{digits}digits.txt", sb.ToString());
            Console.WriteLine($"Done!\nDigits of pi are stored in 'pi{digits}digits.txt'");
        }
    }
}
