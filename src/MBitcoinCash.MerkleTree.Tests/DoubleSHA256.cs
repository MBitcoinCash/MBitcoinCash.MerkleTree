namespace MBitcoinCash.MerkleTree.Tests
{
    using System.Security.Cryptography;

    internal class DoubleSHA256 : IHashProvider
    {
        public IHash ComputeHash(byte[] input)
        {
            var sha256 = SHA256.Create();
            var firstHash = sha256.ComputeHash(input);
            var secondHash = sha256.ComputeHash(firstHash);
            return new Hash(secondHash);
        }
    }
}
