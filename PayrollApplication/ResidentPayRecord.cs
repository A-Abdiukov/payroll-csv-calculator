namespace PayrollApplication
{
    class ResidentPayRecord : PayRecord
    {
        /// <summary>
        /// Defining Tax public field
        /// It gets its information from TaxCalculator method
        /// Thus, by calling this field, the Tax gets calculated.
        /// The idea is that a ResidentPayRecord type should be able to calculate its Tax by adding ".Tax"
        /// </summary>
        /// <returns>Calculated tax (Residential Tax)</returns>

        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateResidentialTax(Gross);

            }
        }
        /// <summary>
        /// Calling a constructor that retrieves all values from the base PayRecord.cs constructor.
        /// </summary>
        /// <param name="id">Unique identifier of the employee</param>
        /// <param name="hours">Contains a list of hours an employee worked.</param>
        /// <param name="rates">Contains a list of rates an employee worked.</param>
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates)
        {

        }

    }
}
