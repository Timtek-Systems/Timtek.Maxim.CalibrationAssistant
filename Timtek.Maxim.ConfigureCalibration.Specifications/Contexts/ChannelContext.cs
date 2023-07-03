using Timtek.Maxim.ConfigureCalibration.Specifications.ItemsUnderDevelopment;

namespace Timtek.Maxim.ConfigureCalibration.Specifications.Contexts;

public class ChannelContext
    {
    public CalibrationChannelReader ChannelReader { get; internal set; } = null!;
    public Stream InputStream { get; internal set; } = null!;
    }