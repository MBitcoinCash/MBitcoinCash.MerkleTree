// <copyright file="HashTests.cs" company="Modular Bitcoin Cash">
// Copyright (c) 2018-2018 Modular Bitcoin Cash developers.
// Distributed under the MIT software license, see the accompanying LICENSE file in the project root
// or http://www.opensource.org/licenses/mit-license.php for full license information.
// </copyright>

namespace MBitcoinCash.MerkleTree.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for <seealso cref="Hash"/> class.
    /// </summary>
    [TestClass]
    public class HashTests
    {
        /// <summary>
        /// Creates from string should match to string.
        /// </summary>
        [TestMethod]
        public void CreateFromStringShouldMatchToString()
        {
            var hashString = "fd636107ceb6de2486331ad662955d09abf0414079f2ea59f12da2cfa15c4561";
            var hash = new Hash(hashString);
            Assert.AreEqual(hashString, hash.ToString());
        }
    }
}
