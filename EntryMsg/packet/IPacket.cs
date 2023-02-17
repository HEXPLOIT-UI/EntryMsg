using DotNetty.Buffers;

namespace packet;

internal interface IPacket
{
    void ReadPacketData(IByteBuffer buf);

    void WritePacketData(IByteBuffer buf);
}