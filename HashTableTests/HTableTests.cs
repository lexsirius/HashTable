using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTable;

namespace HashTableTests
{
    [TestClass]
    public class HTableTests
    {
        [TestMethod]
        public void ThreeElements()
        {
            var hashTable = new HashTable(3);
            hashTable.PutPair(1, "one");
            hashTable.PutPair(2, "two");
            hashTable.PutPair(3, "three");
            Assert.AreEqual("one", hashTable.GetValueByKey(1));
            Assert.AreEqual("three", hashTable.GetValueByKey(3));
            Assert.AreEqual(null, hashTable.GetValueByKey(4));
        }

        [TestMethod]
        public void SameKey()
        {
            var hashTable = new HashTable(2);
            hashTable.PutPair(1, "one");
            hashTable.PutPair(1, "ONE");
            Assert.AreEqual("ONE", hashTable.GetValueByKey(1));
        }

        [TestMethod]
        public void BigTable()
        {
            var hashTable = new HashTable(10000);
            for(int i = 0; i < 10000; i++)
                hashTable.PutPair(i, "num " + i);
            Assert.AreEqual("num 999", hashTable.GetValueByKey(999));
        }

        [TestMethod]
        public void NotAddedKeys()
        {
            var hashTable = new HashTable(10000);
            for (int i = 0; i < 10000; i++)
                hashTable.PutPair(i, "num " + i);
            for (int i = 0; i < 1000; i++)
                Assert.AreEqual(null, hashTable.GetValueByKey(99999+i));
        }

    }
}
