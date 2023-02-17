using DotNetty.Buffers;

namespace ClientWindows.packet
{
    internal class SPacketKeepAlive : IPacket
    {
        public long PingID;

        public SPacketKeepAlive() { }

        public SPacketKeepAlive(long pingId)
        {
            PingID = pingId;
        }

        public void ReadPacketData(IByteBuffer buf)
        {
            PingID = buf.ReadLong();
        }

        public void WritePacketData(IByteBuffer buf)
        {
            buf.WriteLong(PingID);
        }
    }
}
