namespace CodeWars.Tests
{
    using CodeWars.App.Challenges;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SG1SampleTest
    {
        [Test]
        public void TestNoSolution()
        {
            var existingWires = "SX.\n" +
                                "XX.\n" +
                                "..G";

            var solution = "Oh for crying out loud...";

            Assert.AreEqual(solution, SG1.WireDHD(existingWires));
        }

        [Test]
        public void Test3x3_1()
        {
            var existingWires = "SX.\n" +
                                "X..\n" +
                                "XXG";

            var solution = "SX.\n" +
                           "XP.\n" +
                           "XXG";

            var output = SG1.WireDHD(existingWires);
            Assert.AreEqual(solution, output);
        }

        [Test]
        public void Test3x3_2()
        {

            var existingWires = ".S.\n" +
                                "...\n" +
                                ".G.";

            var solution = ".S.\n" +
                           ".P.\n" +
                           ".G.";

            var output = SG1.WireDHD(existingWires);
            Assert.AreEqual(solution, output);

        }

        [Test]
        public void Test3x3_3()
        {

            var existingWires = "...\n" +
                            "S.G\n" +
                            "...";

            var solution = "...\n" +
                           "SPG\n" +
                           "...";
                           
            var output = SG1.WireDHD(existingWires);
            Assert.AreEqual(solution, output);

        }

        [Test]
        public void Test3x3_4()
        {

            var existingWires = "...\n" +
                                "SG.\n" +
                                "...";

            var solution = "...\n" +
                           "SG.\n" +
                           "...";

            var output = SG1.WireDHD(existingWires);
            Assert.AreEqual(solution, output);
        }

        [Test]
        public void Test5x5()
        {
            var existingWires = ".S...\n" +
                                "XXX..\n" +
                                ".X.XX\n" +
                                "..X..\n" +
                                "G...X";

            var solution = ".SP..\n" +
                           "XXXP.\n" +
                           ".XPXX\n" +
                           ".PX..\n" +
                           "G...X";

            Assert.AreEqual(solution, SG1.WireDHD(existingWires));
        }

        [Test]
        public void Test10x10()
        {
            var existingWires = "XX.S.XXX..\n" +
                                "XXXX.X..XX\n" +
                                "...X.XX...\n" +
                                "XX...XXX.X\n" +
                                "....XXX...\n" +
                                "XXXX...XXX\n" +
                                "X...XX...X\n" +
                                "X...X...XX\n" +
                                "XXXXXXXX.X\n" +
                                "G........X";

            var solutionsSet = new HashSet<string>
        {
            "XX.S.XXX..\n" +
            "XXXXPX..XX\n" +
            "...XPXX...\n" +
            "XX.P.XXX.X\n" +
            "...PXXX...\n" +
            "XXXXPP.XXX\n" +
            "X...XXP..X\n" +
            "X...X..PXX\n" +
            "XXXXXXXXPX\n" +
            "GPPPPPPP.X",

            "XX.S.XXX..\n" +
            "XXXXPX..XX\n" +
            "...XPXX...\n" +
            "XX..PXXX.X\n" +
            "...PXXX...\n" +
            "XXXXPP.XXX\n" +
            "X...XXP..X\n" +
            "X...X..PXX\n" +
            "XXXXXXXXPX\n" +
            "GPPPPPPP.X"
        };

            var actual = SG1.WireDHD(existingWires);
            Assert.IsTrue(solutionsSet.Contains(actual), $"Your solution:\n{actual}\n\nShould be:{string.Join("\n", solutionsSet)}");
        }

        [Test]
        public void AdditionalTest()
        {
            var existingWires = "...X..X.X.....X..XXXX.GXXX\n" +
                                "XX.X.XX..X..X.X..XX.XXX...\n" +
                                "XXXX.X.X.X..X.XXXX.X.X.X.X\n" +
                                "XX..XX.X.X.XXXXXXXXX..X..X\n" +
                                "XXXXX.X.X.XXX..X.XXXX...XX\n" +
                                ".XX.X..XX.X.XX.X.XXXXX.XX.\n" +
                                "...XXX.X.XXXXX.XXXX...X.XX\n" +
                                ".X.XXXXX.X....XXXX..XXX..X\n" +
                                "XXX..X..XX.XXXXXX.XXX..X.X\n" +
                                "XX....XX..X.X....X...X.X.X\n" +
                                "..XXX.XXXXX..X..XX.XXXX.X.\n" +
                                "...X..XXXX.X...X.XXX..XX.X\n" +
                                "..XX.XX.XXX.XXX.XXXXXX.X..\n" +
                                "XX.XXXXX...X..X.XX...XX...\n" +
                                "XX.X.....XXX.X.XX.XX.XX..X\n" +
                                ".X...X.XX.XXX.X..X.X.XXX.X\n" +
                                "XX.X..XXX.XXX.....XXX.XXX.\n" +
                                ".XX.X.XX.XXX...X.X..XXXXX.\n" +
                                "...X.XX.X.X..XXX..X..X.X.X\n" +
                                "XXXXXXX......XXX...X...XX.\n" +
                                "X..X.XXX..XX..X.XX..XXXXXX\n" +
                                "XXX...XX.X.XX.XXXXXXXX...X\n" +
                                "X.X.XXX.X.XX.SX.XXX.XX.XXX\n" +
                                "..XXXX..X..XX..X..X....X.X\n" +
                                "X..XXX.XXX..X..X.X.X.X..X.\n" +
                                "XX.X.X......XX..XX.X.XX..X";
        
            var solution = "...X..X.X.....X..XXXX.GXXX\n" +
                                "XX.X.XX..X..X.X..XX.XXXP..\n" +
                                "XXXX.X.X.X..X.XXXX.X.XPX.X\n" +
                                "XX..XX.X.X.XXXXXXXXX.PX..X\n" +
                                "XXXXX.X.X.XXX..X.XXXXP..XX\n" +
                                ".XX.X..XX.X.XX.X.XXXXXPXX.\n" +
                                "...XXX.X.XXXXX.XXXX.PPX.XX\n" +
                                ".X.XXXXX.X....XXXXPPXXX..X\n" +
                                "XXX..X..XX.XXXXXXPXXX..X.X\n" +
                                "XX....XX..X.X...PX...X.X.X\n" +
                                "..XXX.XXXXX..X.PXX.XXXX.X.\n" +
                                "...X..XXXX.X..PX.XXX..XX.X\n" +
                                "..XX.XX.XXX.XXXPXXXXXX.X..\n" +
                                "XX.XXXXX...X..XPXX...XX...\n" +
                                "XX.X.....XXX.XPXX.XX.XX..X\n" +
                                ".X...X.XX.XXX.XP.X.X.XXX.X\n" +
                                "XX.X..XXX.XXX.P...XXX.XXX.\n" +
                                ".XX.X.XX.XXX.P.X.X..XXXXX.\n" +
                                "...X.XX.X.X.PXXX..X..X.X.X\n" +
                                "XXXXXXX.....PXXX...X...XX.\n" +
                                "X..X.XXX..XX.PX.XX..XXXXXX\n" +
                                "XXX...XX.X.XXPXXXXXXXX...X\n" +
                                "X.X.XXX.X.XX.SX.XXX.XX.XXX\n" +
                                "..XXXX..X..XX..X..X....X.X\n" +
                                "X..XXX.XXX..X..X.X.X.X..X.\n" +
                                "XX.X.X......XX..XX.X.XX..X";

            Assert.AreEqual(solution, SG1.WireDHD(existingWires));
        }
    }
}
