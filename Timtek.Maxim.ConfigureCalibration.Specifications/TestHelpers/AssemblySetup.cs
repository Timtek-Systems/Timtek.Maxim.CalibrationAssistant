// This file is part of the TA.ObjectOrientedAstronomy project
// 
// Copyright © 2015-2016 Tigra Astronomy, all rights reserved.
// 
// File: AssemblySetup.cs  Last modified: 2016-09-30@02:16 by Tim Long

using Machine.Specifications;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Timtek.Maxim.ConfigureCalibration.Specifications.TestHelpers
    {
    public class AssemblySetup : IAssemblyContext
        {
        private static Logger? log = null;

        public static Logger Log => log ?? ConfigureLogging();

        public void OnAssemblyStart()
            {
            ConfigureLogging();
            Log.Info("Logging configured");
            }

        public void OnAssemblyComplete()
            {
            log = null!;
            }

        static Logger ConfigureLogging()
            {
            var config = new LoggingConfiguration();
            var traceTarget = new TraceTarget();
            config.AddTarget("Diagnostic", traceTarget);
            var traceRule = new LoggingRule("*", LogLevel.Debug, traceTarget);
            config.LoggingRules.Add(traceRule);
            LogManager.Configuration = config;
            return LogManager.GetCurrentClassLogger();
            }
        }
    }