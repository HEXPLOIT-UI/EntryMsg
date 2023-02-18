using DotNetty.Buffers;
using utils;

namespace packet
{
    internal class SPacketServerMessage : IPacket
    {
        public string Message;
        public SPacketServerMessage() { }

        public SPacketServerMessage(string message)
        {
        }
        public void ReadPacketData(IByteBuffer buf)
        {
            Message = PacketBuffer.ReadString(buf, 1024);
        }

        public void WritePacketData(IByteBuffer buf)
        {
            PacketBuffer.WriteString(buf, Message);
        }
    }
}
