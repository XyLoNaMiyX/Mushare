using System;
using System.IO;
using System.Reflection;

namespace Mushare
{
    public static class Utils
    {
        public static readonly string[] SupportedFormats = new string[]
        {
            ".mp3", ".flac", ".ogg", ".aac", ".wav", ".mpga", ".mp4a", ".a52", ".a52b", ".wma"
        };

        public static string GetSupportedFormatsFilter()
        {
            return "*" + string.Join("|*", SupportedFormats);
        }

        public static DirectoryInfo GetVlcLibDirectory()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = Path.GetDirectoryName(currentAssembly.Location);
            if (string.IsNullOrEmpty(currentDirectory))
                return null;

#if X64
            return new DirectoryInfo(Path.Combine(currentDirectory, @"lib\x64\"));
#else
            return new DirectoryInfo(Path.Combine(currentDirectory, @"lib\x86\"));
#endif
        }

        static readonly DateTime epoch = new DateTime(1970, 1, 1);

        public static long GetUnixTimeNow()
        {
            return (long)(DateTime.UtcNow.Subtract(epoch)).TotalMilliseconds;
        }

        public static DateTime GetDateTimeFromUnix(long unix)
        {
            return epoch.AddMilliseconds(unix);
        }
    }
}
