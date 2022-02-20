using Assignment.Application.Mappers;
using Assignment.Application.DTO;
using Assignment.Application.Services;
using Assignment.Domain;
using Assignment.Domain.Repositories;
using Assignment.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Logging;

namespace Assignment.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = Init();
            var listService = serviceProvider.GetService<IListProcessor>();

            Console.Write("Enter name:");
            string name = Console.ReadLine();
            Console.Write("Enter last name:");
            string lastName = Console.ReadLine();

            var t = listService.ProcessList(name, lastName);

            Console.WriteLine($"Received GUID: {t}");
            Console.WriteLine("Display Results?");
            Console.ReadLine();

            var processed = listService.GetStatus(t);
            PresentList(processed.Outputs);
            Console.ReadLine();
        }

        private static void PresentList(ICollection<OutputDto> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Value);
            }
        }

        private static ServiceProvider Init()
        {
            IConfiguration Config = new ConfigurationBuilder()
                 .AddJsonFile("appSettings.json")
                 .Build();
            string connString = Config.GetSection("DefaultConnection").Value;
            var services = new ServiceCollection();
            services.AddDbContext<ABNContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connString)

            );
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OutputProfile());
                mc.AddProfile(new ProcessRequestProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddLogging();
            services.AddScoped<IProcessRequestRepository, ProcessRequestRepository>();
            services.AddSingleton<IListProcessor, ListProcessorService>();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
