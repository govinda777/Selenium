using System;
using System.Drawing;
using System.Drawing.Imaging;
using Facade.Selenium.Infra.Helper;
using Facade.Selenium.Infra;


namespace Facade.Selenium.Test.SeleniumTest.Core.Helper
{
    
    public class ScreenCaptureTest
    {
        
        public void CaptureScreenTest()
        {
            ScreenCapture sc = new ScreenCapture();
            // capture entire screen, and save it to a file
            Image img = sc.CaptureScreen();

            img.Save(@"c:\teste.gif", ImageFormat.Gif);
        }
    }
}
