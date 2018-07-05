// <copyright file="MerkleTree.cs" company="Modular Bitcoin Cash">
// Copyright (c) 2018-2018 Modular Bitcoin Cash developers.
// Distributed under the MIT software license, see the accompanying LICENSE file in the project root
// or http://www.opensource.org/licenses/mit-license.php for full license information.
// </copyright>

namespace MBitcoinCash.MerkleTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The Merkle Tree structure.
    /// </summary>
    public class MerkleTree
    {
        /// <summary>
        /// The objeckt that knows how to calculate hashes
        /// </summary>
        private readonly IHashProvider hashProvider;

        /// <summary>
        /// The root node of this Merkle Tree
        /// </summary>
        private MerkleNodeBase root;

        /// <summary>
        /// Initializes a new instance of the <see cref="MerkleTree"/> class.
        /// </summary>
        /// <param name="hashProvider">The hash provider.</param>
        public MerkleTree(IHashProvider hashProvider)
        {
            this.hashProvider = hashProvider;
        }

        /// <summary>
        /// Gets the Merkle Tree root hash.
        /// </summary>
        /// <returns>The hash of Merkle Tree root.</returns>
        public IHash GetRootHash()
        {
            if (this.root == null)
            {
                throw new InvalidOperationException("Could not get the hash of Merkle Tree root, because Merkle Tree is not built yet.");
            }

            return this.root.Hash;
        }

        /// <summary>
        /// Builds the tree from the list of hashes.
        /// </summary>
        /// <param name="hashes">The list of hashes.</param>
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

        /// <summary>
        /// Builds the Merkle Tree recursivly from the list of Leaf nodes to the root node.
        /// </summary>
        /// <remarks>
        /// Merkle tree is built from lowest level to the highest (root) level.
        /// In each level nodes are paired and their parent node is constructed.
        /// If there is odd number of nodes, then last parent node is calculated using same node for both childs.
        /// </remarks>
        /// <param name="nodes">The list of nodes.</param>
        private void BuildTree(IList<MerkleNodeBase> nodes)
        {
            // if only one node, then we reached the root level
            if (nodes.Count == 1)
            {
                this.root = nodes[0];
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
                var newNode = new MerkleNode(this.hashProvider, nodes[nodes.Count - 1], nodes[nodes.Count - 1]);
                nextLevelNodes.Add(newNode);
            }

            this.BuildTree(nextLevelNodes);
        }
    }
}
