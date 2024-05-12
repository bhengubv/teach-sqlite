﻿using Serilog;
using static System.DateTime;

namespace SampleApp3.Classes;

/// <summary>
/// For setting up SeriLog to keep Program.Main clean and allows code to be easily copied to other projects.
/// </summary>
public class SeriLogSetupLogging
{
    /// <summary>
    /// Configure logging for development environment
    /// </summary>
    public static void Development()
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{Now.Year}-{Now.Month}-{Now.Day}", "Log.txt"),
                rollingInterval: RollingInterval.Infinite,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();
    }


}
