using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Podaj swoje imię: \t ");
                var surname = Console.ReadLine();

                Console.WriteLine("Podaj miejsce swojego urodzenia: \t ");
                var placeOfBirth = Console.ReadLine();

                Console.WriteLine("Podaj swój rok urodzenia: \t");
                var yearOfBirth = int.Parse(Console.ReadLine());

                int monthOfBirth;
                do
                {
                    Console.WriteLine("Podaj swój miesiąc urodzenia (wpisz od 1 do 12): \t");
                    monthOfBirth = int.Parse(Console.ReadLine());

                    if (monthOfBirth < 1 || monthOfBirth > 12)
                    {
                        Console.WriteLine("Błędny miesiąc urodzenia. Podaj wartość od 1 do 12.");
                    }
                } 
                while (monthOfBirth < 1 || monthOfBirth > 12);

                int dayOfBirth;
                do
                {
                    Console.WriteLine("Podaj swój dzień urodzenia (wpisz od 1 do 31): \t");
                    dayOfBirth = int.Parse(Console.ReadLine());

                    if (dayOfBirth < 1 || dayOfBirth > 31)
                    {
                        Console.WriteLine("Błędny dzień urodzenia. Podaj wartość od 1 do 31.");
                    }
                } while (dayOfBirth < 1 || dayOfBirth > 31);

                var birthDate = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
                var currentDate = DateTime.Today;
                Console.WriteLine($"Dzisiejsza data to: {currentDate}");
                Console.WriteLine();

                var age = currentDate.Year - birthDate.Year;

                if (birthDate.Date > currentDate.AddYears(-age))
                {
                    age--;
                }

                Console.WriteLine($" Masz na imię: {surname}. \n Miejsce urodzenia to: {placeOfBirth}. \n Twoja data urodzenia to: {dayOfBirth}-{monthOfBirth}-{yearOfBirth}. \n Masz: {age} lat.\n ");
            }
            catch (Exception ex)
            {
                //logowanie do pliku
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}