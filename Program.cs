using System;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics.Metrics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace L1;

class Program
{
    static void Main(string[] args) //This Main for double/list operations
    {
        Console.WriteLine("Welcome to the high/low number program!\n\nTasks 1 & 2:");
        //loop until acceptable input is received
        //Then print the difference between the two numbers
        double low = GetLowNumber();       
        double high = GetHighNumber(low);       
        Difference(low, high);

        Console.WriteLine("\nTask 3");
        //Makes an array of numbers from low to high inputs
        //NOTE: numbers are in increments of 1.0
        List<double> numberList = MakeList(low, high);

        //Write to a txt file "numbers.txt" in reverse order
        string document = "numbers.txt";
        WriteListToFile(document, numberList);

        Console.WriteLine("\nAdditional Tasks:");
        //Read 'numbers.txt' from file to screen
        ReadAndCalculate(document);
        FindPrimeNumbers(numberList);

        Console.ReadKey();
    }
    static double GetLowNumber() //for int operations
    {
        // CHANGED TO ALLOW FOR DOUBLE
        //have user enter low number. Verify it's a positive number. return value
        //Otherwise alert invalid and ask again
        while (true)
        {
            
            Console.WriteLine("**Please enter a low positive number...**");
            string userLow = Console.ReadLine();
            if (double.TryParse(userLow, out double low) & (low >= 0))
            {
                Console.WriteLine("\nYour low number is: " + low);
                return low;
            }
            else
            {
                Console.WriteLine("!!! Invalid Input !!!");
            }
        }
    }
    static double GetHighNumber(double low)
    {
        // CHANGED TO ALLOW FOR DOUBLE
        //Ask user for high number. Verify it's greater than their low number.
        //Return value
        //otherwise return invalid and repeat
        while (true)
        {
            Console.WriteLine("**Please enter a high number...**");
            string userHigh = Console.ReadLine();
            if (double.TryParse(userHigh, out double high) & (high > low))
            {
                Console.WriteLine("\nYour high number is: " + high);
                return high;
            }
            else
            {
                Console.WriteLine("!!! Invalid Input !!!");
            }
        }

    }
    static void Difference(double l, double h)
    {
        // CHANGED TO ALLOW FOR DOUBLE
        //determine difference between low and high, and write to screen
        Console.WriteLine("\nThe difference between " + l + " and " + h + " is: " + (h - l));
    }
    static List<double> MakeList(double low, double high)
    {
        //creates a list of all WHOLE numbers FROM low to high
        //THIS INCLUDES THE LOW AND HIGH NUMBERS
        List<double> numberList = new List<double>();
        // counter i = array index
        // counter j = current number
        for (double j = low; j <= (high); j++)
        {
            numberList.Add(j);
        }
        return numberList;
    }
    static void WriteListToFile<T>(string document, List<T> list)
    {
        //opens a file called numbers.txt
        using (StreamWriter writer = new StreamWriter(document))
        {
            for (int i = list.Count-1; i>=0; i--)
            {
                writer.WriteLine(list[i]);
            }
            Console.WriteLine("** 'Numbers.txt' file created **"); //confirmation
        }
    }
    static void ReadAndCalculate(string document)
    {
        Console.WriteLine("Reading document 'numbers.txt'...");
        string item;
        double sum = 0;
        using (StreamReader reader = new StreamReader(document))
        {
            Console.WriteLine("The numbers written in the file are:\n");
            //Reads document line by line until a blank line is reached.
            while ((item = reader.ReadLine()) != null)
            {
                //Write line to screen, then convert to int and add to sum variable
                Console.WriteLine("\t" + item);
                if (double.TryParse(item, out double number))
                {
                    sum += number;
                }
                else
                {
                    Console.WriteLine("!! Error: File contains non numbers !!");
                }
            }
            //Tells user the sum of the numbers in the document
            Console.Write("\nThe sum of these numbers is : " + sum);
        }
    }
    static void FindPrimeNumbers(List<double> numberList)
    {
        int low = (int)Math.Ceiling(numberList[0]);
        int high = (int)Math.Floor(numberList.Last());
        int found = 0;
        Console.WriteLine("\nLets find any prime numbers between " + numberList[0] + " and " + numberList.Last() + "\n");
        for (int i = low; i <= high; i++)
        {
            if (PrimeNumber(i))
            {
                Console.WriteLine("\t" + i);
                found++;
            }
        } 
        if (found == 0)
        {
            Console.WriteLine("\nThe list does not contain any prime numbers");
        }
    }
    static bool PrimeNumber(int x)
    {
        //returns false if non prime number condition found
        //1 is not prime
        if (x <= 1)
        {
            return false;
        }
        //Loop to divide number by each number from 2 - sqrt of itself.
        for (int divisor = 2; divisor <= Math.Sqrt(x); divisor++)
        {
            //modulus determins if the operation leaves a remainder. 
            //if the number is divisible, return false
            if (x % divisor == 0)
            {
                return false;
            }
        }
        //if all checks pass, return true
        return true;
    }

    //!!!!!!!!!! TO USE THE INT / ARRAY VERSION, COMMENT EVERYTHING 
    // ABOVE THIS LINE AND UNCOMMENT EVERYTHING BELOW THIS LINE !!!!!!!!!!


    //static void Main(string[] args) //This Main for int/array operations
    //{
    //    Console.WriteLine("Welcome to the high/low number program!\n\nTasks 1 & 2:");
    //    //loop until acceptable input is received
    //    //Then print the difference between the two numbers
    //    int low = GetLowNumber();
    //    int high = GetHighNumber(low);
    //    Difference(low, high);

    //    Console.WriteLine("\nTask 3");
    //    //Makes an array of numbers BETWEEN low and high inputs
    //    int[] numbersBetween = MakeArr(low + 1, high - 1);
    //    // Makes an array INCLUDING low and high inputs
    //    //int[] numbersInc = MakeArr(low, high);

    //    //Write to a txt file "numbers.txt" in reverse order
    //    string document = "numbers.txt";
    //    WriteArrToFile(document, numbersBetween);

    //    Console.WriteLine("\nAdditional Tasks:");
    //    //Read 'numbers.txt' from file to screen
    //    ReadAndCalculate(document);
    //    Console.ReadKey();
    //}
    //static int GetLowNumber() //for int operations
    //{
    //    //have user enter low number. Verify it's a positive number. return value
    //    //Otherwise alert invalid and ask again
    //    while (true)
    //    {
    //        int low;
    //        Console.WriteLine("**Please enter a low positive number...**");
    //        string userLow = Console.ReadLine();
    //        if (int.TryParse(userLow, out low) & (low >= 0))
    //        {
    //            Console.WriteLine("\nYour low number is: " + low);
    //            return low;
    //        }
    //        else
    //        {
    //            Console.WriteLine("!!! Invalid Input !!!");
    //        }
    //    }
    //}
    //static int GetHighNumber(int low)
    //{
    //    //Ask user for high number. Verify it's greater than their low number.
    //    //Return value
    //    //otherwise return invalid and repeat
    //    while (true)
    //    {
    //        int high;
    //        Console.WriteLine("**Please enter a high number...**");
    //        string userHigh = Console.ReadLine();
    //        if (int.TryParse(userHigh, out high) & (high > low))
    //        {
    //            Console.WriteLine("\nYour high number is: " + high);
    //            return high;
    //        }
    //        else
    //        {
    //            Console.WriteLine("!!! Invalid Input !!!");
    //        }
    //    }

    //}
    //static void Difference(int l, int h)
    //{
    //    //determine difference between low and high, and write to screen
    //    Console.WriteLine("\nThe difference between " + l + " and " + h + " is: " + (h - l));
    //}
    //static int[] MakeArr(int low, int high)
    //{
    //    //creates an array of all numbers FROM low to high
    //    //THIS ARRAY INCLUDES THE LOW AND HIGH NUMBERS
    //    int size = (high - low) + 1;
    //    int[] newArr = new int[size];
    //    // counter i = array index
    //    // counter j = current number
    //    for (int i = 0, j = low; j < (high+1); i++, j++)  
    //    {
    //        //Console.WriteLine("Index: " + i + "     #: " + j);
    //        newArr[i] = j;
    //    }
    //    return newArr;
    //}
    //static void WriteArrToFile(string document, int[] item)
    //{
    //    //opens a file called numbers.txt
    //    using (StreamWriter writer = new StreamWriter(document))
    //    {
    //        //iiterate through array in reverse order and write to numbers.txt
    //        for (int i = (item.Length)-1; i>=0; i--)
    //        {
    //            writer.WriteLine(item[i]);
    //        }
    //        Console.WriteLine("** 'Numbers.txt' file created **"); //confirmation
    //    }
    //}
    //static void ReadAndCalculate(string document)
    //{
    //    string item;
    //    double sum = 0;
    //    using (StreamReader reader = new StreamReader(document))
    //    {
    //        Console.WriteLine("The numbers written in the file are:");
    //        //Reads document line by line until a blank line is reached.
    //        while ((item = reader.ReadLine()) != null)
    //        {
    //            //Write line to screen, then convert to int and add to sum variable
    //            Console.WriteLine("\t"+item);
    //            if (double.TryParse(item, out double number))
    //            {
    //                sum += number;
    //            }
    //            else
    //            {
    //                Console.WriteLine("!! Error: File contains non numbers !!");
    //            }
    //        }
    //        //Tells user the sum of the numbers in the document
    //        Console.Write("\nThe sum of these numbers is : " + sum);
    //    }
    //}

}
