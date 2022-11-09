namespace CodeWars.Tests
{
    using System;
    using NUnit.Framework;
    using CodeWars.App.Challenges;

    [TestFixture]
    public class MorseCodeDecoderTests
    {
        [Test]
        public void MorseCodeDecoderBasicTest_1()
        {
            try
            {
                string input = ".... . -.--   .--- ..- -.. .";
                string expected = "HEY JUDE";

                string actual = MorseCodeDecoder.Decode(input);

                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Assert.Fail("There seems to be an error somewhere in your code. Exception message reads as follows: " + ex.Message);
            }
        }

        [Test]
        public void TestExampleFromDescription()
        {
            Assert.AreEqual("HEY JUDE", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011")));
        }

        [TestCase("1", ".")]
        [TestCase("111", ".")]
        [TestCase("0001110", ".")]
        [TestCase("10101010001000111010111011100000001011101110111000101011100011101010001", ".... . -.--   .--- ..- -.. .")]
        [TestCase("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011", ".... . -.--   .--- ..- -.. .")]
        [TestCase("00011100010101010001000000011101110101110001010111000101000111010111010001110101110000000111010101000101110100011101110111000101110111000111010000000101011101000111011101110001110101011100000001011101110111000101011100011101110001011101110100010101000000011101110111000101010111000100010111010000000111000101010100010000000101110101000101110001110111010100011101011101110000000111010100011101110111000111011101000101110101110101110", "- .... .   --.- ..- .. -.-. -.-   -... .-. --- .-- -.   ..-. --- -..-   .--- ..- -- .--. ...   --- ...- . .-.   - .... .   .-.. .- --.. -.--   -.. --- --. .-.-.-")]
        public void TestMorseDecoder3(string input, string expected)
        {
            Assert.AreEqual(expected, MorseCodeDecoder.DecodeBits(input));
        }

        [TestCase("1", "E")]
        [TestCase("111", "E")]
        [TestCase("0001110", "E")]
        [TestCase("10101010001000111010111011100000001011101110111000101011100011101010001", "HEY JUDE")]
        [TestCase("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011", "HEY JUDE")]
        [TestCase("00011100010101010001000000011101110101110001010111000101000111010111010001110101110000000111010101000101110100011101110111000101110111000111010000000101011101000111011101110001110101011100000001011101110111000101011100011101110001011101110100010101000000011101110111000101010111000100010111010000000111000101010100010000000101110101000101110001110111010100011101011101110000000111010100011101110111000111011101000101110101110101110", "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG.")]
        public void TestMorseDecoder2(string input, string expected)
        {
            Assert.AreEqual(expected, MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits(input)));
        }
    }
}
