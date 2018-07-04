namespace MBitcoinCash.MerkleTree.Tests
{
    using System;
    using System.Linq;

    internal class Hash : IHash
    {
        internal Hash(byte[] hash)
        {
            this.HashBytes = hash;
        }

        internal Hash(string hash)
        {
            this.HashBytes = Enumerable.Range(0, hash.Length / 2).Select(x => Convert.ToByte(hash.Substring(x * 2, 2), 16)).ToArray();
            Array.Reverse(this.HashBytes);
        }

        public override string ToString()
        {
            var reversedArray = new byte[this.HashBytes.Length];
            this.HashBytes.CopyTo(reversedArray, 0);
            Array.Reverse(reversedArray);

            return BitConverter.ToString(reversedArray).Replace("-", "").ToLower();
        }

        public byte[] HashBytes { get; }
    }
}
