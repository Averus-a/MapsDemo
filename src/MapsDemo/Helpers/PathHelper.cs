namespace MapsDemo.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static class PathHelper
    {
        public static string GetAppDir()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().GetModules()[0].FullyQualifiedName);
        }
    }
}
