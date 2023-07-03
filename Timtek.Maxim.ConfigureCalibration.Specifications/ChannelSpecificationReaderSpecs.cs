using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Timtek.Maxim.ConfigureCalibration.Specifications.Contexts;
using Timtek.Maxim.ConfigureCalibration.Specifications.ItemsUnderDevelopment;

namespace Timtek.Maxim.ConfigureCalibration.Specifications;

#nullable disable   // Doesn't play well with BDD

/*
 *     "channelName": "Basic Darks", 
    "frameType": "Dark", 
    "Exposure": 60, 
    "Temperature": 0, 
    "Binning": 1, 
    "maxAge": 10, 
    "minFrames": 1, 
    "desiredFrames": 3 
*/
class when_reading_a_target_specification_with_one_channel : with_test_context
    {
    static IEnumerable<CalibrationChannel> Actual;
    Establish context = () => Context = ContextBuilder
        .WithSpecificationResourceStream("TestData.BasicDarkFrames.json")
        .Build();
    Because of = () => Actual = Context.ChannelReader.ReadSpecification(Context.InputStream);
    It should_produce_one_channel = () => Actual.Count().ShouldEqual(1);
    It should_be_for_dark_frames;
    It should_be_for_60_second_exposures;
    It should_be_for_temperature_0_degrees;
    It should_be_unbinned;
    It should_be_for_minimum_1_frames;
    It should_desire_3_frames;
    }
