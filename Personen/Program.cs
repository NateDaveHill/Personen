using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;
using static System.Net.Mime.MediaTypeNames;

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
            List<Data> inputData = new List<Data>();
            decimal avgWeight = Decimal.Zero;
            int ageRangeMale = 0;
            int ageRangeFemale = 0;

            string[] textFile =
                System.IO.File.ReadAllLines(datafile);


            foreach (var line in textFile)
            {
                string[] textSplit = line.Split(" ");

                inputData.Add(new Data
                {
                    Name = textSplit[0],
                    Weight = Decimal.Parse(textSplit[1], CultureInfo.InvariantCulture),
                    Age = Convert.ToInt32(textSplit[2]),
                    Gender = textSplit[3]
                });
            }

            foreach (var person in inputData)
            {
                avgWeight += person.Weight / inputData.Count;
            }

            var sortedPersonDataMale = inputData.OrderBy(x => x.Age).Where(x => x.Gender == "m").ToList();
            var sortedPersonDataFemale = inputData.OrderBy(x => x.Age).Where(x => x.Gender == "w").ToList();

            var combinedSortedList = sortedPersonDataMale.Concat(sortedPersonDataFemale).ToList();

            foreach (var person in combinedSortedList)
            {

                if (person.Name.Contains(q) && person.Gender == "m")
                {
                    ageRangeMale = sortedPersonDataMale.Count(p => p.Age > person.Age) + 1;

                    if (person.Weight > avgWeight)
                    {
                        Console.WriteLine($"{person.Name} {person.Age} {person.Gender} + {ageRangeMale}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} {person.Age} {person.Gender} - {ageRangeMale}");
                    }
                }

                if (person.Name.Contains(q) && person.Gender == "w")
                {
                    ageRangeMale = sortedPersonDataFemale.Count(p => p.Age > person.Age) + 1;

                    if (person.Weight > avgWeight)
                    {
                        Console.WriteLine($"{person.Name} {person.Age} {person.Gender} + {ageRangeMale}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} {person.Age} {person.Gender} - {ageRangeMale}");
                    }
                }
            }
        }
    }
}

