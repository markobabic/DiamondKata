using FluentAssertions;
using NUnit.Framework;

namespace Diamond.Tests
{
    public class DiamondTests
    {
        private Diamond _diamond;

        [SetUp]
        public void Setup()
        {
            _diamond = new Diamond();
        }


        [Test]
        public void WhenSeedIsA_ThenResultIsA()
        {
            // act
            var result = _diamond.Generate('A');

            // assert
            result.Count.Should().Be(1);
            result[0].Should().Be("A");
        }

        [Test]
        public void WhenSeedIsB_ThenFirstLineIsPaddedWithSpace()
        {
            // act
            var result = _diamond.Generate('B');

            // assert
            result[0].Should().Be(" A ");
        }

        [Test]
        public void WhenSeedIsB_ThenLineLengthIsDoubleSeedIndexMinusOne()
        {
            // act
            var result = _diamond.Generate('B');

            // assert
            result.ForEach(line => line.Length.Should().Be(3));
        }

        [Test]
        public void WhenSeedIsB_ThenResultIsABBA()
        {
            // act
            var result = _diamond.Generate('B');

            // assert
            result[0].Should().Be(" A ");
            result[1].Should().Be("B B");
            result[2].Should().Be(" A ");
        }


        [TestCase('A', 1)]
        [TestCase('B', 3)]
        [TestCase('C', 5)]
        [TestCase('D', 7)]
        public void WhenSeedIsGiven_ThenRowNumberAndLineLengthAreEqual(char seed, int dimensions)
        {
            // act
            var result = _diamond.Generate(seed);

            // assert
            result.Count.Should().Be(dimensions);
            result.ForEach(line => line.Length.Should().Be(dimensions));
        }


        [TestCase('C')]
        [TestCase('D')]
        [TestCase('E')]
        public void WhenSeedIsGiven_ThenRowsAreSymetrical(char seed)
        {
            // act
            var result = _diamond.Generate(seed);

            // assert
            for (var i = 0; i < result.Count / 2; i++)
                result[i].Should().Be(result[result.Count - (i + 1)]);
        }

        [TestCase('B')]
        [TestCase('D')]
        [TestCase('K')]
        public void WhenSeedIsGiven_ThenMiddleRowStartsAndEndsWithSeed(char seed)
        {
            // act
            var result = _diamond.Generate(seed);

            // assert
            result[result.Count / 2].Should().StartWith(seed.ToString()).And.EndWith(seed.ToString());
        }
    }
}
