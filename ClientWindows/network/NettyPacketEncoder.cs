using System;
using System.IO;
using ClientWindows.packet;
using ClientWindows.utils;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;

namespace ClientWindows.network
{
    internal class NettyPacketEncoder : MessageToByteEncoder<IPacket>
    {
        private readonly PacketDirection direction;

        public NettyPacketEncoder(PacketDirection direction) => this.direction = direction;

        protected override void Encode(IChannelHandlerContext context, IPacket message, IByteBuffer output)
        {
            var id = EnumConnectionState.GetPacketId(direction, message);
            if (id == -1) throw new IOException("Can't serialize unregistered packet");
            PacketBuffer.WriteVarInt(output, id);
            try {
                message.WritePacketData(output);
            } catch (Exception exception) {
                Console.WriteLine(exception.StackTrace);
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.InnerException);
            }
        }
    }
}