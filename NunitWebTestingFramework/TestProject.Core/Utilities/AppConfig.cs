using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Core.Utilities
{
    public static class AppConfig
    {
        public static TimeSpan ElementLoadWaitTime { get; private set; }
        public static string InitUrl { get; private set; }
        public static string AssemblyDirectory { get; private set; }

        static AppConfig()
        {
            ElementLoadWaitTime = TimeSpan.FromMilliseconds(4000);
            InitUrl = "http://automationpractice.com/";
            AssemblyDirectory = GetDirectoryName();
        }
        private static string GetDirectoryName()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
