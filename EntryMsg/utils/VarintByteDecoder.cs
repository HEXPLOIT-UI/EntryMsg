using DotNetty.Common.Utilities;

namespace utils;

internal class VarintByteDecoder : IByteProcessor
{
    private int readVarint;
    private int bytesRead;
    private DecodeResult result = DecodeResult.TOO_SHORT;

    public bool Process(byte k) 
    {
        if (k == 0 && bytesRead == 0) {
            // tentatively say it's invalid, but there's a possibility of redemption
            result = DecodeResult.RUN_OF_ZEROES;
            return true;
        }
        if (result == DecodeResult.RUN_OF_ZEROES) {
            return false;
        }
        readVarint |= (k & 0x7F) << bytesRead++ * 7;
        if ((k & 0x80) != 128) {
            result = DecodeResult.SUCCESS;
            return false;
        }
        return true;
    }

    public int GetReadVarint() => readVarint;

    public int GetBytesRead() => bytesRead;

    public DecodeResult GetResult() => result;

    public void Reset() {
        readVarint = 0;
        bytesRead = 0;
        result = DecodeResult.TOO_SHORT;
    }
    
    public enum DecodeResult {
        SUCCESS,
        TOO_SHORT,
        TOO_BIG,
        RUN_OF_ZEROES
    }
}