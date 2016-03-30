using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Facade.Selenium.Infra.Helper.Interface
{
    public interface IScreenCapture
    {
        Image CaptureScreen();
        Image CaptureWindow(IntPtr handle);
        void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format);
        void CaptureScreenToFile(string filename, ImageFormat format);
        void CaptureScreen(string evidenceName);
    }
}