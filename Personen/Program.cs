using System;
using System.Diagnostics.Contracts;
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
            int count = 0;

            string[] text =
                System.IO.File.ReadAllLines(datafile);
            List<string> tempReturnName = new List<string>();
            List<string> tempReturnWeightAvg = new List<string>();
            decimal weightTotal = 1;
            //decimal weightAvg = weightTotal / count;


            foreach (var line in text)
            {
                count++;

                string[] temp = line.Split(' ');


                string Name = temp[0];
                string weight = temp[1];
                string age = temp[2];
                string sex = temp[3];


                weightTotal += Convert.ToDecimal(temp[1]);

                if (Name.Contains(q))
                {
                    tempReturnName.Add(Name);
                }


                //if (Convert.ToDecimal(weightTotal) < weightAvg)
                //{
                //    tempReturnWeightAvg.Add("+");
                //}
                //else
                //{
                //    tempReturnWeightAvg.Add("-");
                //}





                //Test Print In Console

                Console.WriteLine("Names containing the query:");
                foreach (var name in tempReturnName)
                {
                    Console.WriteLine(name);
                }

                Console.WriteLine("Weight comparisons:");
                foreach (var comparison in tempReturnWeightAvg)
                {
                    Console.WriteLine(comparison);
                }
            }
        }
    }
}