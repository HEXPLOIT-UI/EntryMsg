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
                    Console.WriteLine($"ID: {i}\nUsername: {client.Username}\nUserID: {client.UserID}\nPing: {client.ping}");
                }
            }
        }
    }
}
