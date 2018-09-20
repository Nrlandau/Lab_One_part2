/*
Lab 1_p2 by Nicholas Landau

This Program takes two dates and finds out how many days/hours/minutes are between them.

EXAMPLES

 2018/1/1 and 2019/1/1 should return 365 days, 8760 hours, or 525600 minutes
 2000/1/1 and 2001/1/1 should return 366 days, 8784 hours, or 527040 minutes
 1900/1/1 and 1901/1/1 should return 365 days, 8760 hours, or 525600 minutes
 2000/1/1 and 2000/1/1 should return 0 days, 0 hours, or 0 minutes
 1900/1/1 and 1999/12/31 should return  36523 days, 876552 hours, or 52593120 minutes

 */
using System;

namespace Project_Lab_1_p2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable declaration
            int numberOfDays = 0;
            int year1 , year2;
            int month1, month2;
            int day1, day2;
            //Input
            //First Date
            System.Console.WriteLine("Input the first year:");
            year1 = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Input the first month(1-12):");
            month1 = int.Parse(System.Console.ReadLine());
            while(month1 < 1 || month1 > 12)
            {
                System.Console.WriteLine("INPUT A VALID MONTH(1-12)");
                month1 = int.Parse(System.Console.ReadLine());
            }

            System.Console.WriteLine("Input the first day(1-{0}):",getDaysInMonth(month1,year1)); // Displays the proprer number of days in that month.
            day1 =  int.Parse(System.Console.ReadLine());
            while (day1 < 1 || day1 > getDaysInMonth(month1, year1))
            {
                System.Console.WriteLine("INPUT A VALID DAY(1-{0}):",getDaysInMonth(month1,year1));
                day1 =  int.Parse(System.Console.ReadLine());
            }
            //Second Date
            System.Console.WriteLine("Input the second year:");
            year2 = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Input the second month(1-12):");
            month2 = int.Parse(System.Console.ReadLine());
            while(month2 < 1 || month2 > 12)
            {
                System.Console.WriteLine("INPUT A VALID MONTH(1-12)");
                month2 = int.Parse(System.Console.ReadLine());
            }

            System.Console.WriteLine("Input the second day(1-{0}):",getDaysInMonth(month2,year2));
            day2 =  int.Parse(System.Console.ReadLine());
            while (day2 < 1 || day2 > getDaysInMonth(month2, year2))
            {
                System.Console.WriteLine("INPUT A VALID DAY(1-{0}):",getDaysInMonth(month2,year2));
                day2 =  int.Parse(System.Console.ReadLine());
            }
            
            //Calculate
            numberOfDays = calcDays(year1, month1, day1, year2, month2, day2);

            //Output
            System.Console.WriteLine("The difference between {0}/{1}/{2} and {3}/{4}/{5} is {6} days, {7} hours, or {8} minutes.", year1, month1,day1, year2, month2, day2, numberOfDays, numberOfDays * 24, numberOfDays * 24 * 60);
            

        }
        static bool isLeapYear(int year) //Leap years happen every 4 years unless the year is a multiple of 100 but not a multiple of 400.
        {
            if(year % 4 == 0)
                if(year % 100 != 0 || year % 400 == 0)
                    return true;
             return false;
        }

        static int getDaysInMonth(int month, int year) 
        {
            switch(month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                return 31;
                case 4: case 6: case 9: case 11:
                return 30;
                case 2:
                return isLeapYear(year) ? 29 : 28;
                default:
                return 0;
            }
        }

        static int calcDays(int year1, int month1, int day1, int  year2, int month2, int day2) // Return the difference between two dates.
        {
            if(year2 < year1 || year2 == year1 && (month2 < month1 || month2 == month1 && (day2< day1))) //the function only works if the first date is before the second so it calls itself with the flipped dates.
            {
                return calcDays(year2, month2, day2, year1, month1, day1);
            }
            int numDays = 0;   
            //If the years are not the same, the program adds from the first date to the end of the first year, the begining of the second year to the second date, and all the years between.
            if(year1 != year2 ) 
            {
                numDays += calcDaysBetween(year1,month1,day1,12,31) ;
                numDays += calcDaysBetween(year2,1,1,month2,day2) + 1;
                for(int i =year1 + 1; i < year2; i++)
                {
                    numDays += isLeapYear(i) ? 366 :365;
                }
                return numDays;
            }

            return calcDaysBetween(year1,month1,day1,month2,day2);
        }   
        static int calcDaysBetween(int year, int month1, int day1, int month2, int day2) // Returns the difference between two dates in the same year.
        {
            int numDays = 0;
            if(month1 == month2)
            {
                return  day2 - day1;
            }
            numDays += getDaysInMonth(month1, year) - day1;
            for(int i = month1 + 1; i < month2 ; i++)
            {
               numDays += getDaysInMonth(i, year);
            }
            return numDays + day2;
        }
    }
}
