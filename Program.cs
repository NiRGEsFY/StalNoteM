using StalNoteM.Application;

namespace StalNoteM
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BotBuilder builder = new BotBuilder();
            await builder.InitialApp();
            builder.StartBeagling(18500);
            /*
            builder.sendMsgAllUsers("Возможны перебои в работе бота, миграция базы данных.\n" +
                                    "Так же возможно ошибочные ответы бота",
                                    "F:\\Repos\\StalNote\\bin\\Debug\\Updates\\0.0.1.png");
            */
            Console.ReadLine();
            
            Console.WriteLine("Nda");
        }
    }
}
