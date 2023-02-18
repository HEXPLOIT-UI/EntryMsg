using ClientWindows.utils;
using DotNetty.Buffers;

namespace ClientWindows.packet
{
    internal class SPacketClientAdd : IPacket
    {
        public string Username, UserID;
        
        public SPacketClientAdd() { }
        public SPacketClientAdd(string username, string userID) 
        {
            Username = username;
            UserID = userID;
        }

        public void ReadPacketData(IByteBuffer buf)
        {
            Username = PacketBuffer.ReadString(buf, 128);
            UserID = PacketBuffer.ReadString(buf, 128);
        }

        public void WritePacketData(IByteBuffer buf)
        {
            PacketBuffer.WriteString(buf, Username);
            PacketBuffer.WriteString(buf, UserID);
        }
    }
}
