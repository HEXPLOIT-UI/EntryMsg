using ClientWindows.utils;
using DotNetty.Buffers;

namespace ClientWindows.packet
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
