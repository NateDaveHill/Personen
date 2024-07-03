using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;

namespace Personen
{
    public class Program
    {
        static void Main(string[] args)
        {
            searchPerson(@"C:\Users\natha\OneDrive\Desktop\00_Temp\03_Projects\Personen\Personen\input.txt", "Andre");
        }

        public static void searchPerson(string datafile, string q)
        {
            decimal avgWeight = 0;
            decimal tempAvgWeight = 0;

            int ageCurrentPerson = 0;
            int agePreviousPerson = 0;


            string[] textFile =
                System.IO.File.ReadAllLines(datafile);

            string[] itemsPerLine = new string[] { };

            for (int i = 0; i < textFile.Length; i++)
            {
                itemsPerLine = textFile[i].Split(' ');
                tempAvgWeight += decimal.Parse(itemsPerLine[1], CultureInfo.InvariantCulture);
                avgWeight = tempAvgWeight / textFile.Length;
            }

            for (int i = 0; i < textFile.Length; i++)
            {
                var range = 1;

                var currentLine = textFile[i];
                var currentLineSplit = textFile[i].Split(' ');
                ageCurrentPerson = Convert.ToInt32(itemsPerLine[2]);

                for (int j = 0; j < textFile.Length; j++)
                {
                    
                    if (ageCurrentPerson < agePreviousPerson)
                    {
                        Console.WriteLine($"{textFile[i]} is older than the previous person.");
                        agePreviousPerson = ageCurrentPerson;
                        range --;
                    }

                }


                //Testing

                

            }












































            //List<string> tempReturnName = new List<string>();
            //List<string> tempReturnWeightAvg = new List<string>();
            //decimal weightTotal = 1;
            ////decimal weightAvg = weightTotal / count;

            //string[] temp = new []{};


            //foreach (var line in text)
            //{

            //    tempReturnWeightAvg 
            //    count++;

            //    string[] temp = line.Split(' ');


            //    string Name = temp[0];
            //    string weight = temp[1];
            //    string age = temp[2];
            //    string sex = temp[3];


            //    weightTotal += Convert.ToDecimal(temp[1]);

            //    if (Name.Contains(q))
            //    {
            //        tempReturnName.Add(Name);
            //    }


            //    //if (Convert.ToDecimal(weightTotal) < weightAvg)
            //    //{
            //    //    tempReturnWeightAvg.Add("+");
            //    //}
            //    //else
            //    //{
            //    //    tempReturnWeightAvg.Add("-");
            //    //}

            //    //Test Print In Console

            //    Console.WriteLine("Names containing the query:");
            //    foreach (var name in tempReturnName)
            //    {
            //        Console.WriteLine(name);
            //    }

            //    Console.WriteLine("Weight comparisons:");
            //    foreach (var comparison in tempReturnWeightAvg)
            //    {
            //        Console.WriteLine(comparison);
            //    }
            //}
        }
    }
}