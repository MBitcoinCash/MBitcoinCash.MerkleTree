// <copyright file="Hash.cs" company="Modular Bitcoin Cash">
// Copyright (c) 2018-2018 Modular Bitcoin Cash developers.
// Distributed under the MIT software license, see the accompanying LICENSE file in the project root
// or http://www.opensource.org/licenses/mit-license.php for full license information.
// </copyright>

namespace MBitcoinCash.MerkleTree.Tests
{
    using System;
    using System.Linq;

    /// <summary>
    /// Hash implementation for testing.
    /// </summary>
    /// <seealso cref="MBitcoinCash.MerkleTree.IHash" />
    internal class Hash : IHash
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hash"/> class.
        /// </summary>
        /// <param name="hash">The hash.</param>
        internal Hash(byte[] hash)
        {
            this.HashBytes = hash;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hash"/> class.
        /// </summary>
        /// <param name="hash">The hash.</param>
        internal Hash(string hash)
        {
            this.HashBytes = Enumerable.Range(0, hash.Length / 2).Select(x => Convert.ToByte(hash.Substring(x * 2, 2), 16)).ToArray();
            Array.Reverse(this.HashBytes);
        }

        /// <inheritdoc/>
        public byte[] HashBytes { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var reversedArray = new byte[this.HashBytes.Length];
            this.HashBytes.CopyTo(reversedArray, 0);
            Array.Reverse(reversedArray);

            return BitConverter.ToString(reversedArray).Replace("-", string.Empty).ToLower();
        }
    }
}
