using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PayrollApplication
{
    /// <summary>
    /// Writes down the calculated taxes for each employee into a csv file and into a Console File.
    /// </summary>
    public class PayRecordWriter
    {

        /// <summary>
        /// This method writes down the calculated taxes for each employee into a csv file and into a Console File.
        /// The taxes are calculated in PayRecord class
        /// The GetDetails() method and GetCsvDetails() method is called from PayRecord class
        /// </summary>
        /// <param name="fileName">The location of the csv file where the calculated taxes for each employee would be</param>
        /// <param name="records">A list of ResidentPayRecords and WorkingHolidayPayRecords</param>
        /// <param name="writeToConsole">Boolean which determines whether the user wants to write something in the console and csv file or only csv file</param>
        /// <returns>void, but all output is in the console and csv file</returns>
        public static void Write(string fileName, List<PayRecord> records, bool writeToConsole)
        {
            //writing to the console if boolean writeToConsole is true
            switch (writeToConsole)
            {
                case true:
                    for (int i = 0; i < records.Count; i++)
                    {
                        Console.WriteLine(records[i].GetDetails());
                    }
                    break;
            }

            //writing the csv file
            StreamWriter stream = new StreamWriter(fileName);


            CsvWriter writer = new CsvWriter(stream, CultureInfo.InvariantCulture);

            writer.WriteField("EmployeeId, Gross, Net, Tax", false);

            for (int i = 0; i < records.Count; i++)
            {
                writer.WriteField("\n" + records[i].GetCsvDetails(), false);
            }
            //closing the writer
            writer.Flush();
            stream.Close();
        }
    }
}