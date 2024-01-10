using Microsoft.Extensions.DependencyInjection;
using System.Text;
using TimeAbstractionTimers;
using TimeAbstractionTimers.Wrappers;

Console.OutputEncoding = Encoding.UTF8;

/****************************************************
 * Credit for configuring DI in a console app, something I hadn't tried before:
 * https://www.siderite.dev/blog/creating-console-app-with-dependency-injection-in-
 * ******************************/

var services = new ServiceCollection();
var provider = services
    .AddScoped<ITimerSamples, TimerSamples>()
    .AddScoped<IConsole, ConsoleWrapper>()
    .AddScoped<IFile, FileWrapper>()
    .AddSingleton(TimeProvider.System)
    .BuildServiceProvider();

var ts = provider.GetService<ITimerSamples>();
ts.StartTimers();

Console.Clear();
Console.ReadLine();
