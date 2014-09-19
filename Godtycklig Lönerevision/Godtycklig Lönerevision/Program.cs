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
            while (true)
            {
                int numberOfSalaries = ReadInt("Ange antal löner att mata in: ");
                while (numberOfSalaries < 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nDu måste mata in minst två löner för att kunna göra en beräkning!\n");
                    Console.ResetColor();
                    numberOfSalaries = ReadInt("Ange antal löner att mata in: ");
                }

                // Kalla på metoden ProcessSalaries.          
                Console.WriteLine();
                ProcessSalaries(numberOfSalaries);

                // Tryck på escape för att avsluta, valfri knapp startar om.
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nValfri tangent påbörjar ny beräkning - [ESC] avslutar programmet.\n");
                Console.ResetColor();
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    return;
                }
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
                    return int.Parse(temp);                    
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("FEL! \"{0}\" kan inte tolkas som ett heltal!", temp);
                    Console.ResetColor();
                }
            }           
        }

        static void ProcessSalaries(int count)
        {
            // Skapa arrayen salaries och ge den värden.
            int[] salaries = new int[count];
            for (int i = 0; i < count; i++)
			{			
            salaries[i] = ReadInt("Ange lön nummer " + (i + 1) + ": ");
            }

            // Kopiera array salaries till salariesCopy för senare redovisning.
            int[] salariesCopy = new int[count];
            Array.Copy(salaries, salariesCopy, count);

            // Sortera salaries.
            Array.Sort(salaries);
            Console.WriteLine();

            // Lite variabler.
            int medianSalary;
            int meanSalary = (int)salaries.Average();
            int salarySpread = salaries.Max() - salaries.Min();

            // Räkna ut median.
            if (count % 2 != 0)
            {
                medianSalary = salaries[count / 2];
            }
            else
            {
                medianSalary = (salaries[(count - 1) / 2] + salaries[(count + 1) / 2]) / 2;
            }

            

            Console.WriteLine("\n---------------------------\n");
            Console.WriteLine("Medianlön:     {0,5:c0}", medianSalary);
            Console.WriteLine("Medellön:      {0,5:c0}", meanSalary);
            Console.WriteLine("Lönespridning: {0,5:c0}", salarySpread);
            Console.WriteLine("\n---------------------------\n");

            // Skriv ut alla löner, i inmatad ordning, tre på varje rad.
            for (int i = 0; i < salariesCopy.Length; i++)
                {
                    Console.Write("{0,8}", salariesCopy[i]);
                    if ((i % 3) == 2) 
                    {
                        Console.WriteLine();
                    }
                }
            Console.WriteLine();
        }    


    }
}
