﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Timtek.Maxim.ConfigureCalibration.Specifications.TestHelpers
    {
    internal static class ExceptionHelpers
        {
        public static Exception First(this Exception ex)
            {
            switch (ex)
                {
                case AggregateException aggregate:
                    return aggregate.InnerExceptions.Single();
                default:
                    return ex;
                }
            }
        }
    }
