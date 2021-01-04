using System.Collections.Generic;
using System.Text;

namespace PayrollApplication
{
    /// <summary>
    /// The class reads the csv file 
    /// </summary>
    public class CsvImporter
    {

        /// <summary>
        /// All Import Pay Records does - call another function and gets its output from there.
        /// csv_FilePath is gathered from Program.cs
        /// </summary>
        /// <param name="csv_FilePath">The path of the csv file that needs to be read and converted. This document does not have its taxes calculated.</param>
        /// <returns> List PayRecord which contains a list of 'ResidentPayRecord's and 'WorkingHolidayPayRecord's </returns>
        public static List<PayRecord> ImportPayRecords(string csv_FilePath)
        {
            List<PayRecord> output = ReadFileContents(csv_FilePath);
            return output;
        }


        /// <summary>
        /// csv_FilePath is gathered from ImportPayRecords which gets it from Program.cs
        /// This method reads out the csv file employee-payroll-data.csv
        /// Afterwards, each line of the csv file gets separated into variables = id, hours, rates, visa, YearToDate
        /// These variables get sent to the createPayRecord()
        /// The createPayRecord() method outputs either ResidentPayRecord object or WorkingHolidayPayRecord
        /// Afterwards, ResidentPayRecord/WorkingHolidayPayRecord get added to the List PayRecord output.
        /// </summary>
        /// <param name="csv_FilePath">The path of the csv file that needs to be read and converted. This document does not have its taxes calculated.</param>
        /// <returns> List PayRecord , which contains many ResidentPayRecord/WorkingHolidayPayRecord objects.</returns>

        static List<PayRecord> ReadFileContents(string csv_FilePath)
        {
            //defining output
            List<PayRecord> output = new List<PayRecord>();

            //defining variables where information will be divided into
            int id = 0;
            double[] hours = new double[100];
            double[] rates = new double[100];
            string visa = "";
            string YearToDate = "";
            int array_loop_counter = 0;
            //checking id is 1, because the first id is 1 and we are checking against it for changes
            int checking_id = 1;

            // creating the reader that extracts the file location from csv_FilePath created in Program.cs
            CSV.CsvReader reader = new CSV.CsvReader(csv_FilePath, Encoding.Default, '\n', ',', 1);

            //for loop is active until the line is empty
            foreach (var line in reader.ReadRows())
            {
                id = int.Parse(line[0]);
                if (id != checking_id)
                {
                    //if the id has changed, we are adding the new item to the list
                    //note that checking_id is used, because id has changed (e.g if the id has changed from 1 to 2, we want to add an item with id 1, not with new ID 2)

                    output.Add(createPayRecord(checking_id, hours, rates, visa, YearToDate));

                    //and then we are resetting all values
                    hours = new double[100];
                    rates = new double[100];
                    visa = "";
                    YearToDate = "";
                    array_loop_counter = 0;
                }
                //Gathering all the values from the line
                hours[array_loop_counter] = double.Parse(line[1]);
                rates[array_loop_counter] = double.Parse(line[2]);
                visa = line[3];
                YearToDate = line[4];
                array_loop_counter++;
                //checking id gets reset
                checking_id = id;
            }
            //adding information about the last PayRecord collected.
            output.Add(createPayRecord(checking_id, hours, rates, visa, YearToDate));


            return output;
        }

        /// <summary>
        /// All of the variables ara retrieved from ReadFileContents()
        /// The program then determines whether the tax should be calculated by the Working Holiday rate or by the Resident Pay rate
        /// The program determines that by looking at the visa = if something was entered into a visa field, the program determines it is a Working Holiday rate
        /// If nothing was entered into the visa field, then it is a Resident Pay rate.
        /// </summary>
        /// <param name="id">Unique identifier of the employee.</param>
        /// <param name="hours">Contains a list of hours an employee worked.</param>
        /// <param name="rates">Contains a lsit of rates an employee worked.</param>
        /// <param name="visa">Contains information regarding which visa the employee worked under.</param>
        /// <param name="YearToDate">Contains the YearToDate employee pay</param>
        /// <returns>Either a ResidentPayRecord or WorkingHolidayPayRecord</returns>

        public static PayRecord createPayRecord(int id, double[] hours, double[] rates, string visa, string YearToDate)
        {
            PayRecord output;
            switch (visa.Length)
            {
                case 0:
                    output = new ResidentPayRecord(id, hours, rates);
                    break;
                default:
                    output = new WorkingHolidayPayRecord(id, hours, rates, int.Parse(visa), int.Parse(YearToDate));
                    break;
            }
            return output;

        }

    }
}