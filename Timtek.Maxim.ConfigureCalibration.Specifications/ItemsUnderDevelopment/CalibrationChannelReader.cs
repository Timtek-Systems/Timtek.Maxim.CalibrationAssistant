using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;

namespace Timtek.Maxim.ConfigureCalibration;

internal class CalibrationChannelReader
    {
    static readonly JsonSerializerOptions readOptions = new JsonSerializerOptions()
        {
        AllowTrailingCommas = true,
        NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals | JsonNumberHandling.AllowReadingFromString,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
            {
            new JsonStringEnumConverter()
            }
        };
    internal async Task<IEnumerable<CalibrationChannelSpecification>> ReadSpecificationAsync(Stream inputStream)
        {
        using (var reader = new StreamReader(inputStream))
            {
            var json = await reader.ReadToEndAsync();
            var channels = JsonSerializer.Deserialize<IEnumerable<CalibrationChannelSpecification>>(json, readOptions);
            return channels ?? Enumerable.Empty<CalibrationChannelSpecification>();
            }
        }
    }