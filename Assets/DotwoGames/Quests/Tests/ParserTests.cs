using NUnit.Framework;

namespace DotwoGames.Quests.Tests
{
    public class ParserTests
    {
        [Test]
        public void ParserTestsEqualsCondition()
        {
            Assert.True(Parser.IsValid("=1.2.3", "1.2.3"));

            Assert.False(Parser.IsValid("=1.2.3", "1.2.33"));
            Assert.False(Parser.IsValid("=1.2.3", "1.22.3"));
            Assert.False(Parser.IsValid("=1.2.3", "11.2.3"));
        }

        [Test]
        public void ParserTestsLessThanCondition()
        {
            Assert.True(Parser.IsValid("<1.2.3", "1.2.2"));
            Assert.True(Parser.IsValid("<1.2.3", "1.1.3"));
            Assert.True(Parser.IsValid("<1.2.3", "0.4.5"));
            Assert.True(Parser.IsValid("<1.2.13", "1.2.5"));

            Assert.False(Parser.IsValid("<1.2.13", "1.12.5"));
            Assert.False(Parser.IsValid("<1.2.3", "1.2.3"));
        }

        [Test]
        public void ParserTestsGreaterThanCondition()
        {
            Assert.True(Parser.IsValid(">1.2.3", "1.2.4"));
            Assert.True(Parser.IsValid(">1.2.3", "1.4.1"));
            Assert.True(Parser.IsValid(">1.2.3", "2.1.1"));

            Assert.False(Parser.IsValid(">1.3.1", "1.1.1"));
            Assert.False(Parser.IsValid(">1.2.3", "1.2.3"));
            Assert.False(Parser.IsValid(">1.2.13", "1.2.3"));
        }

        [Test]
        public void ParserTestsValidation()
        {
            Assert.True(Parser.IsValid("> 1.2.3", "1.2.4"));
            Assert.True(Parser.IsValid(" =1.2.3", "1.2.3"));

            Assert.False(Parser.IsValid("1.2.3", "1.2.3"));
        }
    }
}
