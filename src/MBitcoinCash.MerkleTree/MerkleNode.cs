// <copyright file="MerkleNode.cs" company="Modular Bitcoin Cash">
// Copyright (c) 2018-2018 Modular Bitcoin Cash developers.
// Distributed under the MIT software license, see the accompanying LICENSE file in the project root
// or http://www.opensource.org/licenses/mit-license.php for full license information.
// </copyright>

namespace MBitcoinCash.MerkleTree
{
    using System.Linq;

    /// <summary>
    /// The Merkle Tree non-leaf node. Always has two child nodes.
    /// </summary>
    /// <seealso cref="MBitcoinCash.MerkleTree.MerkleNodeBase" />
    internal class MerkleNode : MerkleNodeBase
    {
        /// <summary>
        /// The left child node
        /// </summary>
        private readonly MerkleNodeBase left;

        /// <summary>
        /// The right child node
        /// </summary>
        private readonly MerkleNodeBase right;

        /// <summary>
        /// The hash of this node
        /// </summary>
        private readonly IHash nodeHash;

        /// <summary>
        /// Initializes a new instance of the <see cref="MerkleNode"/> class.
        /// </summary>
        /// <param name="hashProvider">The hash provider.</param>
        /// <param name="left">The left child node.</param>
        /// <param name="right">The right child node.</param>
        internal MerkleNode(IHashProvider hashProvider, MerkleNodeBase left, MerkleNodeBase right)
        {
            this.right = right;
            this.left = left;
            this.nodeHash = hashProvider.ComputeHash(left.Hash.GetHashBytes().Concat(right.Hash.GetHashBytes()).ToArray());
        }

        /// <inheritdoc/>
        public override IHash Hash => this.nodeHash;
    }
}
