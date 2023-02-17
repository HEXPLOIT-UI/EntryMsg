using System;
using System.Text;
using DotNetty.Buffers;
using DotNetty.Codecs;

namespace ClientWindows.utils
{
    public class PacketBuffer
    {
        public static byte[] ReadByteArray(IByteBuffer buffer)
        {
            var size = ReadVarInt(buffer);
            var bytes = new byte[size];
            buffer.ReadBytes(bytes);
            return bytes;
        }

        public static void WriteByteArray(IByteBuffer buffer, byte[] bytes)
        {
            WriteVarInt(buffer, bytes.Length);
            buffer.WriteBytes(bytes);
        }

        public static string ReadString(IByteBuffer buffer, int maxLength)
        {
            var line = Encoding.UTF8.GetString(ReadByteArray(buffer));
            if (line.Length > maxLength) throw new DecoderException($"Строчка слишком длинная {line.Length} лимит {maxLength}");
            return line;
        }

        public static void WriteString(IByteBuffer buffer, string line)
        {
            var lineBytes = Encoding.UTF8.GetBytes(line);
            WriteByteArray(buffer, lineBytes);
        }
        
        public static int ReadVarInt(IByteBuffer buffer)
        {
            int i = 0;
            int j = 0;
            byte b0;

            do
            {
                b0 = buffer.ReadByte();
                i |= (b0 & 127) << j++ * 7;

                if (j > 5)
                {
                    throw new Exception("VarInt too big");
                }
            }
            while ((b0 & 128) == 128);

            return i;
        }

        public static void WriteVarInt(IByteBuffer buf, int value) {
            // Peel the one and two byte count cases explicitly as they are the most common VarInt sizes
            // that the proxy will write, to improve inlining.
            if ((value & (0xFFFFFFFF << 7)) == 0) {
                buf.WriteByte(value);
            } else if ((value & (0xFFFFFFFF << 14)) == 0) {
                var w = (value & 0x7F | 0x80) << 8 | (value >>> 7);
                buf.WriteShort(w);
            } else {
                WriteVarIntFull(buf, value);
            }
        }

        private static void WriteVarIntFull(IByteBuffer buf, int value) {
            // See https://steinborn.me/posts/performance/how-fast-can-you-write-a-varint/
            if ((value & (0xFFFFFFFF << 7)) == 0) {
                buf.WriteByte(value);
            } else if ((value & (0xFFFFFFFF << 14)) == 0) {
                var w = (value & 0x7F | 0x80) << 8 | (value >>> 7);
                buf.WriteShort(w);
            } else if ((value & (0xFFFFFFFF << 21)) == 0) {
                var w = (value & 0x7F | 0x80) << 16 | ((value >>> 7) & 0x7F | 0x80) << 8 | (value >>> 14);
                buf.WriteMedium(w);
            } else if ((value & (0xFFFFFFFF << 28)) == 0) {
                var w = (value & 0x7F | 0x80) << 24 | (((value >>> 7) & 0x7F | 0x80) << 16)
                                                    | ((value >>> 14) & 0x7F | 0x80) << 8 | (value >>> 21);
                buf.WriteInt(w);
            } else {
                var w = (value & 0x7F | 0x80) << 24 | ((value >>> 7) & 0x7F | 0x80) << 16
                                                    | ((value >>> 14) & 0x7F | 0x80) << 8 | ((value >>> 21) & 0x7F | 0x80);
                buf.WriteInt(w);
                buf.WriteByte(value >>> 28);
            }
        }
    }
}