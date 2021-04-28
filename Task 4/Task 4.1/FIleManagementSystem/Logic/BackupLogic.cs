using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIleManagementSystem.Logic.Entities;
using FIleManagementSystem.Logic.Exceptions;
using Newtonsoft.Json;

namespace FIleManagementSystem.Logic
{
    public class BackupLogic
    {
        /*
         * вынести сервисдиректори в поле
         */

        public string Path { get => _directory.FullName; }

        private DirectoryInfo _directory;
        private DirectoryInfo _serviceDirectory;

        public BackupLogic(string path)
        {
            if (!Directory.Exists(path))
                throw new IncorrectPathException("Указанный путь не существует");

            _directory = new DirectoryInfo(path);
            _serviceDirectory = new DirectoryInfo($@"{path}\.fms");
        }

        public void BackupDirectory()
        {
            

            if (!_serviceDirectory.Exists)
            {
                _serviceDirectory.Create();
                _serviceDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

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
            _directory.Delete(true);
            var directoryDataJson = _serviceDirectory.GetFiles()
                                                     .FirstOrDefault(item => item.Name == dateTime.ToString()
                                                                                                  .Replace(':', '-'));
        }

        public IEnumerable<DateTime> GetCommitList() 
            => _serviceDirectory.GetFiles()
                                .Select(item => item.Name.Substring(0, 19)) // cut the date from the file name
                                .Select(item => DateTime.ParseExact(item, "dd.MM.yyyy HH-mm-ss", CultureInfo.InvariantCulture));
    }
}
