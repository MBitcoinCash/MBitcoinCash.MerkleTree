namespace MBitcoinCash.MerkleTree.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void CreateFromStringShouldMatchToString()
        {
            var hashString = "fd636107ceb6de2486331ad662955d09abf0414079f2ea59f12da2cfa15c4561";
            var hash = new Hash(hashString);
            Assert.AreEqual(hashString, hash.ToString());
        }
    }
}
