using Task;

namespace UnitTests
{
    public class TestSimpleFinder
    {
        public TestSimpleFinder()
        {
        }

        [Fact]
        public void ShouldFindPalindromes1()
        {
            SmartFinder finder = new SmartFinder();

            string result = finder.SearchPalindrome("a");

            Assert.Equal("a", result);
        }

        [Fact]
        public void ShouldFindPalindromes2()
        {
            SmartFinder finder = new SmartFinder();

            string result = finder.SearchPalindrome("abb");

            Assert.Equal("bb", result);
        }

        [Fact]
        public void ShouldFindPalindromes3()
        {
            SmartFinder finder = new SmartFinder();

            string result = finder.SearchPalindrome("abc");

            Assert.Equal("a", result);
        }

        [Fact]
        public void ShouldFindPalindromes()
        {
            SmartFinder finder = new SmartFinder();

            string result = finder.SearchPalindrome("abcbdefgfer");

            Assert.Equal("efgfe", result);
        }

        [Fact]
        public void ShouldFindPalindromesOdd()
        {
            SmartFinder finder = new SmartFinder();

            string result = finder.SearchPalindrome("abcbdeffer");

            Assert.Equal("effe", result);
        }

        [Fact]
        public void ShouldFindPalindromesDuplicates()
        {
            SmartFinder finder = new SmartFinder();

            string result = finder.SearchPalindrome("bcbdcafgfer");

            Assert.Equal("fgf", result);
        }

        [Fact]
        public void ShouldFindPalindromesOdd2()
        {
            SmartFinder finder = new SmartFinder();

            string result = finder.SearchPalindrome("abcbdbcbdefgr");

            Assert.Equal("bcbdbcb", result);
        }

        [Fact]
        public void ShouldFindPalindromes4()
        {
            SmartFinder finder = new SmartFinder();

            string result = finder.SearchPalindrome("afcfdfcfdfcfgr");

            Assert.Equal("fcfdfcfdfcf", result);
        }
    }
}