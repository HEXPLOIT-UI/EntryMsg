using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using packet;
using Server;
using Server.packet;

namespace network
{
    internal class Provider : SimpleChannelInboundHandler<IPacket>
    {
        public IChannel Channel;
        public string Username, UserID;
        public long UserConnectedID;
        private long lastPing, lastKeepAlive;
        public long ping;
        public long sendTime;

        public Provider()
        {
        }
        
        public override void ChannelActive(IChannelHandlerContext ctx)
        {
            Channel = ctx.Channel;
            UserConnectedID = new Random().NextLong();
            Console.WriteLine($"New connection aviable");
            SendPacket(new SPacketChatInfo(Settings.ChatName));
        }
        public override void ChannelInactive(IChannelHandlerContext ctx)
        {
            CloseChannel("End of stream!");
        }
        
        protected override void ChannelRead0(IChannelHandlerContext ctx, IPacket packet)
        {
            if (IsChannelOpen())
            {
                try
                {
                    switch (packet)
                    {
                        case CPacketKeepAlive packetKeepAlive:
                            ping = DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastPing;
                            break;
                        case CPacketLogin packetInfo:
                            Username = packetInfo.Username;
                            UserID = packetInfo.UserID;
                            foreach (var client in EntryServer.Instance.Clients)
                            {
                                if (client.Username != null && client.UserID != null)
                                {
                                    client.SendPacket(new SPacketClientAdd(Username, UserID));
                                    SendPacket(new SPacketClientAdd(client.Username, client.UserID));
                                }
                            }
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
        
        public override void ExceptionCaught(IChannelHandlerContext ctx, Exception exception)
        {
            if (exception is TimeoutException)
            {
                CloseChannel("Timed out");
            }
            else
            {
                Console.WriteLine(exception);
            }
        }

        private void CloseChannel(string message)
        {
            if (!Channel.Open) return;
            Channel.CloseAsync();
            Console.WriteLine("Channel closed: " + message);
        }

        public void SendPacket(IPacket packetIn) 
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
            if (Channel.EventLoop.InEventLoop) 
            {
                Channel.WriteAndFlushAsync(inPacket);
            } 
            else 
            {
                Channel.EventLoop.Execute(() => Channel.WriteAndFlushAsync(inPacket));
            }
        }
        
        public void Tick() {
            if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastKeepAlive > 1500) 
            {
                lastPing = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                SendPacket(new SPacketKeepAlive(new Random().NextLong()));
                lastKeepAlive = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        }
        
        public bool IsChannelOpen()
        {
            return Channel is { Open: true };
        }
    }
}