using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godtycklig_Lönerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {

                int numberOfSalaries = 0;
                while (numberOfSalaries < 2)
                {
                    numberOfSalaries = ReadInt("Ange antal löner att mata in: ");
                    if (numberOfSalaries < 2)
                    {
                        ViewMessage("\nDu måste mata in minst två löner för att kunna göra en beräkning!\n", true);
                    }
                }

                Console.WriteLine();
                int[] salaries = ReadSalaries(numberOfSalaries);

                ViewResult(salaries);

                loop = IsContinuing();
            }
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string temp = Console.ReadLine();
                try
                {
                    if (int.Parse(temp) < 0)
                    {
                        ViewMessage("Inga negativa siffror, tack!", true);
                    }
                    else
                    {
                        return int.Parse(temp);
                    }
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    ViewMessage("FEL! \"" + temp + "\" kan inte tolkas som ett heltal!", true);
                    Console.ResetColor();
                }
            }
        }

        static int[] ReadSalaries(int count)
        {
            // Skapa arrayen salaries och ge den värden.
            int[] salaries = new int[count];
            for (int i = 0; i < count; i++)
            {
                salaries[i] = ReadInt("Ange lön nummer " + (i + 1) + ": ");
            }
            return salaries;
        }

        static void ViewResult(int[] salaries)
        {
            int medianSalary = GetMedian(salaries);
            int averageSalary = (int)salaries.Average();
            int salaryDispersion = GetDispersion(salaries);

            Console.WriteLine("\n---------------------------\n");
            Console.WriteLine("Medianlön:     {0,5:c0}", medianSalary);
            Console.WriteLine("Medellön:      {0,5:c0}", averageSalary);
            Console.WriteLine("Lönespridning: {0,5:c0}", salaryDispersion);
            Console.WriteLine("\n---------------------------\n");

            // Skriv ut alla löner, i inmatad ordning, tre på varje rad.
            for (int i = 0; i < salaries.Length; i++)
            {
                Console.Write("{0,8}", salaries[i]);
                if ((i % 3) == 2)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        static int GetDispersion(int[] source)
        {
            return source.Max() - source.Min();
        }

        static int GetMedian(int[] source)
        {
            int medianSalary;
            int[] copy = new int[source.Length];
            Array.Copy(source, copy, source.Length);
            Array.Sort(copy);
            if (copy.Length % 2 != 0)
            {
                return medianSalary = copy[copy.Length / 2];
            }
            else
            {
                return medianSalary = (copy[(copy.Length - 1) / 2] + copy[(copy.Length + 1) / 2]) / 2;
            }

        }

        static bool IsContinuing()
        {
            ViewMessage("\nValfri tangent påbörjar ny beräkning - [ESC] avslutar programmet.\n", false);
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        static void ViewMessage(string message, bool isError)
        {
            if (isError == true)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}