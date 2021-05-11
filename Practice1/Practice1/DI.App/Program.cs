using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            // Inversion of Control

            var dbService = new InMemoryDatabaseService();

            var userStore = new UserStore(dbService);

            var commandAddUser = new AddUserCommand(userStore);
            var commandListUsers = new ListUsersCommand(userStore);

            var processor = new CommandProcessor();

            processor.AddCommand(commandAddUser);
            processor.AddCommand(commandListUsers);

            var manager = new CommandManager(processor);

            manager.Start();
        }
    }
}
