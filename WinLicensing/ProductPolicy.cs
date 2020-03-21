using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WinLicensing
{
    public class ProductPolicy
    {
        public ProductPolicyHeader Header = new ProductPolicyHeader();
        public ProductPolicyValue[] Values;

        public ProductPolicy(byte[] bytes)
        {
            var parser = new BytesParser(bytes);
            var valueList = new List<ProductPolicyValue>();

            parser
                .ReadUInt32(ref Header.cbSize)
                .ReadUInt32(ref Header.cbDataSize)
                .ReadUInt32(ref Header.cbEndMarker)
                .ReadUInt32(ref Header.Unknown1)
                .ReadUInt32(ref Header.Unknown2);

            while (!parser.EOF)
            {
                var value = new ProductPolicyValue()
                {
                    cbSize = parser.ReadUInt16(),
                    cbName = parser.ReadUInt16(),
                };

                if (value.cbName == 0) break;
                parser
                    .ReadUInt16(ref value.SlDatatype)
                    .ReadUInt16(ref value.cbData)
                    .ReadUInt32(ref value.Unknown1)
                    .ReadUInt32(ref value.Unknown2)
                    .ReadString(ref value.Key, value.cbName, Encoding.Unicode)
                    .Read(ref value.Value, value.cbData);

                var offset = value.cbSize - sizeof(ushort) * 4 - sizeof(uint) * 2 - value.cbName - value.cbData;
                parser.Seek(offset, SeekOrigin.Current);

                valueList.Add(value);
            }

            Values = valueList.ToArray();
        }

    }
}
