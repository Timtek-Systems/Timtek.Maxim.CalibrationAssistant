using System.Text.Json.Serialization;

namespace Timtek.Maxim.ConfigureCalibration;

/// <summary>
/// A data transfer object with no functionality.
/// Specifies a calibration "channel".
/// </summary>
/// <remarks>Setters must be public for <see cref="System.Text.Json.JsonSerializer"/>.</remarks>
internal class CalibrationChannelSpecification
    {
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("frameType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public FrameType FrameType { get; set; } = FrameType.Unknown;
    [JsonPropertyName("exposure")]
    public uint Exposure { get; set; }
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; }
    [JsonPropertyName("binning")]
    public uint Binning { get; set; }
    [JsonPropertyName("maxAge")]
    public uint MaxAge { get; set; }
    [JsonPropertyName("minFrames")]
    public uint MinFrames { get; set; }
    [JsonPropertyName("desiredFrames")]
    public uint DesiredFrames { get; set; }
    }

internal enum FrameType
    {
    Unknown,    // The frame type is unknown or has not yet been determined
    Light,      // A light frame taken with the camera shutter open
    Dark,       // A frame taken with the shutter closed for nonzero duration
    Bias,       // A frame taken with the shutter closed for zero duration (or the shortest possible camera exposure time).
    Flat,       // A frame taken with the shutter open of an evenly illuminated field at a specified spectral band.
    Other       // A frame for which the type has been examined and is not of any of the other well-knowm types.
    };


