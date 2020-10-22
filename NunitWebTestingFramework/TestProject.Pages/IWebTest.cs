using OpenQA.Selenium;
using System;

namespace TestProject.Pages
{
    public interface IWebTest:IDisposable
    {
        IWebDriver BaseWebDriver { get; }
    }
}
