namespace Selenium.Core.Interface
{
    public interface INavigation
    {
        void Initialize();
        void CloseWebBrowser();
        void OpenUrl(string url);
        string GetCurrentUrl();
        void NavigateBack();
    }
}