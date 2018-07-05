// <copyright file="MerkleNodeBase.cs" company="Modular Bitcoin Cash">
// Copyright (c) 2018-2018 Modular Bitcoin Cash developers.
// Distributed under the MIT software license, see the accompanying LICENSE file in the project root
// or http://www.opensource.org/licenses/mit-license.php for full license information.
// </copyright>

namespace MBitcoinCash.MerkleTree
{
    /// <summary>
    /// Base class for all Merkle Tree nodes.
    /// </summary>
    internal abstract class MerkleNodeBase
    {
        /// <summary>
        /// Gets the hash of Merkle Tree Node.
        /// </summary>
        /// <value>
        /// The hash.
        /// </value>
        public abstract IHash Hash { get; }
    }
}
