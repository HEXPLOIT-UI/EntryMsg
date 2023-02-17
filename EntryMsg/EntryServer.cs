using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Transport.Channels;
using System.Net;
using DotNetty.Handlers.Timeout;
using command;
using network;
using packet;

internal class EntryServer
{
    public static EntryServer Instance = new();
    public readonly CommandManager CommandManager = new();
    public readonly List<Provider> Clients = new();

    public void Start(int port)
    {
        StartConsole();
        OpenPort(port);
        StartTick();
    }

    private void OpenPort(int port)
    {
        var eventExecutors = new MultithreadEventLoopGroup();
        var boss = new MultithreadEventLoopGroup();
        var bootstrap = new ServerBootstrap()
            .Option(ChannelOption.TcpNodelay, true)
            .Group(boss, eventExecutors)
            .Channel<TcpServerSocketChannel>()
            .ChildHandler(new ActionChannelInitializer<ISocketChannel>(
            channel =>
            {
                var connection = new Provider();
                channel.Pipeline
                    .AddLast("timeout", new ReadTimeoutHandler(30))
                    .AddLast("splitter", new NettySplitterHandler())
                    .AddLast("decoder", new NettyPacketDecoder(PacketDirection.SERVERBOUND))
                    .AddLast("prepender", new NettySizePrepender())
                    .AddLast("encoder", new NettyPacketEncoder(PacketDirection.CLIENTBOUND))
                    .AddLast("packet_handler", connection);
                Clients.Add(connection);
            }));
        bootstrap.BindAsync(IPAddress.Any, port);
        Console.WriteLine($"Server running as port: {port}");
    }

    private void Tick()
    {
        for (int i = 0; i < Clients.Count; i++)
        {
            var connection = Clients[i];
            if (connection.IsChannelOpen()) connection.Tick();
            else
            {
                Console.WriteLine($"Disconnected: {connection.Channel.RemoteAddress}");
                Clients.Remove(connection);
                break;
            }
        }
    }

    private void StartConsole()
    {
        new Thread(() =>
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line != null)
                {
                    try
                    {
                        CommandManager.Handle(line);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }
                }
            }
        })
        {
            Name = "Console"
        }.Start();
    }

    private void StartTick()
    {
        new Thread(() =>
        {
            while (true)
            {
                Tick();
                Thread.Sleep(50);
            }
        })
        {
            Name = "Tick"
        }.Start();
    }
}