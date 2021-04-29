using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using FIleManagementSystem.Interfaces;
using FIleManagementSystem.Logic.Entities;
using FIleManagementSystem.Logic.Exceptions;
using FIleManagementSystem.Logic.Extension;
using Newtonsoft.Json;

namespace FIleManagementSystem.Logic
{
    public class BackupLogic : IBackupLogic
    {
        private DirectoryInfo _directory;
        private DirectoryInfo _serviceDirectory;

        /// <summary>
        /// The path to the working directory
        /// </summary>
        public string Path 
        { 
            
            get => _directory?.FullName;

            set
            {
                if (!Directory.Exists(value))
                    throw new IncorrectPathException("Указанный путь не существует");

                _directory = new DirectoryInfo(value);
                _serviceDirectory = new DirectoryInfo($@"{value}\.fms");

                if (!_serviceDirectory.Exists)
                {
                    _serviceDirectory.Create();
                    _serviceDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

                    BackupDirectory();
                }
            }
        }

        public BackupLogic() => Path = Directory.GetCurrentDirectory();

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

            var backupFilePath = $@"{_serviceDirectory.FullName}\{DateTime.Now.ToString().Replace(':', '-')}.json";
            var backupFileContent = JsonConvert.SerializeObject(files);

            File.WriteAllText(backupFilePath, backupFileContent);
        }

        /// <summary>
        /// Rolls back the directory to the specified date
        /// </summary>
        public void RollbackFolder(DateTime dateTime)
        {
            var dataPath = $@"{_serviceDirectory.FullName}\{dateTime.ToString().Replace(':', '-')}.json";

            if (!File.Exists(dataPath))
                throw new MissingBackupException("Фиксации с заданным временем не найдено");
            
            var backupFiles 
                = JsonConvert.DeserializeObject<IEnumerable<BackupFile>>(File.ReadAllText(dataPath));

            _directory.Clean(".fms");

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
        public IEnumerable<DateTime> GetCommitList()
            => _serviceDirectory.GetFiles()
                                .Select(item => FileNameToDateTime(item.Name));

        private DateTime FileNameToDateTime(string fileName)
        {
            fileName = fileName.Substring(0, 19); // cut the date from the file name
            DateTime result = DateTime.ParseExact(fileName, "dd.MM.yyyy HH-mm-ss", CultureInfo.InvariantCulture);

            return result;
        }


    }
}
