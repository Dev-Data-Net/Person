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

                Console.WriteLine("\nPodaj miejsce swojego urodzenia: \t ");
                var placeOfBirth = Console.ReadLine();

                Console.WriteLine("\nPodaj swój rok urodzenia: \t");
                var yearOfBirth = GetYear();

                Console.WriteLine("\nPodaj swój miesiąc urodzenia (wpisz od 1 do 12): \t");
                var monthOfBirth = GetMonth();

                Console.WriteLine("\nPodaj swój dzień urodzenia (wpisz od 1 do 31): \t");
                var dayOfBirth = GetDayOfMonth(yearOfBirth,monthOfBirth);

        
                var birthDate = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
                var currentDate = DateTime.Now;
                Console.WriteLine($"Dzisiejsza data i czas to: {currentDate}");
                Console.WriteLine();

                var age = currentDate.Year - birthDate.Year;

                if (birthDate.Date > currentDate.AddYears(-age))
                {
                    age--;
                }

                Console.WriteLine($" Masz na imię: {surname}. \n Miejsce urodzenia to: {placeOfBirth}. \n Twoja data urodzenia to: {dayOfBirth}-{monthOfBirth}-{yearOfBirth}. \n Masz: {age} lat(a).\n ");
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

        private static int GetDayOfMonth(int yearOfBirth, int monthOfBirth)
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int day) || day < 1 || day > DateTime.DaysInMonth(yearOfBirth, monthOfBirth))
                {
                    Console.WriteLine("Podałeś nieprawidłowe dane. Spróbuj ponownie");
                    continue;
                }
                return day;
            }
        }

        private static int GetMonth()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int month) || month > 12 || month < 1)
                {
                    Console.WriteLine("Podałeś nieprawidłowe dane. Spróbuj ponownie");
                    continue;
                }
                return month;
            }
        }

        private static int GetYear()
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int year) || year > DateTime.Now.Year)
                {
                    Console.WriteLine("Podałeś nieprawidłowe dane. Spróbuj ponownie");
                    continue;
                }
                return year;
            }
        }
    }
}