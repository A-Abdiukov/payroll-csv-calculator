using System;
using CsvHelper;
using CSV;
using System.Reflection;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace ReusableComponentsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //checking the CSV writer
            string output_csv = Path.GetFullPath(Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"..\..\..\")) + @"Export\" + "{" + DateTime.Now.Ticks.ToString() + "}-records.csv";
            StreamWriter stream = new StreamWriter(output_csv);

            CsvHelper.CsvWriter writer = new CsvWriter(stream, CultureInfo.InvariantCulture);

            writer.WriteField("hello");
            writer.WriteField("how");
            writer.WriteField("are");
            writer.WriteField("you");
            writer.WriteField("\n Great!",false);
            writer.WriteField("I");
            writer.WriteField("am");
            writer.WriteField("great");

            writer.Flush();
            stream.Close();


            //checking the CSV reader
            string csv_file_path = Path.GetFullPath(Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"..\..\..\")) + @"Import\employee-payroll-data.csv";
            
            CSV.CsvReader reader = new CSV.CsvReader(csv_file_path, Encoding.Default, '\n', ',', 1);

            Console.WriteLine(string.Join("\t", reader.Header));

            foreach (var row in reader.ReadRows())
            {
                Console.WriteLine(string.Join("\t", row));
            }

            Console.ReadKey();
        }



    }
}


