namespace CodeWars.Tests
{
    using CodeWars.App.Challenges;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class MiddlePermutationKataTests
    {

        [Test]
        public void BasicTests()
        {
            var kata = new MiddlePermutationKata();

            Assert.AreEqual("bac", kata.MiddlePermutation("abc"));

            Assert.AreEqual("bdca", kata.MiddlePermutation("abcd"));

            Assert.AreEqual("cbxda", kata.MiddlePermutation("abcdx"));

            Assert.AreEqual("cxgdba", kata.MiddlePermutation("abcdxg"));

            Assert.AreEqual("dczxgba", kata.MiddlePermutation("abcdxgz"));

        }

    }
}
