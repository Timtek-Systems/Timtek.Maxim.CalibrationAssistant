using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Timtek.Maxim.ConfigureCalibration.Specifications.Contexts;

namespace Timtek.Maxim.ConfigureCalibration.Specifications;

#nullable disable   // Doesn't play well with BDD

class when_reading_a_target_specification_with_one_channel : with_test_context
    {
    static IEnumerable<CalibrationChannelSpecification> Actual;
    Establish context = () => Context = ContextBuilder
        .WithSpecificationResourceStream("BasicDarkFrames")
        .Build();
    static CalibrationChannelSpecification Channel => Actual.First();
    Because of = () => Actual = Context.ChannelReader.ReadSpecificationAsync(Context.InputStream).Result;
    It should_produce_one_channel = () => Actual.Count().ShouldEqual(1);
    It should_be_for_dark_frames = () => Channel.FrameType.ShouldEqual(FrameType.Dark);
    It should_be_for_60_second_exposures = () => Channel.Exposure.ShouldEqual(60u);
    It should_be_for_temperature_0_degrees = () => Channel.Temperature.ShouldEqual(0);
    It should_be_full_resolution = () => Channel.Binning.ShouldEqual(1u);
    It should_be_for_minimum_1_frames = ()=> Channel.MinFrames.ShouldEqual(1u);
    It should_desire_3_frames = () => Channel.DesiredFrames.ShouldEqual(3u);
    }
