using System;

namespace command.cmds
{
    internal class ClientsCommand : Command
    {
        public ClientsCommand(string name) : base(name)
        {
        }

        public override void Handle(string[] args)
        {
            if (Clients.Count == 0)
            {
                Console.WriteLine("Client list is empty");
            }
            else
            {
                for (int i = 0; i < Clients.Count; i++)
                {
                    var client = Clients[i];
                    Console.WriteLine($"User ID: {i}\nUsername: {client.Username}\nPing: {client.ping}");
                }
            }
        }
    }
}
