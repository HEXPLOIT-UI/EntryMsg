using System.Collections.Generic;
using System.IO;
using ClientWindows.packet;
using ClientWindows.utils;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;

namespace ClientWindows.network
{
    internal class NettyPacketDecoder : ByteToMessageDecoder
    {
        private readonly PacketDirection direction;

        public NettyPacketDecoder(PacketDirection direction) => this.direction = direction;

        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            if (input.ReadableBytes == 0) return;
            var i = PacketBuffer.ReadVarInt(input);
            var packet = EnumConnectionState.GetPacket(direction, i);
            if (packet == null) throw new IOException("Bad packet id " + i);
            packet.ReadPacketData(input);
            if (input.ReadableBytes > 0) throw new IOException($"Пакет {i} ({packet.GetType().FullName}) больше чем ожидалось, найдено {input.ReadableBytes} лишних байтов при чтении пакета!");
            output.Add(packet);
        }
    }
}