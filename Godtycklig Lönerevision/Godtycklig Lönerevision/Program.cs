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
            int numberOfSalaries = ReadInt("Ange antal löner att mata in: ");

            while (numberOfSalaries < 2)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nDu måste mata in minst två löner för att kunna göra en beräkning!\n");
                Console.ResetColor();
                numberOfSalaries = ReadInt("Ange antal löner att mata in: ");
                
            }


            ProcessSalaries(numberOfSalaries);


        }

        static int ReadInt(string prompt)
        {           
            while (true)
            {

                try
                {
                    Console.Write(prompt);
                    return int.Parse(Console.ReadLine());                    
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("FEL! {0} kan inte tolkas som ett heltal!");
                    Console.ResetColor();
                }
            }           
        }

        static int ProcessSalaries(int count)
        {
            throw new NotImplementedException();
        }    


    }
}
