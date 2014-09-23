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
            // Booleska variabeln loop sätts till true och hela main-metoden nästlas i 
            // en while-loop som fortsätter så länge loop-variabeln fortsätter vara true.
            bool loop = true;
            while (loop == true)
            {
                // Deklarera variabeln numberOfSalaries och sätt värdet 0.
                int numberOfSalaries = 0;

                // Inmatning av antal löner sker nästlat i en while-sats som loopas 
                // innehållet medan numberOfSalaries har ett värde mindre än 2. 
                while (numberOfSalaries < 2)
                {
                    numberOfSalaries = ReadInt("Ange antal löner att mata in: ");

                    // Är det inmatade värdet mindre än 2 skrivs ett meddelande ut med ViewMessage-metoden, 
                    // booleska värdet true skickas med för att visa att det är ett error-meddelande.
                    if (numberOfSalaries < 2)
                    {
                        ViewMessage("\nDu måste mata in minst två löner för att kunna göra en beräkning!\n", true);
                    }
                }

                Console.WriteLine();

                // Deklarera arrayen salaries och läs in värden i den med hjälp av metoden 
                // ReadSalaries, dit numberOfSalaries skickas med som argument. 
                int[] salaries = ReadSalaries(numberOfSalaries);

                // Skriv ut resultat med hjälp av metoden ViewResult, arrayen som vi skapade
                // ovan skickas med som argument. 
                ViewResult(salaries);

                // Avslutningsvis kallar vi på metoden IsContinuing för att fråga användaren 
                // om hen vill göra en ny beräkning eller avsluta programmet.
                loop = IsContinuing();
            }
        }
               
        static int ReadInt(string prompt)
        {
            // Läser in heltal.
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
            // Skapar en array och ger den värden med hjälp av en for-loop.
            int[] salaries = new int[count];
            for (int i = 0; i < count; i++)
            {
                salaries[i] = ReadInt("Ange lön nummer " + (i + 1) + ": ");
            }
            return salaries;
        }

        static void ViewResult(int[] salaries)
        {
            // Visar resultatet. Metoderna Getmedian och GetDispersion 
            // räknar ut medianlön respektive lönespridning.
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
            // Räknar ut medianlön.
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
            // Frågar användaren om hen vill göra en ny beräkning eller avsluta programmet.
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
            // Skriver ut medskickad sträng och formaterar meddelandena olika beroende på om 
            // det är ett error-meddelande eller inte. 
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