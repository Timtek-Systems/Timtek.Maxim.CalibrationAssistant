using Machine.Specifications;
using Timtek.Maxim.ConfigureCalibration.Specifications.Builders;

namespace Timtek.Maxim.ConfigureCalibration.Specifications.Contexts;

class with_test_context
{
    internal static ChannelContext Context { get; set; } = null!;
    internal static ChannelContextBuilder ContextBuilder { get; set; } = null!;
    Establish context = () => ContextBuilder = new ChannelContextBuilder();
    Cleanup after = () =>
        {
            ContextBuilder = null!;
            Context = null!;
        };
}
