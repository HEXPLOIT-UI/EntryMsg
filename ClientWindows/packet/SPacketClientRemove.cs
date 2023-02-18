using ClientWindows.utils;
using DotNetty.Buffers;

namespace ClientWindows.packet
{
    internal class SPacketClientRemove : IPacket
    {
        public string UserID;
        public SPacketClientRemove() { }
        public SPacketClientRemove(string userID) 
        {
            UserID = userID;
        }
        public void ReadPacketData(IByteBuffer buf)
        {
            UserID = PacketBuffer.ReadString(buf, 128);
        }

        public void WritePacketData(IByteBuffer buf)
        {
            PacketBuffer.WriteString(buf, UserID);
        }
    }
}
