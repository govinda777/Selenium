using System;
using System.Drawing;
using System.Drawing.Imaging;
using Iteris.Selenium.Core.Helper;
using Iteris.Selenium.Core.Selemiun;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Selenium.Test.HelperTest
{
    [TestClass]
    public class ScreenCaptureTest
    {
        [TestMethod]
        public void CaptureScreenTest()
        {
            ScreenCapture sc = new ScreenCapture();
            // capture entire screen, and save it to a file
            Image img = sc.CaptureScreen();

            img.Save(@"c:\teste.gif", ImageFormat.Gif);
        }
    }
}
