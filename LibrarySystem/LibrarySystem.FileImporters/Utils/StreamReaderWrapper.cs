using System.IO;
using Bytes2you.Validation;
using LibrarySystem.FileImporters.Utils.Contracts;

namespace LibrarySystem.FileImporters.Utils
{
    public class StreamReaderWrapper : IStreamReader
    {
        private StreamReader streamReader;

        public StreamReaderWrapper(string filePath)
        {
            Guard.WhenArgument(filePath, "StreamReaderWrapper").IsNullOrEmpty().Throw();

            this.streamReader = new StreamReader(filePath);
        }

        public StreamReader GetStreamReader()
        {
            return this.streamReader;
        }
    }
}
