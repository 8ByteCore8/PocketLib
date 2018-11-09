using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PocketLib
{
    /// <summary>
    /// Предоставляет методы для взаимодействия с файловой системой.
    /// </summary>
    public static class FileSystem
    {
        /// <summary>
        /// Возвращает аблолютные пути всех файлов в директории. В том числе и из вложеных директорий.
        /// </summary>
        /// <param name="PathToDirectory">Путь к директории.</param>
        /// <returns>Аблолютные пути всех файлов в даной директории.</returns>
        public static IEnumerable<string> GetAllFileNamesFromDir(string PathToDirectory)
        {
            List<string> files = new List<string>();

            files.AddRange(Directory.GetFiles(PathToDirectory));

            string[] subDirs = Directory.GetDirectories(PathToDirectory);

            for (int i = 0; i < subDirs.Length; i++)
                files.AddRange(GetAllFileNamesFromDir(subDirs[i]));

            return files;
        }

        /// <summary>
        /// Возвращает аблолютные пути всех файлов в директории. В том числе и из вложеных директорий.
        /// </summary>
        /// <param name="Directory">Экземпляр директории.</param>
        /// <returns>Аблолютные пути всех файлов в даной директории.</returns>
        public static IEnumerable<string> GetAllFilePath(this DirectoryInfo Directory)
        {
            List<string> files = new List<string>();

            files.AddRange(System.IO.Directory.GetFiles(Directory.FullName));

            string[] subDirs = System.IO.Directory.GetDirectories(Directory.FullName);

            for (int i = 0; i < subDirs.Length; i++)
                files.AddRange(GetAllFileNamesFromDir(subDirs[i]));

            return files;
        }

        /// <summary>
        /// Возвращяет все файлы в директории. В том числе и из вложеных директорий.
        /// </summary>
        /// <param name="PathToDirectory">Путь к директории.</param>
        /// <returns>Все файлы в директории</returns>
        public static IEnumerable<FileInfo> GetAllFilesFromDir(string PathToDirectory)
        {
            string[] fileNames = GetAllFileNamesFromDir(PathToDirectory).ToArray();

            FileInfo[] files = new FileInfo[fileNames.Length];

            for (int i = 0; i < fileNames.Length; i++)
                files[i] = new FileInfo(fileNames[i]);

            return files;
        }

        /// <summary>
        /// Возвращяет все файлы в директории. В том числе и из вложеных директорий.
        /// </summary>
        /// <param name="Directory">Экземпляр директории.</param>
        /// <returns>Все файлы в директории</returns>
        public static IEnumerable<FileInfo> GetAllFiles(this DirectoryInfo Directory)
        {
            string[] fileNames = GetAllFileNamesFromDir(Directory.FullName).ToArray();

            FileInfo[] files = new FileInfo[fileNames.Length];

            for (int i = 0; i < fileNames.Length; i++)
                files[i] = new FileInfo(fileNames[i]);

            return files;
        }
    }
}
