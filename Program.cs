using StalNoteM.Application;
using StalNoteM.Data.Users;

namespace StalNoteM
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BotBuilder builder = new BotBuilder();
            await builder.InitialApp();
            builder.StartBeagling(12000);
            Console.ReadLine();
            /*
            builder.sendMsgAllUsers(
                "Довожу для всех, на данный момент времени бот переводиться в полный приват, если кто-то хочет чтобы бот отправлял сообщения и ему, писать в личку, стоимость обсудим",
                                    "F:\\StalNote\\StalNoteBot\\StalNoteM\\bin\\Debug\\net8.0\\Updates\\update.png");
            */

            Console.WriteLine("Nda");
        }
    }
}
