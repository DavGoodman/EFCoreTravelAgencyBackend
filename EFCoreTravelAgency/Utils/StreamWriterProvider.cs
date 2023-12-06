public class StreamWriterProvider : IStreamWriterProvider
{
    public StreamWriter CreateStreamWriter(string path)
    {
        return new StreamWriter(File.Open(path, FileMode.Append))
        {
            AutoFlush = true
        };
    }
}