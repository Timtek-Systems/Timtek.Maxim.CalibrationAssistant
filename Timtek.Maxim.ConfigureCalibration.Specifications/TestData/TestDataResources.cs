using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Timtek.Maxim.ConfigureCalibration.Specifications.TestHelpers;

namespace Timtek.Maxim.ConfigureCalibration.Specifications.TestData
    {
    internal class TestDataResources
        {
        public static Stream ChannelSpecification(string key)
            {
            var assembly = Assembly.GetExecutingAssembly();
            var fullyQualifiedName = $"{assembly.GetName().Name}.TestData.ChannelSpecifications.{key}";
            var stream = assembly.GetManifestResourceStream(fullyQualifiedName);
            return stream ?? Stream.Null;
            }

        }
    }
