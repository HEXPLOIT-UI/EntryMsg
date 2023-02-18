using System;
using System.Net;
using System.Threading;
using ClientWindows.forms;
using ClientWindows.packet;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using MetroFramework.Controls;

namespace ClientWindows.network
{
    internal class Connection : SimpleChannelInboundHandler<IPacket>
    {
        public static string Username, UserID;
        private IChannel channel;
        private EndPoint endPoint;

        public override void ChannelActive(IChannelHandlerContext ctx)
        {
            channel = ctx.Channel;
            endPoint = channel.RemoteAddress;
            SendPacket(new CPacketLogin(Username, UserID));
        }

        public override void ChannelInactive(IChannelHandlerContext ctx)
        {
            CloseChannel("End of stream!");
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, IPacket packet)
        {
            if (channel.Open)
            {
                switch (packet)
                {
                    case SPacketKeepAlive packetKeepAlive:
                        SendPacket(new CPacketKeepAlive(packetKeepAlive.PingID));
                        break;
                    case SPacketClientAdd packetClientAdd:
                        MetroLabel user = new MetroLabel();
                        user.AutoSize = true;
                        user.Name = packetClientAdd.UserID;
                        user.Style = MetroFramework.MetroColorStyle.White;
                        user.TabIndex = 2;
                        user.Text = packetClientAdd.Username;
                        user.Theme = MetroFramework.MetroThemeStyle.Dark;
                        Program.currentChatMenu.UserList.Controls.Add(user);
                        break;
                    case SPacketClientRemove packetClientRemove:
                        Program.currentChatMenu.UserList.Controls.Remove(Program.currentChatMenu.UserList.Controls[packetClientRemove.UserID]);
                        break;
                    case SPacketChatInfo packetChatInfo:
                        Program.currentChatMenu.Text = $"Chat {packetChatInfo.ChatName}";
                        Program.currentChatMenu.Update();
                        break;
                }
            }
        }

        public override void ExceptionCaught(IChannelHandlerContext ctx, Exception exception)
        {
            if (exception is TimeoutException)
            {
                CloseChannel("Timeout");
            }
            else
            {
                Console.WriteLine(exception);
                CloseChannel("Error");
            }
        }

        private void CloseChannel(string message)
        {
            if (!channel.Open) return;
            channel.CloseAsync();
            Console.WriteLine("Channel closed: " + message);
            Program.currentChatMenu.Close();
            Program.mainForm.Show();
        }

        private void SendPacket(IPacket packetIn)
        {
            if (IsChannelOpen())
            {
                DispatchPacket(packetIn);
            }
            else
            {
                CloseChannel("Close");
            }
        }

        private void DispatchPacket(IPacket inPacket)
        {
            if (channel.EventLoop.InEventLoop)
            {
                channel.WriteAndFlushAsync(inPacket);
            }
            else
            {
                channel.EventLoop.Execute(() => channel.WriteAndFlushAsync(inPacket));
            }
        }

        public static void CreateConnection(string ip, int port, string username, string userid)
        {
            Username = username;
            UserID = userid;
            var networkManager = new Connection();
            var bootstrap = new Bootstrap();
            bootstrap.Channel<TcpSocketChannel>()
                .Option(ChannelOption.TcpNodelay, true)
                .Group(new MultithreadEventLoopGroup())
                .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    channel.Pipeline
                        .AddLast("timeout", new ReadTimeoutHandler(30))
                        .AddLast("splitter", new NettySplitterHandler())
                        .AddLast("decoder", new NettyPacketDecoder(PacketDirection.CLIENTBOUND))
                        .AddLast("prepender", new NettySizePrepender())
                        .AddLast("encoder", new NettyPacketEncoder(PacketDirection.SERVERBOUND))
                        .AddLast("packet_handler", networkManager);
                }));
            var task = bootstrap.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port));
            while (!task.IsCompleted)
            {
                Thread.Sleep(50);

            }
            while (networkManager.IsChannelOpen())
            {
                Thread.Sleep(50);
            }
        }

        public bool IsChannelOpen() => channel is { Open: true };
    }
}