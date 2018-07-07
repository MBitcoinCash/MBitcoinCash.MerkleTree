// <copyright file="IMerkleTree.cs" company="Modular Bitcoin Cash">
// Copyright (c) 2018-2018 Modular Bitcoin Cash developers.
// Distributed under the MIT software license, see the accompanying LICENSE file in the project root
// or http://www.opensource.org/licenses/mit-license.php for full license information.
// </copyright>

namespace MBitcoinCash.MerkleTree
{
    /// <summary>
    /// Interface for MekleTree.
    /// </summary>
    public interface IMerkleTree
    {
        /// <summary>
        /// Gets the Merkle Tree root hash.
        /// </summary>
        /// <returns>The hash of Merkle Tree root.</returns>
        IHash GetRootHash();
    }
}
