using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InfoTecsIntro
{
    public class DirectoryCopy
    {
        public void RecursiveCopyDirectory(DirectoryInfo sourceDirectory, DirectoryInfo targetDirectory)
        {
            sourceDirectory.ThrowIfNull("sourceDirectory==null");
            targetDirectory.ThrowIfNull("targetDirectory==null");
            if (!sourceDirectory.Exists)
                throw new ArgumentException("source directory doesn't exists");

            if (!targetDirectory.Exists)
                CreateNonExistentDirectory(targetDirectory);

            CopyFilesInDirectory(sourceDirectory, targetDirectory);
            var childDirectories = GetAllChildDirectories(sourceDirectory);

            foreach (var directory in childDirectories)
            {
                CopyFilesInDirectory(directory, targetDirectory);
            }
        }

        private IEnumerable<DirectoryInfo> GetAllChildDirectories(DirectoryInfo sourceDirectory)
        {
            sourceDirectory.ThrowIfNull("sourceDirectory==null");

            IEnumerable<DirectoryInfo> directories = sourceDirectory.GetDirectories().ToArray();
            foreach (var directory in directories)
            {
                var childDirectories = GetAllChildDirectories(directory); ;
                directories = directories.Concat(childDirectories).ToArray();
            }
            return directories;
        }

        private void CopyFilesInDirectory(DirectoryInfo sourceDirectory, DirectoryInfo targetDirectory)
        {
            sourceDirectory.ThrowIfNull("sourceDirectory==null");
            targetDirectory.ThrowIfNull("targetDirectory==null");
            if (!sourceDirectory.Exists)
                throw new ArgumentException("source directory doesn't exists");
            
            var files = sourceDirectory.GetFiles();

            foreach (var file in files)
            {
                string tempPath = Path.Combine(targetDirectory.FullName, file.Name);
                file.CopyTo(tempPath, false);
            }
        }

        private void CreateNonExistentDirectory(DirectoryInfo targetDirectory)
        {
            targetDirectory.ThrowIfNull("targetDirectory==null");
            Directory.CreateDirectory(targetDirectory.FullName);
        }
    }

}