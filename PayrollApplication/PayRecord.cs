using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PayrollApplication
{
    /// <summary>
    /// Abstract class that is used as a base for other classes
    /// </summary>
    abstract public class PayRecord
    {
        /// <summary>
        ///For each id there might be multiple hours and rates
        ///So for instance for ID 1 there are many hours and rates:
        /// ID  HR  RATE
        /// 1,  2,  25
        /// 1,  3,  25
        /// 1,  3,  25
        /// 1,  4,  25
        /// 1,  5,  32
        /// That is why _hours and _rates are arrays
        /// </summary>
        protected double[] _hours;
        /// <summary>
        /// Contains an array of different rates an employee has worked
        /// </summary>
        protected double[] _rates;
        private int id;


        //Defining public fields

        /// <summary>
        ///Tax is used as an abstract class. Later, in WorkingHolidayPayRecord and ResidentPayRecord this class gets overwritten
        ///for specific tax calculations, as WorkingHoliday and ResidentPay have different tax rates.
        /// </summary>
        /// <returns> Tax calculated (it is calculated in other classes, this is just the abstract variable) </returns>
        public abstract double Tax
        {
            get;
        }

        /// <summary>
        /// Id is used for id of a specific employee. For one Id, there might be many different hours and rates.
        /// </summary>
        /// <returns>The value of public int Id. This value is gathered from private int id. </returns>

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        /// <summary>
        /// Net is calculated by getting the difference between the total gross amount of money earned = 'Gross', and the tax paid = 'Tax'.
        /// </summary>
        /// <returns>The amount left after paying tax.</returns>

        public double Net
        {
            get
            {
                double output = Gross - Tax;
                return output;
            }

        }


        /// <summary>
        /// Gross gets calculated in the following way
        /// Each hour gets multiplied by the corresponding rate e.g :
        /// <example>_hours[4] * _rates[4]</example>
        /// And then the result of calculation gets added to the Gross value
        /// </summary>
        /// <returns>The amount of money the person earnt BEFORE paying taxes.</returns>
        /// <remarks>As soon as the amount of hours becomes 0, the Gross calculation finishes. This can create problems if someone entered the amount of hours as 0.</remarks>

        public double Gross
        {
            get
            {

                //Defining default values 
                double gross = 0;
                bool ExitTheLoop = false;
                // Calculation 
                for (int i = 0; ExitTheLoop == false; i++)
                {
                    switch (_hours[i])
                    {
                        case 0:
                            ExitTheLoop = true;
                            break;
                        default:
                            gross += _hours[i] * _rates[i];
                            break;
                    }
                }

                return gross;
            }
        }

        /// <summary>
        /// Defining base constructor.
        /// WorkingHolidayPayRecord, ResidentPayRecord use this base constructor, and then add on some values to fit their needs.
        /// </summary>
        /// <param name="id">Unique identifier of the employee</param>
        /// <param name="hours">Contains a list of hours an employee worked.</param>
        /// <param name="rates">Contains a list of rates an employee worked.</param>


        public PayRecord(int id, double[] hours, double[] rates)
        {
            this.id = id;
            _hours = hours;
            _rates = rates;
        }


        /// <summary>
        /// Defining base output method.
        /// WorkingHolidayPayRecord, ResidentPayRecord use this base output string, and then modify it to fit their needs.
        /// Gross, Net and Tax get converted into currency format with {0:C}
        /// </summary>
        /// <returns>All employee details get outputted into the console format.</returns>
        public virtual string GetDetails()
        {
            string output;

            output = "\n ---------- EMPLOYEE: " + Id + " ----------";
            output += "\nGROSS:  " + String.Format("{0:C}", Gross);
            output += "\nNET:    " + String.Format("{0:C}", Net);
            output += "\nTAX:    " + String.Format("{0:C}", Tax);
            return output;
        }


        /// <summary>
        /// Defining the output method/string that is used to output into a csv file.
        /// This method/string is different from GetDetails(), as GetDetails() outputs it in the console format, whereas this outputs it into a csv file format
        /// Gross, Net and Tax get converted into currency format with Math.Round(Gross, 2)
        /// </summary>
        /// <returns>Gross, Net and Tax of all employees get outputted into csv format.</returns>

        public virtual string GetCsvDetails()
        {
            string output;
            output = Id.ToString() + ",";
            output += Math.Round(Gross, 2) + ",";
            output += Math.Round(Net, 2) + ",";
            output += Math.Round(Tax, 2);
            return output;
        }


    }
}
