namespace CodeWars.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CodeWars.App.Challenges;
    using NUnit.Framework;

    [TestFixture]
    public class IsInterestingTest
    {
        [Test]
        public void Given_Less_Than_100_Then_Uninteresting()
        {
            Assert.AreEqual(0, Kata.IsInteresting(3, new List<int>() { 1337, 256 }));
        }
        [Test]
        public void Given_Almost_Awesome_Then_Almost_Interesting()
        {
            Assert.AreEqual(1, Kata.IsInteresting(1336, new List<int>() { 1337, 256 }));
        }
        [Test]
        public void Given_Just_Past_Awesome_Then_Not_Interesting()
        {
            Assert.AreEqual(0, Kata.IsInteresting(1338, new List<int>() { 1337, 256 }));
        }
        [Test]
        public void Given_Awesome_Number_Then_Interesting()
        {
            Assert.AreEqual(2, Kata.IsInteresting(1337, new List<int>() { 1337, 256 }));
        }
        [Test]
        public void Given_Uninteresting_Number_Then_Uninteresting()
        {
            Assert.AreEqual(0, Kata.IsInteresting(11208, new List<int>() { 1337, 256 }));
        }
        [Test]
        public void Given_Almost_Palindrome_Then_Almost_Interesting()
        {
            Assert.AreEqual(1, Kata.IsInteresting(11209, new List<int>() { 1337, 256 }));
        }
        [Test]
        public void Given_Palindrome_Then_Interesting()
        {
            Assert.AreEqual(2, Kata.IsInteresting(11211, new List<int>() { 1337, 256 }));
        }
        [Test]
        public void Given_0_Based_Number_Then_Interesting()
        {
            Assert.AreEqual(2, Kata.IsInteresting(100000, new List<int> { 1337, 256 }));
        }
        [Test]
        public void Given_All_Numbers_Are_The_Same_Then_Interesting()
        {
            Assert.AreEqual(2, Kata.IsInteresting(55555, new List<int> { 1337, 256 }));
        }
        [Test]
        public void Given_Almost_0_Based_Number_Then_Almost_Intersting()
        {
            Assert.AreEqual(1, Kata.IsInteresting(49998, new List<int> { 1337, 256 }));
        }
        [Test]
        public void Given_Interesting_Nuber_Just_Past_Then_Not_Interesting()
        {
            Assert.AreEqual(0, Kata.IsInteresting(40000009, new List<int> { 1337, 256 }));
        }
        [TestCase(123456)]
        [TestCase(67890)]
        public void Given_Ascending_Numbers_Then_Intersting(int input)
        {
            Assert.AreEqual(2, Kata.IsInteresting(input, new List<int> { 1337, 256 }));

        }
        [TestCase(123454)]
        public void Given_Almost_Ascending_Numbers_Then_Almost_Intersting(int input)
        {
            Assert.AreEqual(1, Kata.IsInteresting(input, new List<int> { 1337, 256 }));
        }
        [TestCase(654321)]
        [TestCase(654)]
        public void Given_Descending_Numbers_Then_Intersting(int input)
        {
            Assert.AreEqual(2, Kata.IsInteresting(input, new List<int> { 1337, 256 }));
        }
        [Test]
        public void Given_Almost_Descending_Numbers_Then_Almost_Interesting()
        {
            Assert.AreEqual(1, Kata.IsInteresting(654319, new List<int> { 1337, 256 }));
        }
    }
}
