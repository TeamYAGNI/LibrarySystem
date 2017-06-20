namespace LibrarySystem.ConsoleClient.ContainerConfiguration
{
    public interface IConfigurationProvider
    {
        string FileDirectory { get; }

        string BooksForImportFilePath { get; }

        string BooksForExportFileName { get; }

        string JournalsForImportFilePath { get; }

        string JournalsForExportFileName { get; }

        string PdfFileName { get; }
    }
}
