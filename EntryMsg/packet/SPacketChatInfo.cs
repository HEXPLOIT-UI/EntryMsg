using DotNetty.Buffers;
using packet;
using utils;

namespace Server.packet
{
    internal class SPacketChatInfo : IPacket
    {
        public string ChatName;

        public SPacketChatInfo() { }

        public SPacketChatInfo(string chatName)
        {
            ChatName = chatName;
        }

        public void ReadPacketData(IByteBuffer buf)
        {
            ChatName = PacketBuffer.ReadString(buf, 128);
        }

        public void WritePacketData(IByteBuffer buf)
        {
            PacketBuffer.WriteString(buf, ChatName);
        }
    }
}
