using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RasmusLabb1.Contexts;
using RasmusLabb1.Entities;
using RasmusLabb1.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using RasmusLabb1.Handlers;

namespace RasmusLabb1
{
    class Program
    {
        public static void Main(string[] args)
        {
            SeedData.Initialize();
            RunApp.RunApplication();
        }

    }
}
        

