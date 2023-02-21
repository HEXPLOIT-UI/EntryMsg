using ClientMobile.utils;
using DotNetty.Buffers;

namespace ClientMobile.packet
{
    internal class SPacketUserMessage : IPacket
    {
        public string Message, Username;
        public SPacketUserMessage() { }

        public SPacketUserMessage(string message, string username)
        {
            Message = message;
            Username = username;
        }

        public void ReadPacketData(IByteBuffer buf)
        {
            Message = PacketBuffer.ReadString(buf, 1024);
            Username = PacketBuffer.ReadString(buf, 128);
        }

        public void WritePacketData(IByteBuffer buf)
        {
            PacketBuffer.WriteString(buf, Message);
            PacketBuffer.WriteString(buf, Username);
        }
    }
}
