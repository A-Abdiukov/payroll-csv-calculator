using PayrollApplication;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UI
{
    /// <summary>
    /// Controller class is responsible for communicating with MyPayProject
    /// </summary>
    public class Controller
    {
        private readonly string importFolderLocation;
        private readonly string importFileLocation;
        private readonly string outputFileLocation;
        private readonly string aboutFileLocation;


        public Controller()
        {
            //Getting the paths of the files
            this.importFolderLocation = "Import\\";
            this.importFileLocation = importFolderLocation + "employee-payroll-data.csv";
            this.outputFileLocation = ("Export\\");
            this.aboutFileLocation = "HowTaxIsCalculated.docx";
        }

        public string[] ReadCSV()
        {
            //The csv employee-payroll-data.csv file gets transported into List<PayRecord>
            List<PayRecord> payRecord = CsvImporter.ImportPayRecords(importFileLocation);

            //A name of the file that will be used for outputs is created
            //The file name looks like this: {637381283525934083}-records.csv
            //The big number in the middle 637381283525934083 is a unique number that counts the current number of ticks since 1st Jan 1970.
            string filename = outputFileLocation + ("{" + DateTime.Now.Ticks.ToString() + "}-records.csv"); ;
            string[] output = PayRecordWriter.Write(filename, payRecord, true);

            return output;
        }

        public void About()
        {
            Process.Start("explorer.exe", aboutFileLocation);
        }

        public void OpenImportFolder()
        {
            Process.Start("explorer.exe", importFolderLocation);
        }

        public void OpenExportFolder()
        {
            Process.Start("explorer.exe", outputFileLocation);
        }

    }
}
