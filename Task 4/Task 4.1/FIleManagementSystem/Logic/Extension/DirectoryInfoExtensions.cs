using System;
using System.IO;
using System.Linq;

namespace FIleManagementSystem.Logic.Extension
{
    public static class DirectoryInfoExtensions
    {
        public static void Clean(this DirectoryInfo directory, params string[] ignoreObjects)
        {
            foreach (var item in directory.GetDirectories())
            {
                if (!ignoreObjects.Contains(item.Name))
                {
                    item.Delete(true);
                }
            }

            foreach (var item in directory.GetFiles())
            {
                if (!ignoreObjects.Contains(item.Name))
                {
                    item.Delete();
                }
            }
        }

        public static void RemoveFiles(this DirectoryInfo directory, string searchPattern)
        {
            foreach (var item in directory.GetFiles(searchPattern, SearchOption.AllDirectories))
            {
                item.Delete();
            }
        }
    }
}
