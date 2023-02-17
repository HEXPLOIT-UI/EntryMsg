using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using packet;
using utils;

namespace network
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
            if (input.ReadableBytes > 0) throw new IOException($"Packet {i} ({packet.GetType().FullName}) is to big, found {input.ReadableBytes} extra bytes on packet read!");
            output.Add(packet);
        }
    }
}