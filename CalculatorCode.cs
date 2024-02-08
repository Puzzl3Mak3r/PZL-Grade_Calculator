using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialSAC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Starts
            startUp();
        }

        public static void startUp()
        {
            // Explaining what to do
            Console.WriteLine("Please Select Which type of Data to analyse");
            Console.WriteLine("Press 1 to use pre-collected Data. Press 2 to type up your own Data.");

            // Starts the decision
            string selection = Console.ReadLine();
            if (selection == "1")
            {
                Console.WriteLine("1 pressed. Loading pre-collected");
                int[] arrayData = { 32, 59, 44, 82, 75, 82, 54, 77, 40, 67, 43, 71, 68, 85, 48, 41, 99, 66, 67, 67, 31, 37, 86, 75, 35, 81, 27, 92, 71, 65, 75, 91, 89, 59, 53, 34, 77, 29, 86, 29, 55, 61, 24, 89, 36, 84, 89, 67, 52, 70, 79, 31, 82, 67, 60, 65, 48, 68, 30, 43, 75, 49, 60, 36, 47, 88, 79, 50, 85, 96, 58, 77, 59, 24, 92, 35, 29, 44, 74, 88, 59, 37, 54, 89, 63, 82, 24, 94, 91, 32, 74, 38, 48, 99, 55, 76, 94, 64, 78, 53 };
                startCalculations(arrayData);
            }
            else if (selection == "2")
            {
                Console.WriteLine("2 pressed");
                getData();
            }
            else
            {
                // restart
                Console.WriteLine("Continue from where you left off");
                startUp();
            }
        }

        //Making a public list
        public static void getData()
        {
            // seperator
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Please write your data with a new line for a new value");
            Console.WriteLine("To finish, type 'Finished!!'");
            bool hasFinished = false;
            string currentLine = "";
            List<int> data = new List<int>();
            while (hasFinished == false)
            {
                // Check if they have finished
                currentLine = Console.ReadLine();
                if (currentLine != "Finished!!")
                {
                    int myInt;
                    bool isNumerical = int.TryParse(currentLine, out myInt);
                    if (isNumerical)
                    {
                        if (Convert.ToInt32(currentLine) <= 100 && Convert.ToInt32(currentLine) >= 0)
                        {
                            data.Add(Convert.ToInt32(currentLine));
                        }
                        else { Console.WriteLine(""); Console.WriteLine("Value needs to be 0-100"); Console.WriteLine(""); }
                    }
                    if (!isNumerical)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Please enter a correct value");
                        Console.WriteLine("Write a whole number");
                    }
                }
                else
                {
                    hasFinished = false;
                    Console.WriteLine("");
                    int[] arrayData = data.ToArray();
                    Console.WriteLine("Thank you for using PZL tools");
                    Console.WriteLine("Calculating...");
                    startCalculations(arrayData);
                }
            }
        }

        static void startCalculations(int[] data)
        {
            calMean(data);
            calMode(data);
            calRange(data);
            calFreGrades(data);
            amount(data);
            restart();
        }

        static void amount(int[] data)
        {
            callOutAll("amount of values", data.Length);
        }

        static void calMean(int[] data)
        {
            int sum = 0;
            for (int count=0; count <= data.Length-1; count++)
            {
                sum += data[count];
            }
            float cacheS = (float)Convert.ToDouble(sum);
            float cacheDL = (float)Convert.ToDouble(data.Length);
            float mean = cacheS / cacheDL;
            callOutAll("mean", mean);
        }

        static void calMode(int[] data)
        {
            //From www.geeksforgeeks.org/mode

            int hi = 0;
            int n = data.Length;
            for (int counts = 0; counts <= data.Length - 1; counts++)
            {
                if (data[counts] >= hi)
                {
                    hi = data[counts];
                }
            }

            //
            //

            int t = hi + 1;
            int[] count = new int[t];
            for (int i = 0; i < t; i++)
            {
                count[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                count[data[i]]++;
            }


            int mode = 0;
            int k = count[0];
            for (int i = 1; i < t; i++)
            {
                if (count[i] > k)
                {
                    k = count[i];
                    mode = i;
                }
            }

            callOutAll("mode", mode);
        }

        static void calRange(int[] data)
        {
            int hi = 0;
            int lo = 100;
            for (int count = 0; count <= data.Length - 1; count++)
            {
                if (data[count] >= hi)
                {
                    hi = data[count];
                }
                if (data[count]<=lo)
                {
                    lo = data[count];
                }
            }
            int range = hi - lo;
            callOutAll("range", range);
        }

        static void calFreGrades(int[] data)
        {
            int As = 0;
            int Bs = 0;
            int Cs = 0;
            int Ds = 0;
            for (int count = 0; count <= data.Length - 1; count++)
            {
                if (data[count] <= 25 || data[count] == 25)
                {
                    Ds++;
                }
                else if (data[count] <= 50 || data[count] == 50)
                {
                    Cs++;
                }
                else if (data[count] <= 75 || data[count] == 75)
                {
                    Bs++;
                }
                else
                {
                    As++;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Amount of each grades:");
            callOutAll("As", As);
            callOutAll("Bs", Bs);
            callOutAll("Cs", Cs);
            callOutAll("Ds", Ds);
        }

        static void callOutAll(string func, float value)
        {
            Console.WriteLine("");
            Console.WriteLine("The " + func + " is:");
            Console.WriteLine(value);
        }

        static void restart()
        {
            Console.WriteLine("");
            Console.WriteLine("Would you like to do another?");
            Console.WriteLine("Y / N");
            string strRestart = Console.ReadLine();
            if (strRestart == "Y" || strRestart == "y")
            {
                Console.WriteLine("Restaring");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                startUp();
            }
            else if (strRestart == "N" || strRestart == "n")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Please select Y or N");
                restart();
            }
        }
    }
}
