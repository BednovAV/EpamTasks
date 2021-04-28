using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIleManagementSystem.Interfaces;
using FIleManagementSystem.Logic.Entities;
using FIleManagementSystem.Logic.Exceptions;
using FIleManagementSystem.Logic.Extension;
using Newtonsoft.Json;

namespace FIleManagementSystem.Logic
{
    public class BackupLogic : IBackupLogic
    {
        public string Path { get => _directory.FullName; }

        private DirectoryInfo _directory;
        private DirectoryInfo _serviceDirectory;

        public BackupLogic(string path)
        {
            if (!Directory.Exists(path))
                throw new IncorrectPathException("Указанный путь не существует");

            _directory = new DirectoryInfo(path);
            _serviceDirectory = new DirectoryInfo($@"{path}\.fms");

            if (!_serviceDirectory.Exists)
            {
                _serviceDirectory.Create();
                _serviceDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                BackupDirectory();
            }
        }

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

        public void RollbackFolder(DateTime dateTime)
        {
            _directory.Clean(".fms");

            // !!! ПЕРЕДЕЛАТЬ
            var directoryDataJson = _serviceDirectory.GetFiles()
                                                     .Select(item => item.Name.Substring(0, 19)) // cut the date from the file name
                                                     .FirstOrDefault(item => item == dateTime.ToString()
                                                                                             .Replace(':', '-'));
            
            // !!! ПЕРЕДЕЛАТЬ
            var backupFiles = JsonConvert.DeserializeObject<IEnumerable<BackupFile>>(File.ReadAllText(_serviceDirectory.FullName + @"\" + directoryDataJson + ".json"));

            foreach (var item in backupFiles)
            {
                if (!Directory.Exists(item.Path))
                    Directory.CreateDirectory(item.Path);

                File.WriteAllText($@"{item.Path}\{item.Name}", item.Content);
            }
        }

        public IEnumerable<DateTime> GetCommitList() 
            => _serviceDirectory.GetFiles()
                                .Select(item => item.Name.Substring(0, 19)) // cut the date from the file name
                                .Select(item => DateTime.ParseExact(item, "dd.MM.yyyy HH-mm-ss", CultureInfo.InvariantCulture));


    }
}
