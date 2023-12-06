using System;
using System.IO;


public class Logger
{
    private readonly StreamWriter _writer;
    private readonly IDateTimeProvider _dateTimeProvider;

    public Logger(string path) : this(path, new DateTimeProvider(), new StreamWriterProvider())
    {
    }

    public Logger(string path, IDateTimeProvider dateTimeProvider, IStreamWriterProvider streamWriterProvider)
    {
        _dateTimeProvider = dateTimeProvider;
        _writer = streamWriterProvider.CreateStreamWriter(path);

        Log("Logger initialized");
    }

    public virtual void Log(string str)
    {
        _writer.WriteLine($"[{_dateTimeProvider.Now:dd.MM.yy HH:mm:ss}] {str}");
        _writer.Flush();
    }
}