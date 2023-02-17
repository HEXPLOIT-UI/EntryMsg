using DotNetty.Buffers;

namespace packet
{
    internal class CPacketKeepAlive : IPacket
    {
        public long PingID;

        public CPacketKeepAlive() { }

        public CPacketKeepAlive(long pingId)
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
