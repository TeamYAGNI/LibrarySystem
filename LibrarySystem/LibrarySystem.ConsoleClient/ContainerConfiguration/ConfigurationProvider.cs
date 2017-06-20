using System;
using System.Configuration;

namespace LibrarySystem.ConsoleClient.ContainerConfiguration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string FileDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["Directory"];
            }
        }

        public string BooksForImportFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["BooksForImportFilePath"];
            }
        }

        public string BooksForExportFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["BooksForExportFileName"];
            }
        }

        public string JournalsForImportFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["JournalsForImportFilePath"];
            }
        }

        public string JournalsForExportFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["JournalsForExportFileName"];
            }
        }

        public string PdfFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["PdfFileName"];
            }
        }

    }
}
