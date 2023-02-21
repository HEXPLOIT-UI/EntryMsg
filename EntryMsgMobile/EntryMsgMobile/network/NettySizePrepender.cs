using System;
using ClientMobile.utils;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;

namespace ClientMobile.network;

public class NettySizePrepender : MessageToByteEncoder<IByteBuffer>
{
    private static readonly int MAX_PREPEND_LENGTH = 3;
    
    protected override void Encode(IChannelHandlerContext context, IByteBuffer message, IByteBuffer output)
    {
        var i = message.ReadableBytes;
        var j = VarIntUtils.GetVarIntLength(i);
        if (j > MAX_PREPEND_LENGTH) throw new ArgumentException("unable to fit " + i + " into 3");
        output.EnsureWritable(j + i);
        PacketBuffer.WriteVarInt(output, i);
        output.WriteBytes(message, message.ReaderIndex, i);
    }
}