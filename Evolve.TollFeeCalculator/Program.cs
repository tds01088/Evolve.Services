using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Evolve.TollFeeCalculator.Models;
using Evolve.TollFeeCalculator.Config;
using Evolve.TollFeeCalculator.Interfaces;
using System.Linq;
using Evolve.TollFeeCalculator.Enums;
using Evolve.TollFeeCalculator.Services;

namespace Evolve.TollFeeCalculator
{
    class Program
    {
        private static IConfigurationRoot _configuration;
        static void Main(string[] args)
        {

            BuildConfiguration();
            IAppConfiguration appConfiguration = new AppConfiguration(_configuration);

            File.AppendAllText(Globals.AppConfiguration.LogFilePath, $"Windows Service Started {DateTime.Now.ToString()}\n");
            ITollFeeCalculatorService tollFreeForAVehicle = new TollFeeCalculatorService();

            var car = new Car();
            car.RegNo = "APE813";

            var totalCostFee= tollFreeForAVehicle.GetTollFee(car, new DateTime[] { new DateTime(2019, 05, 8, 10, 30, 0),
                                                                                       new DateTime(2019, 05, 9, 10, 30, 0),
                                                                                       new DateTime(2019, 05, 9, 10, 56, 0) });


            var motorbike = new Motorbike();
            motorbike.RegNo = "APE888";
            totalCostFee = tollFreeForAVehicle.GetTollFee(motorbike, new DateTime[] { new DateTime(2019, 05, 8, 10, 30, 0),
                                                                                       new DateTime(2019, 05, 9, 10, 30, 0),
                                                                                   new DateTime(2019, 05, 9, 10, 56, 0) });                   
              
            Console.ReadKey();
        }


        private static void BuildConfiguration()
        {
            var EnviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{EnviromentName}.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();

        }
    }
}

