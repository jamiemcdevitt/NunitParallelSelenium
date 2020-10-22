using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using TestProject.Core.Utilities;

namespace TestProject.Core.Extensions
{
    public static class DriverExtensions
    {
        public static void WaitForPageLoad(this IWebDriver driver)
        {
            var timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed < AppConfig.ElementLoadWaitTime)
            {
                var wait = new WebDriverWait(driver, AppConfig.ElementLoadWaitTime);
                try
                {
                    wait.Until(x => x.IsDocumentDone() && x.IsAjaxDone() && x.IsAngularDone());
                    break;
                }
                catch (InvalidOperationException)
                {

                }
            }
        }
        private static bool IsAngularDone(this IWebDriver webDriver)
        {
            try
            {
                var script = @"if(window.angular === undefined) return true;
                           if(!angular.element($('.ng-scope')).injector()) angular.reloadWithDebugInfo(); 
                           return angular.element($('.ng-scope')).injector().get('$http').pendingRequests.length == 0;";
                return webDriver.ExecuteJavaScript<bool>(script);
            }
            catch
            {
                var script = @"return (window.angular !== undefined) && (angular.element(document).injector() !== undefined) && (angular.element(document).injector().get('$http').pendingRequests.length === 0)";
                return webDriver.ExecuteJavaScript<bool>(script);
            }
        }

        private static bool IsAjaxDone(this IWebDriver webDriver)
        {
            var script = "return window.jQuery === undefined || jQuery.active == 0";
            var isAjaxDone = webDriver.ExecuteJavaScript<bool>(script);
            return isAjaxDone;
        }

        private static bool IsDocumentDone(this IWebDriver webDriver)
        {
            var script = "return document.readyState == 'complete'";
            var isAjaxDone = webDriver.ExecuteJavaScript<bool>(script);
            return isAjaxDone;
        }
    }
    
}
