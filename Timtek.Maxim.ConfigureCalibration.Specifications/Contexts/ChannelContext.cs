namespace Timtek.Maxim.ConfigureCalibration.Specifications.Contexts;

internal class ChannelContext
    {
    internal CalibrationChannelReader ChannelReader { get; set; } = null!;
    internal Stream InputStream { get; set; } = null!;
    }