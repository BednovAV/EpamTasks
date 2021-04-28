using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
