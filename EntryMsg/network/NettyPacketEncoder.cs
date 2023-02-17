using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using packet;
using utils;

namespace network
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
                Console.WriteLine(exception);
            }
        }
    }
}