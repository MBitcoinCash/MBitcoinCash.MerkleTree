namespace MBitcoinCash.MerkleTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MerkleTree
    {
        private readonly IHashProvider hashProvider;
        private MerkleNodeBase root;

        public MerkleTree(IHashProvider hashProvider)
        {
            this.hashProvider = hashProvider;
        }

        public IHash RootHash 
            => root.Hash;

        /// <summary>
        /// Builds the tree.
        /// </summary>
        /// <param name="hashes">The hashes.</param>
        public void BuildTree(IList<IHash> hashes)
        {
            if (hashes.Count == 0)
            {
                throw new InvalidOperationException("At least one hash has to be provided in order to build Mrekle Tree.");
            }
            var a = new List<IHash>();
            var merkleLeaves = hashes.Select(hash => new MerkleLeaf(hash)).ToList<MerkleNodeBase>();
            this.BuildTree(merkleLeaves);
        }

        private void BuildTree(IList<MerkleNodeBase> nodes)
        {
            // if only one node, then we reached the root level
            if (nodes.Count == 1)
            {
                root = nodes[0];
                return;
            }

            // new list of next level nodes
            var nextLevelNodes = new List<MerkleNodeBase>();

            // the lenght of list where each node has a pair.
            var lenghtOfPairs = (nodes.Count / 2) * 2;

            // calculate next level nodes for each current level node pair
            for (var i = 0; i < lenghtOfPairs; i += 2)
            {
                var newNode = new MerkleNode(this.hashProvider, nodes[i], nodes[i + 1]);
                nextLevelNodes.Add(newNode);
            }

            // if there is one node left without pair (odd number of nodes), then use same node for both childs
            if (nodes.Count > lenghtOfPairs)
            {
                var newNode = new MerkleNode(this.hashProvider, nodes[nodes.Count-1], nodes[nodes.Count - 1]);
                nextLevelNodes.Add(newNode);
            }

            this.BuildTree(nextLevelNodes);
        }
    }
}
