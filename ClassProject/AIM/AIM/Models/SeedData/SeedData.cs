using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AIM.Data;
using Microsoft.VisualBasic.FileIO;

namespace AIM.Models.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AIMDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AIMDbContext>>()))
            {
                // Look for any entries.
                //if (context.DodicLibrary.Any())
                //{
                //    return;   // DB has been seeded
                //}
                                
                TextFieldParser parser = new TextFieldParser(@"C:\Users\adam\Documents\Adam\MSSA\Project\AIM\AIM\Models\SeedData\DodicLibrary.csv");
                parser.HasFieldsEnclosedInQuotes = true; //Account for commas in quotes
                parser.SetDelimiters(","); //DODIC/nomenclature pairs are split by comma

                string[] parsedData; //Array to hold data read from csv

                while (!parser.EndOfData)
                {
                    parsedData = parser.ReadFields(); //Input each string into array, split at the commas, and don't ignore blank entries

                    context.DodicLibrary.AddRange( //Add new db entry
                        new DodicLibrary
                        {
                            Dodic = parsedData[0],
                            Nomenclature = parsedData[1]
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
