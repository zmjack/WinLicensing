namespace WinLicensing
{
    public class ProductPolicyValue
    {
        public ushort cbSize;
        public ushort cbName;
        public ushort SlDatatype;
        public ushort cbData;
        public uint Unknown1;
        public uint Unknown2;

        public string Key;
        public byte[] Value;
    }
}
