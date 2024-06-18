using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StalNoteM.Application;
using StalNoteM.Data.Users;

namespace StalNoteM
{

    internal class Program
    {

        public static void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;Initial Catalog=Stalcraft2;Integrated Security=True;MultipleActiveResultSets=True;"));

            // Add Identity
            services.AddIdentity<User, Role>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequiredLength = 8;
                config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.#_@абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application
            services.AddTransient<App>();

            services.AddLogging(configure => configure.AddConsole());
        }
        static async Task Main(string[] args)
        {
            bool updateDb = false;
            if (!updateDb)
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);

                var serviceProvider = serviceCollection.BuildServiceProvider();

                await serviceProvider.GetService<App>().Run();

                while (true)
                {
                    Thread.Sleep(1000000);
                }
            }

            /*
            builder.sendMsgAllUsers(
                "Довожу для всех, на данный момент времени бот переводиться в полный приват, если кто-то хочет чтобы бот отправлял сообщения и ему, писать в личку, стоимость обсудим",
                                    "F:\\StalNote\\StalNoteBot\\StalNoteM\\bin\\Debug\\net8.0\\Updates\\update.png");
            */

            Console.WriteLine("End Work");
        }


    }
}
