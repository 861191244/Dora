﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace App
{
public class Program
{
    public static void Main(string[] args)
    {
        Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(buider => buider.UseStartup<Startup>())
                .Build()
                .Run();
    }
}
}
