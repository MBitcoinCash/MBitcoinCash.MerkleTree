namespace MBitcoinCash.MerkleTree
{
    using System;

    internal class MerkleLeaf : MerkleNodeBase
    {
        private IHash leafHash;

        public override IHash Hash => this.leafHash;

        internal MerkleLeaf(IHash leafHash)
        {
            this.leafHash = leafHash ?? throw new ArgumentNullException(nameof(leafHash), "Can not construct the leaf of Merkle Tree if hash is not provided.");
        }
    }
}
