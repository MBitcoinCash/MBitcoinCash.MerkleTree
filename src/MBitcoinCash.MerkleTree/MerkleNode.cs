namespace MBitcoinCash.MerkleTree
{
    using System.Linq;

    internal class MerkleNode : MerkleNodeBase
    {
        private MerkleNodeBase left;
        private MerkleNodeBase right;
        private IHash nodeHash;

        public override IHash Hash => this.nodeHash;

        internal MerkleNode(IHashProvider hashProvider, MerkleNodeBase left, MerkleNodeBase right)
        {
            this.right = right;
            this.left = left;
            this.nodeHash = hashProvider.ComputeHash(left.Hash.HashBytes.Concat(right.Hash.HashBytes).ToArray());
        }
    }
}
