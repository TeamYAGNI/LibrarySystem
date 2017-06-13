using iTextSharp.text;

namespace LibrarySystem.FileExporters.Utils.Contracts
{
    public interface IPdfStream
    {
        Document Document { get; }
    }
}
