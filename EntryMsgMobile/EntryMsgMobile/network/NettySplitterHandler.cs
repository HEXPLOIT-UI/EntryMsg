﻿using System.Collections.Generic;
using ClientMobile.utils;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;

namespace ClientMobile.network;

public class NettySplitterHandler : ByteToMessageDecoder
{
    public static readonly DecoderException BAD_LENGTH_CACHED = new("Bad packet length");
    public static readonly DecoderException VARINT_BIG_CACHED = new("VarInt too big");
    private static readonly VarintByteDecoder reader = new();

    protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
    {
        if (!context.Channel.Active) {
            input.Clear();
            return;
        }

        reader.reset();

        var varintEnd = input.ForEachByte(reader);
        if (varintEnd == -1) {
            // We tried to go beyond the end of the buffer. This is probably a good sign that the
            // buffer was too short to hold a proper varint.
            if (reader.getResult() == VarintByteDecoder.DecodeResult.RUN_OF_ZEROES) {
                // Special case where the entire packet is just a run of zeroes. We ignore them all.
                input.Clear();
            }
            return;
        }

        if (reader.getResult() == VarintByteDecoder.DecodeResult.RUN_OF_ZEROES) {
            // this will return to the point where the next varint starts
            input.SetReaderIndex(varintEnd);
        } else if (reader.getResult() == VarintByteDecoder.DecodeResult.SUCCESS) {
            var readVarint = reader.getReadVarint();
            var bytesRead = reader.getBytesRead();
            if (readVarint < 0) {
                input.Clear();
                throw BAD_LENGTH_CACHED;
            } else if (readVarint == 0) {
                // skip over the empty packet(s) and ignore it
                input.SetReaderIndex(varintEnd + 1);
            } else {
                int minimumRead = bytesRead + readVarint;
                if (input.IsReadable(minimumRead)) {
                    output.Add(input.RetainedSlice(varintEnd + 1, readVarint));
                    input.SkipBytes(minimumRead);
                }
            }
        } else if (reader.getResult() == VarintByteDecoder.DecodeResult.TOO_BIG) {
            input.Clear();
            throw VARINT_BIG_CACHED;
        }
    }
}