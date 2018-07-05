// <copyright file="IHash.cs" company="Modular Bitcoin Cash">
// Copyright (c) 2018-2018 Modular Bitcoin Cash developers.
// Distributed under the MIT software license, see the accompanying LICENSE file in the project root
// or http://www.opensource.org/licenses/mit-license.php for full license information.
// </copyright>

namespace MBitcoinCash.MerkleTree
{
    /// <summary>
    /// Interface for the object that stores calculated hash.
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// Gets the hash as byte array.
        /// </summary>
        /// <value>
        /// The hash as byte array.
        /// </value>
        byte[] HashBytes { get; }
    }
}
