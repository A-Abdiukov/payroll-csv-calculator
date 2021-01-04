using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using PayrollApplication;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

// I have renamed the project name to fit the requirements. As a result, it says "using PayRollApplication", because "PayrollApplication" was the old project name.
// The new project name is "MyPayProject"

namespace MyPayNUnitTestProject_
{
    public class Tests
    {
        private List<PayRecord> _records;

        [SetUp]
        //setting up the file
        public void Setup()
        {
            string csv_file_path = Path.GetFullPath(Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"..\..\..\")) + @"Import\employee-payroll-data.csv";
            _records = CsvImporter.ImportPayRecords(csv_file_path);
        }
        //testing whether the file was imported properly
        [Test]
        public void TestImport()
        {
            Assert.IsNotNull(_records);
            Assert.AreEqual(_records.Count, 5);
        }
        //testing whether the gross calculated is correct
        [Test]
        public void TestGross()
        {
            double expected_value = 1797.45;
            double actual_value = Math.Round(_records[4].Gross, 2);
            Assert.AreEqual(expected_value, actual_value);
        }

        //testing whether the tax calculated is correct
        [Test]
        public void TestTax()
        {
            double expected_value = 597.14;

            double actual_value = Math.Round(_records[4].Tax, 2);

            Assert.AreEqual(expected_value, actual_value);
        }
        //testing whether the net calculated is correct
        [Test]
        public void TestNet()
        {
            double expected_value = 1200.31;

            double actual_value = Math.Round(_records[4].Net, 2);
            Assert.AreEqual(expected_value, actual_value);
        }

        //testing whether the file gets written.
        [Test]
        public void TestExport()
        {
            //getting the path of the file where the output will be made.
            string csv_file_path = Path.GetFullPath(Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"..\..\..\")) + @"Export\" + "{" + DateTime.Now.Ticks.ToString() + "}-records.csv";
            PayRecordWriter.Write(csv_file_path, _records, false);
            Assert.AreEqual(File.Exists(csv_file_path), true);

        }
    }
}
