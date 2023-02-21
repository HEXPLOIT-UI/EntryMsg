using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using ChatUIXForms.Models;
using ChatUIXForms.ViewModels;
using ChatUIXForms.Views;
using ClientMobile.packet;
using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using EntryMsgMobile;

namespace ClientMobile.network
{
    internal class Connection : SimpleChannelInboundHandler<IPacket>
    {
        public static string Username, UserID;
        public static IChannel channel;
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
                    case SPacketChatInfo packetChatInfo:
                        
                        break;
                    case SPacketKeepAlive packetKeepAlive:
                        SendPacket(new CPacketKeepAlive(packetKeepAlive.PingID));
                        break;
                    case SPacketClientAdd packetClientAdd:
                        
                        break;
                    case SPacketClientRemove packetClientRemove:
                        
                        break;
                    case SPacketDisconnect packetDisconnect:
                        
                        break;
                    case SPacketUserMessage packetUserMessage:
                        var vm = AuthMenu.chatPage.BindingContext as ChatPageViewModel;
                        vm.Messages.Insert(0, new Message() { Text = packetUserMessage.Message, User = packetUserMessage.Username });
                        break;
                    case SPacketServerMessage packetServerMessage:
                        
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

        public static void CloseChannel(string message)
        {
            if (!channel.Open) return;
            channel.CloseAsync();
            Debug.WriteLine("Channel closed: " + message);
        }

        public static void SendPacket(IPacket packetIn)
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

        private static void DispatchPacket(IPacket inPacket)
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
            while (IsChannelOpen())
            {
                Thread.Sleep(50);
            }
        }

        private static bool IsChannelOpen() => channel is { Open: true };
    }
}