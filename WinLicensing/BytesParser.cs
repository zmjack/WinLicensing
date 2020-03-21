using System;
using System.IO;
using System.Text;

namespace WinLicensing
{
    public class BytesParser
    {
        private readonly MemoryStream Stream;

        public BytesParser(byte[] bytes)
        {
            Stream = new MemoryStream(bytes);
        }

        public bool EOF => Stream.Position >= Stream.Length;

        public byte[] Read(int count)
        {
            if (EOF) throw new InvalidOperationException("All bytes are parsed.");
            if (Stream.Position + count > Stream.Length) throw new InvalidOperationException("Not enough bytes to read.");

            var buffer = new byte[count];
            Stream.Read(buffer, 0, count);
            return buffer;
        }
        public string ReadString(int count, Encoding encoding) => encoding.GetString(Read(count));

        public char ReadChar() => BitConverter.ToChar(Read(sizeof(char)), 0);
        public short ReadInt16() => BitConverter.ToInt16(Read(sizeof(short)), 0);
        public ushort ReadUInt16() => BitConverter.ToUInt16(Read(sizeof(ushort)), 0);
        public int ReadInt32() => BitConverter.ToInt32(Read(sizeof(int)), 0);
        public uint ReadUInt32() => BitConverter.ToUInt32(Read(sizeof(uint)), 0);
        public long ReadInt64() => BitConverter.ToInt64(Read(sizeof(long)), 0);
        public ulong ReadUInt64() => BitConverter.ToUInt64(Read(sizeof(ulong)), 0);
        public float ReadSingle() => BitConverter.ToSingle(Read(sizeof(float)), 0);
        public double ReadDouble() => BitConverter.ToDouble(Read(sizeof(double)), 0);

        public BytesParser Read(ref byte[] @ref, int count)
        {
            @ref = Read(count);
            return this;
        }

        public BytesParser ReadChar(ref char @ref)
        {
            @ref = BitConverter.ToChar(Read(sizeof(char)), 0);
            return this;
        }
        public BytesParser ReadInt16(ref short @ref)
        {
            @ref = BitConverter.ToInt16(Read(sizeof(short)), 0);
            return this;
        }

        public BytesParser ReadUInt16(ref ushort @ref)
        {
            @ref = BitConverter.ToUInt16(Read(sizeof(ushort)), 0);
            return this;
        }

        public BytesParser ReadInt32(ref int @ref)
        {
            @ref = BitConverter.ToInt32(Read(sizeof(int)), 0);
            return this;
        }

        public BytesParser ReadUInt32(ref uint @ref)
        {
            @ref = BitConverter.ToUInt32(Read(sizeof(uint)), 0);
            return this;
        }

        public BytesParser ReadInt64(ref long @ref)
        {
            @ref = BitConverter.ToInt64(Read(sizeof(long)), 0);
            return this;
        }

        public BytesParser ReadUInt64(ref ulong @ref)
        {
            @ref = BitConverter.ToUInt64(Read(sizeof(ulong)), 0);
            return this;
        }

        public BytesParser ReadSingle(ref float @ref)
        {
            @ref = BitConverter.ToSingle(Read(sizeof(float)), 0);
            return this;
        }

        public BytesParser ReadDouble(ref double @ref)
        {
            @ref = BitConverter.ToDouble(Read(sizeof(double)), 0);
            return this;
        }

        public BytesParser ReadString(ref string @ref, int count, Encoding encoding)
        {
            @ref = ReadString(count, encoding);
            return this;
        }

        public void Seek(long offset, SeekOrigin seekOrigin) => Stream.Seek(offset, seekOrigin);

    }
}
