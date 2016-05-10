using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Facade.Selenium.Infra.Helper;

namespace Selenium.Test.Infra.Helper
{
    [Trait("Url", "")]
    public class UrlTest
    {
        [Fact]
        public void Test1ConvertingTheSchemeAndHostToLowercase()
        {
            var url1 = "HTTP://www.Example.com/".NormalizeUrl();
            var url2 = "http://www.example.com/".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test2CapitalizingLettersInEscapeSequences()
        {
            var url1 = "http://www.example.com/a%c2%b1b".NormalizeUrl();
            var url2 = "http://www.example.com/a%C2%B1b".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test3DecodingPercentEncodedOctetsOfUnreservedCharacters()
        {
            var url1 = "http://www.example.com/%7Eusername/".NormalizeUrl();
            var url2 = "http://www.example.com/~username/".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test4RemovingTheDefaultPort()
        {
            var url1 = "http://www.example.com:80/bar.html".NormalizeUrl();
            var url2 = "http://www.example.com/bar.html".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test5AddingTrailing()
        {
            var url1 = "http://www.example.com/alice".NormalizeUrl();
            var url2 = "http://www.example.com/alice/?".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test6RemovingDotSegments()
        {
            var url1 = "http://www.example.com/../a/b/../c/./d.html".NormalizeUrl();
            var url2 = "http://www.example.com/a/c/d.html".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test7RemovingDirectoryIndex1()
        {
            var url1 = "http://www.example.com/default.asp".NormalizeUrl();
            var url2 = "http://www.example.com/".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test7RemovingDirectoryIndex2()
        {
            var url1 = "http://www.example.com/default.asp?id=1".NormalizeUrl();
            var url2 = "http://www.example.com/default.asp?id=1".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test7RemovingDirectoryIndex3()
        {
            var url1 = "http://www.example.com/a/index.html".NormalizeUrl();
            var url2 = "http://www.example.com/a/".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test8RemovingTheFragment()
        {
            var url1 = "http://www.example.com/bar.html#section1".NormalizeUrl();
            var url2 = "http://www.example.com/bar.html".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test9LimitingProtocols()
        {
            var url1 = "https://www.example.com/".NormalizeUrl();
            var url2 = "http://www.example.com/".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test10RemovingDuplicateSlashes()
        {
            var url1 = "http://www.example.com/foo//bar.html".NormalizeUrl();
            var url2 = "http://www.example.com/foo/bar.html".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test11AddWww()
        {
            var url1 = "http://example.com/".NormalizeUrl();
            var url2 = "http://www.example.com".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void Test12RemoveFeedburnerPart()
        {
            var url1 = "http://site.net/2013/02/firefox-19-released/?utm_source=rss&utm_medium=rss&utm_campaign=firefox-19-released".NormalizeUrl();
            var url2 = "http://site.net/2013/02/firefox-19-released".NormalizeUrl();

            Assert.True(url1 == url2);
        }

        [Fact]
        public void NormalizeUrl_RemoveFeedburnerPart()
        {
            var url1 = "https://login.live.com/login.srf/?wa=wsignin1.0&rpsnv=12&ct=1457360630&rver=6.5.6509.0&wp=MBI&wreply=https:%2F%2Fwww.microsoft.com%2Fpt-br%2Faccount%2Fdefault.aspx&lc=1033&id=74335".NormalizeUrl();
            var url2 = "https://login.live.com/login.srf".NormalizeUrl();

            Assert.True(url1 == url2);
        }


        
    }
}
