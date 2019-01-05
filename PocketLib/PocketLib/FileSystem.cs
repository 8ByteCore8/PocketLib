//C#
//© Кушнір Б.T. , 2018
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
        #region Public Methods

        /// <summary>
        /// Возвращает аблолютные пути всех файлов в директории. В том числе и из вложеных директорий.
        /// </summary>
        /// <param name="pathToDirectory">Путь к директории.</param>
        /// <returns>Аблолютные пути всех файлов в даной директории.</returns>
        public static IEnumerable<string> GetAllFileNamesFromDir(string pathToDirectory)
        {
            List<string> files = new List<string>();

            files.AddRange(Directory.GetFiles(pathToDirectory));

            string[] subDirs = Directory.GetDirectories(pathToDirectory);

            for (int i = 0; i < subDirs.Length; i++)
                files.AddRange(GetAllFileNamesFromDir(subDirs[i]));

            return files;
        }

        /// <summary>
        /// Возвращает аблолютные пути всех файлов в директории. В том числе и из вложеных директорий.
        /// </summary>
        /// <param name="directory">Экземпляр директории.</param>
        /// <returns>Аблолютные пути всех файлов в даной директории.</returns>
        public static IEnumerable<string> GetAllFilePath(this DirectoryInfo directory)
        {
            List<string> files = new List<string>();

            files.AddRange(System.IO.Directory.GetFiles(directory.FullName));

            string[] subDirs = System.IO.Directory.GetDirectories(directory.FullName);

            for (int i = 0; i < subDirs.Length; i++)
                files.AddRange(GetAllFileNamesFromDir(subDirs[i]));

            return files;
        }

        /// <summary>
        /// Возвращяет все файлы в директории. В том числе и из вложеных директорий.
        /// </summary>
        /// <param name="directory">Экземпляр директории.</param>
        /// <returns>Все файлы в директории</returns>
        public static IEnumerable<FileInfo> GetAllFiles(this DirectoryInfo directory)
        {
            string[] fileNames = GetAllFileNamesFromDir(directory.FullName).ToArray();

            FileInfo[] files = new FileInfo[fileNames.Length];

            for (int i = 0; i < fileNames.Length; i++)
                files[i] = new FileInfo(fileNames[i]);

            return files;
        }

        /// <summary>
        /// Возвращяет все файлы в директории. В том числе и из вложеных директорий.
        /// </summary>
        /// <param name="pathToDirectory">Путь к директории.</param>
        /// <returns>Все файлы в директории</returns>
        public static IEnumerable<FileInfo> GetAllFilesFromDir(string pathToDirectory)
        {
            string[] fileNames = GetAllFileNamesFromDir(pathToDirectory).ToArray();

            FileInfo[] files = new FileInfo[fileNames.Length];

            for (int i = 0; i < fileNames.Length; i++)
                files[i] = new FileInfo(fileNames[i]);

            return files;
        }

        #endregion Public Methods
    }
}