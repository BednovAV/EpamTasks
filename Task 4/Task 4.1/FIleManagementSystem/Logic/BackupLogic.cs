using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using FileManagementSystem.Interfaces;
using FileManagementSystem.Logic.Entities;
using FileManagementSystem.Logic.Exceptions;
using FileManagementSystem.Logic.Extension;
using Newtonsoft.Json;

namespace FileManagementSystem.Logic
{
    public class BackupLogic : IBackupLogic
    {
        private DirectoryInfo _directory;
        private DirectoryInfo _serviceDirectory;

        /// <summary>
        /// The path to the working directory
        /// </summary>
        public string DirectoryPath => _directory.FullName;

        public BackupLogic(string path)
        {
            if (!Directory.Exists(path))
                throw new IncorrectPathException("Указанный путь не существует");

            _directory = new DirectoryInfo(path);
            _serviceDirectory = new DirectoryInfo(Path.Combine(path, ".fms"));

            if (!_serviceDirectory.Exists)
            {
                _serviceDirectory.Create();
                _serviceDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

                BackupDirectory();
            }
        }

        /// <summary>
        /// The current directory is backed up
        /// </summary>
        public void BackupDirectory()
        {
            var files = new List<BackupFile>();

            foreach (var item in _directory.GetFiles("*.txt", SearchOption.AllDirectories))
            {
                files.Add(new BackupFile 
                { 
                    Name = item.Name,
                    Content = File.ReadAllText(item.FullName),
                    Path = item.DirectoryName 
                });
            }

            var dateTime = DateTime.Now.ToString("dd.MM.yyyy HH-mm-ss");

            var backupFilePath = Path.Combine(_serviceDirectory.FullName, $"{dateTime}.json");
            var backupFileContent = JsonConvert.SerializeObject(files);

            File.WriteAllText(backupFilePath, backupFileContent);
        }

        /// <summary>
        /// Rolls back the directory to the specified date
        /// </summary>
        public void RollbackFolder(DateTime dateTime)
        {
            var dateTimeString = dateTime.ToString("dd.MM.yyyy HH-mm-ss");

            var dataPath = Path.Combine(_serviceDirectory.FullName, $"{dateTimeString}.json");

            if (!File.Exists(dataPath))
                throw new MissingBackupException("Фиксации с заданным временем не найдено");
            
            var backupFiles 
                = JsonConvert.DeserializeObject<IEnumerable<BackupFile>>(File.ReadAllText(dataPath));

            _directory.RemoveFiles("*.txt");

            foreach (var item in backupFiles)
            {
                if (!Directory.Exists(item.Path))
                    Directory.CreateDirectory(item.Path);

                File.WriteAllText($@"{item.Path}\{item.Name}", item.Content);
            }
        }

        /// <summary>
        /// Returns a list of commits in the current directory
        /// </summary>
        public IEnumerable<DateTime> GetCommits()
            => _serviceDirectory?.GetFiles()
                                .Select(file => FileNameToDateTime(file.Name))
                                .OrderBy(date => date);

        private DateTime FileNameToDateTime(string fileName)
        {
            fileName = fileName.Substring(0, 19); // cut the date from the file name
            DateTime result = DateTime.ParseExact(fileName, "dd.MM.yyyy HH-mm-ss", CultureInfo.InvariantCulture);

            return result;
        }


    }
}
