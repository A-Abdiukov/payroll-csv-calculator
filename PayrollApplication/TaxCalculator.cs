namespace PayrollApplication
{
    class TaxCalculator
    {
        /// <summary>
        /// Double below calculates the residential task
        /// The program determines which tax bracket the employee is in
        /// And then calculates the tax according to taht tax bracket
        /// </summary>
        /// <param name="gross">The amount of money the person earnt BEFORE paying taxes</param>
        /// <returns>Calculated tax (Residential Tax)</returns>

        public static double CalculateResidentialTax(double gross)
        {
            //defining variables
            double residential_tax_amount;
            double A;
            double B;

            //assigning default values
            A = 0;
            B = 0;

            //checking which tax bracket the person is in
            if (gross > -1 && gross <= 72)
            {
                A = 0.19;
                B = 0.19;
            }
            else if (gross > 72 && gross <= 361)
            {
                A = 0.2342;
                B = 3.213;
            }
            else if (gross > 361 && gross <= 932)
            {
                A = 0.3477;
                B = 44.2476;
            }
            else if (gross > 932 && gross <= 1380)
            {
                A = 0.345;
                B = 41.7311;
            }
            else if (gross > 1380 && gross <= 3111)
            {
                A = 0.39;
                B = 103.8657;
            }
            else if (gross > 3111 && gross <= 999999)
            {
                A = 0.47;
                B = 352.7888;
            }

            //calculation
            residential_tax_amount = (A * gross) - B;

            //output
            return (residential_tax_amount);
        }
        /// <summary>
        /// Method below calculates the working holiday tax
        /// The program determines which tax bracket the employee is in
        /// And then calculates the tax according to taht tax bracket
        /// </summary>
        /// <param name="gross">The amount of money the person earnt BEFORE paying taxes</param>
        /// <param name="YearToDate">Contains the YearToDate employee pay</param>
        /// <returns>Calculated tax (Working Holiday Tax)</returns>
        public static double CalculateWorkingHolidayTax(double gross, int YearToDate)
        {
            //defining variables
            double working_holiday_tax_amount;
            double tax_percentage;

            //gross and yearToDate combined
            double combined_earnings = gross + YearToDate;

            //assigning default values
            tax_percentage = 0;

            //checking which tax bracket the person is in
            if (combined_earnings > -1 && combined_earnings <= 37000)
            {
                tax_percentage = 0.15;
            }
            else if (combined_earnings > 37000 && combined_earnings <= 90000)
            {
                tax_percentage = 0.32;
            }
            else if (combined_earnings > 90000 && combined_earnings <= 180000)
            {
                tax_percentage = 0.37;
            }
            else if (combined_earnings > 180000 && combined_earnings <= 9999999)
            {
                tax_percentage = 0.45;
            }

            //calculation
            working_holiday_tax_amount = gross * tax_percentage;

            //output
            return (working_holiday_tax_amount);
        }

    }
}
