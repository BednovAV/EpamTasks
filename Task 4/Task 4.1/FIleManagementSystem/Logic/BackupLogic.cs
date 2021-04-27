using System;
using System.Collections.Generic;
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
        public string Path { get; }

        public BackupLogic(string path) => Path = path;

        public void BackupDirectory()
        {
            if (!Directory.Exists(Path))
                throw new IncorrectPathException("Указанный путь не существует");

            var directory = new DirectoryInfo(Path);
            var serviceDirectory = new DirectoryInfo($@"{Path}\.fms");

            if (!serviceDirectory.Exists)
            {
                serviceDirectory.Create();
                serviceDirectory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            var files = new List<BackupFile>();

            foreach (var item in directory.GetFiles("*.txt", SearchOption.AllDirectories))
            {
                files.Add(new BackupFile 
                { 
                    Name = item.Name,
                    Content = File.ReadAllText(item.FullName),
                    Path = item.DirectoryName 
                });
            }

            var backupFilePath = $@"{serviceDirectory.FullName}\{DateTime.Now.ToString().Replace(':', '-')}.json";
            var backupFileContent = JsonConvert.SerializeObject(files);

            File.WriteAllText(backupFilePath, backupFileContent);
        }
    }
}
