using utils;
using DotNetty.Buffers;

namespace packet
{
    class CPacketUserMessage : IPacket
    {
        public string Message, Username;
        public CPacketUserMessage() { }
        public CPacketUserMessage(string message, string username) 
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
