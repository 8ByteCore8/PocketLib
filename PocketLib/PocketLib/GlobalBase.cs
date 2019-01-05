//C#
//© Кушнір Б.T. , 2018
using System.IO;
using System.Reflection;

namespace PocketLib
{
    public static class GlobalBase
    {
        public static string CacheDir { get; } = $"{RootDir}/Cache";
        public static string DataDir { get; } = $"{RootDir}/Data";
        public static string ModulesDir { get; } = $"{RootDir}/Modules";
        public static string ResourcesDir { get; } = $"{RootDir}/Resources";
        public static string RootDir { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}