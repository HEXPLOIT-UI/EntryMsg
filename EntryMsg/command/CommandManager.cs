using command.cmds;
using utils;

namespace command;

internal class CommandManager
{
    private readonly List<Command> Commands = new();

    public CommandManager()
    {
        Commands.Add(new ClientsCommand("clients"));
    }

    public void Handle(string message)
    {
        if (message.StartsWith(@"/"))
        {
            var command = GetCommand(message.Substring(1).Split(' ')[0]);
            if (command == null)
            {
                Console.WriteLine("Command not found");
            }
            else
            {
                var args = message.Substring(1).Split(' ');
                command.Handle(StringUtils.Join(args, " ", 1, args.Length).Split(' '));
            }
        }
        else
        {
            Console.WriteLine("Command not found");
        }
    }

    private Command GetCommand(string name)
    {
        return Commands.FirstOrDefault(command => command.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}