using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PayrollApplication
{
    class Program
    {

        /// <summary>
        /// Proram.cs creates a path for csv file (export, e.g it has its taxes calculated)
        /// Program.cs also creates a path for the initial csv file that needs to be converted (import e.g before taxes are calculated)
        /// Program.cs calls a method that reads the initial csv file (import) and then converts it into a PayRecord list
        /// Program.cs then calls a method that gets the list, calculates the taxes for each employee in that list and outputs it into console/csv file
        /// </summary>
        /// <param name="args"></param>
        /// 


        static void Main(string[] args)
        {
            UI.Program.Main();


            //Getting the path of the csv file
            //First, I am getting the full path of the file, then I am going 3 folders back
            //then I am attaching the csv file to that path
            string full_path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string path_reduced = Path.GetFullPath(Path.Combine(full_path, @"..\..\..\"));
            string csv_FilePath = (path_reduced + @"Import\employee-payroll-data.csv");

            //The csv employee-payroll-data.csv file gets transported into List<PayRecord>
            List<PayRecord> PayRecords = CsvImporter.ImportPayRecords(csv_FilePath);

            //A name of the file that will be used for outputs is created
            //The file name looks like this: {637381283525934083}-records.csv
            //The big number in the middle 637381283525934083 is a unique number that counts the current number of ticks since 1st Jan 1970.
            string filename = (path_reduced + @"Export\");
            filename += ("{" + DateTime.Now.Ticks.ToString() + "}-records.csv"); ;

            //Writing the file. First the Taxes/Gross/Net etc get calculated.
            //Then the calculated Taxes/Gross/Net get written onto a csv file
            PayRecordWriter.Write(filename, PayRecords, true);

            //Information regarding where the csv file can be found at.
            //Added this just in case the csv file cannot be found by the user
            Console.WriteLine("\n\n--------------------------------------");
            Console.WriteLine("The CSV converted file can be found at");
            Console.WriteLine(filename);
            Console.WriteLine("--------------------------------------");

            //Making sure the console doesn't close

            Console.ReadKey();
        }
    }
}
