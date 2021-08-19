# Payroll tax assistant

Application takes in a .csv file that contains information about employees (number of hours worked, visa type, hourly rate, ytd). The appropriate taxes are then calculated for different visa types/income brackets. Afterwards, a new .csv file is created that contains the calculated taxes, the gross pay, and the net pay. Could be useful for accountants.

## How to set up:

1. Open the MyPaySolution.sln with Visual Studio 2019.

2. (Optional) Change the input csv file. The file is located at MyPayProject\Import\employee-payroll-data.csv

3. Start the application.


## Credits

- CSV.NET - > https://github.com/abbgrade/csv-dotnet by Steffen Kampmann and Pavlo Datsiuk. MIT Licence.
- CsvHelper - > https://github.com/JoshClose/CsvHelper by Josh Close and 59 other contributors. Apache 2.0 and MS-PL License.
