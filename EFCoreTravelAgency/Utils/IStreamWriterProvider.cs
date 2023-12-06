public interface IStreamWriterProvider
{
    StreamWriter CreateStreamWriter(string path);
}