using DotNetty.Buffers;
using utils;

namespace packet
{
    internal class SPacketDisconnect : IPacket
    {
        public string Reason;

        public SPacketDisconnect() { }

        public SPacketDisconnect(string reason) 
        { 
            Reason = reason;
        }

        public void ReadPacketData(IByteBuffer buf)
        {
            Reason = PacketBuffer.ReadString(buf, 512);
        }

        public void WritePacketData(IByteBuffer buf)
        {
            PacketBuffer.WriteString(buf, Reason);
        }
    }
}
