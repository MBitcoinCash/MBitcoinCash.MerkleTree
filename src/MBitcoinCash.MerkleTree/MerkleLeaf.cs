// <copyright file="MerkleLeaf.cs" company="Modular Bitcoin Cash">
// Copyright (c) 2018-2018 Modular Bitcoin Cash developers.
// Distributed under the MIT software license, see the accompanying LICENSE file in the project root
// or http://www.opensource.org/licenses/mit-license.php for full license information.
// </copyright>

namespace MBitcoinCash.MerkleTree
{
    using System;

    /// <summary>
    /// The Merkle Tree leaf node located at the lowes level of Merkle Tree.
    /// </summary>
    /// <seealso cref="MBitcoinCash.MerkleTree.MerkleNodeBase" />
    internal class MerkleLeaf : MerkleNodeBase
    {
        /// <summary>
        /// The hash of this leaf node
        /// </summary>
        private IHash leafHash;

        /// <summary>
        /// Initializes a new instance of the <see cref="MerkleLeaf"/> class.
        /// </summary>
        /// <param name="leafHash">The hash of the leaf node.</param>
        /// <exception cref="ArgumentNullException">leafHash - Can not construct the leaf node of Merkle Tree if hash is not provided.</exception>
        internal MerkleLeaf(IHash leafHash)
        {
            this.leafHash = leafHash ?? throw new ArgumentNullException(nameof(leafHash), "Can not construct the leaf node of Merkle Tree if hash is not provided.");
        }

        /// <inheritdoc/>
        public override IHash Hash => this.leafHash;
    }
}
