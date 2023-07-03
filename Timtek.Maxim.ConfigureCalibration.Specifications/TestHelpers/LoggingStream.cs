using Timtek.Maxim.ConfigureCalibration.Specifications.Builders;

namespace Timtek.Maxim.ConfigureCalibration.Specifications.TestHelpers;

public class LoggingStream : MemoryStream
    {
    internal ByteArrayBuilder outputLog = new ByteArrayBuilder();

    /// <summary>
    /// Gets the exact ASCII-encoded bytes written to the output stream.
    /// </summary>
    public byte[] OutputBytes => outputLog.ToArray();

    public int OutputByteCount => outputLog.Length;

    /// <inheritdoc />
    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken = default)
        {
        outputLog.Append(buffer);
        return base.WriteAsync(buffer, offset, count, cancellationToken);
        }

    /// <inheritdoc />
    public override void WriteByte(byte value)
        {
        outputLog.Append(value);
        base.WriteByte(value);
        }

    /// <inheritdoc />
    public override ValueTask DisposeAsync()
        {
        Disposed = true;
        return base.DisposeAsync();
        }

    public bool Disposed { get; private set; } = false;

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
        {
        Disposed = true;
        base.Dispose(disposing);
        }
    }
