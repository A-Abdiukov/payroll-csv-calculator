using System;

namespace PayrollApplication
{
    class WorkingHolidayPayRecord : PayRecord
    {
        // defining private fields

        private int YearToDate;
        private int visa;

        /// <summary>
        /// Gets the information from the private field and applies it to the public field.
        /// </summary>
        //defining public fields
        public int YearToDate_public
        {
            get { return YearToDate; }
            private set { YearToDate = value; }
        }
        /// <summary>
        /// Gets the information from the private field and applies it to the public field.
        /// </summary>
        public int Visa
        {
            get { return visa; }
            private set { visa = value; }
        }

        // defining Tax public field.
        /// <summary>
        /// Tax public double gets its information from TaxCalculator method.
        /// Thus, by calling this field, the Tax gets calculated.
        /// The idea is that a WorkingHolidayPayRecord type should be able to calculate its Tax by adding ".Tax"
        /// </summary>
        /// <returns>Calculated tax (Working Holiday Tax)</returns>
        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate_public);
            }
        }


        // defining constructor

        /// <summary>
        /// Constructor gets its information from PayRecord.cs consturctor
        /// And then adds variables that are specific to WorkingHolidayPayRecord, such as Visa, YearToDate
        /// </summary>
        /// <param name="id">Unique identifier of the employee.</param>
        /// <param name="hours">Contains a list of hours an employee worked.</param>
        /// <param name="rates">Contains a lsit of rates an employee worked.</param>
        /// <param name="visa">Contains information regarding which visa the employee worked under.</param>
        /// <param name="YearToDate">Contains the YearToDate employee pay</param>
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int YearToDate) : base(id, hours, rates)
        {
            this.visa = visa;
            this.YearToDate = YearToDate;
        }

        /// <summary>
        /// The method gets its information from GetDetails method in the PayRecord.cs
        /// Then it adds unique information that is specific to WorkingHolidayPayRecord.cs , such as Visa, YearToDate 
        /// </summary>
        /// <returns>Returns information about id, hours, rates, visa and YearToDate. Information is styled to be displayed in Console.</returns>
        //defining methods
        public override string GetDetails()
        {
            string output = base.GetDetails();

            output += "\nVISA:   " + Visa;

            //for some bizzare reason, for the output, the YTD has to be combined with gross
            //despite the fact that YTD is integer, and gross is double???
            double YTD_output = YearToDate_public + Gross;

            output += "\nYTD:    " + String.Format("{0:C}", YTD_output);
            return output;
        }

    }
}
