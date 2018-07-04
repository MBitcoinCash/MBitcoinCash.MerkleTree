namespace MBitcoinCash.MerkleTree
{
    public interface IHashProvider
    {
        IHash ComputeHash(byte[] input);
    }
}
