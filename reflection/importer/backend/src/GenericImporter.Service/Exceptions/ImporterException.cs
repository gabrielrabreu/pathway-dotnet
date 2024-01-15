using System;

namespace GenericImporter.Service.Exceptions
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "<Pending>")]
    public class ImporterException : Exception
    {
        public ImporterException(string message) : base(message) { }
    }
}
