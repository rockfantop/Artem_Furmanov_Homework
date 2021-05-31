using System;
using System.Threading;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using BLL.ModelsDTO;
using BLL.Services;
using DAL.Abstractions.Interfaces;
using DAL.Json.JsonHandler;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace IWillFixYou
{
    class Program : BackgroundService
    {
        private readonly IUserService userService;

        public Program(IUserService userService)
        {
            this.userService = userService;
        }

        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().StartAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddDebug();
                })
                .ConfigureServices((_, services) =>
                {
                    services.AddScoped(typeof(IJsonHandler<>), typeof(JsonHandler<>));
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

                    services.AddScoped<IUserService, UserService>();

                    services.AddScoped<Program>();

                    services.AddHostedService<Program>();
                });

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Factory.StartNew(() =>
            {
                var guid = Guid.NewGuid();

                var userDTO = new UserDTO
                {
                    Id = guid,
                    FirstName = "Fred",
                    LastName = "Smith",
                    Age = 40
                };

                var result = this.userService.CreateUser(userDTO);

                if (result.IsSuccesful)
                {
                    UserDTO user = (UserDTO)this.userService.GetUser((x) => x.Id == guid).Result;

                    Console.WriteLine($"Matching Record, got name={user.FirstName}, lastname={user.LastName}, age={user.Age}");
                }
            });
        }
    }
}
