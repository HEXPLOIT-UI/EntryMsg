using DotNetty.Buffers;

namespace ClientWindows.packet;

internal interface IPacket
{
    void ReadPacketData(IByteBuffer buf);

    void WritePacketData(IByteBuffer buf);
}