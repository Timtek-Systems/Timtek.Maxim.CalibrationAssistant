using Timtek.Maxim.ConfigureCalibration.Specifications.Contexts;
using Timtek.Maxim.ConfigureCalibration.Specifications.TestData;
using Timtek.Maxim.ConfigureCalibration.Specifications.ItemsUnderDevelopment;

namespace Timtek.Maxim.ConfigureCalibration.Specifications.Builders;

internal class ChannelContextBuilder
{
    Stream specificationInputStream = Stream.Null;
    internal ChannelContext Build()
        {

        return new ChannelContext { ChannelReader = new CalibrationChannelReader(), InputStream = specificationInputStream};
        }

    internal ChannelContextBuilder WithSpecificationResourceStream(string resourceKey)
        {
        specificationInputStream = TestDataResources.ChannelSpecification(resourceKey);
        return this;
        }
    }
