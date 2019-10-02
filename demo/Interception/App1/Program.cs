﻿using Dora.DynamicProxy;
using Dora.Interception;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace App
{
    public class Program
    {
        public static async Task Main()
        {
            //var clock1 = new ServiceCollection()
            //  .AddLogging(factory => factory.AddConsole())
            //  .AddMemoryCache()
            //  .AddSingleton<ISystemClock, SystemClock>()
            //  .AddInterception()
            //  .BuildServiceProvider()
            //  .GetRequiredService<IInterceptable<ISystemClock>>()
            //  .Proxy;

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"Current time: {await clock1.GetCurrentTime(DateTimeKind.Local)}");
            //    Task.Delay(1000).Wait();
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"Current time: {await clock1.GetCurrentTime(DateTimeKind.Utc)}");
            //    Task.Delay(1000).Wait();
            //}

            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                var clock2 = new ServiceCollection()
              .AddMemoryCache()
              .AddSingleton<ISystemClock, SystemClock>()
              .BuildInterceptableServiceProvider()
              .GetRequiredService<ISystemClock>();
            }
            Console.WriteLine(watch.Elapsed);
            

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"Current time: {await clock2.GetCurrentTime(DateTimeKind.Local)}");
            //    Task.Delay(1000).Wait();
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"Current time: {await clock2.GetCurrentTime(DateTimeKind.Utc)}");
            //    Task.Delay(1000).Wait();
            //}
        }
    }
}

public class FoobarInterceptor
{
    public IFoo Foo { get; }
    public string Baz { get; }  
    public FoobarInterceptor(IFoo foo, string baz)
    {
        Foo = foo;
        Baz = baz;
    }

    public async Task InvokeAsync(InvocationContext context, IBar bar)
    {
        await Foo.DoSomethingAsync();
        await bar.DoSomethingAsync();
        await context.ProceedAsync();
    }
}

public interface IFoo {
    Task DoSomethingAsync();
}
public interface IBar {
    Task DoSomethingAsync();
}

