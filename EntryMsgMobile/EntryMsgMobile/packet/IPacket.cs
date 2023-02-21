using DotNetty.Buffers;

namespace ClientMobile.packet;

internal interface IPacket
{
    void ReadPacketData(IByteBuffer buf);

    void WritePacketData(IByteBuffer buf);
}