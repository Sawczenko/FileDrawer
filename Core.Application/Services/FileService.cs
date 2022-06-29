using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Core.Application.Interfaces;
using Core.Entities.Entities;

namespace Core.Application.Services
{
    public class FileService : IFileService
    {

        private readonly OpenFileDialog _fileDialog;

        public FileService()
        {
           _fileDialog = new OpenFileDialog();
           _fileDialog.Multiselect = true;
        }

        public void OpenFileDialog(string defaultPath)
        {
            _fileDialog.ShowDialog();
        }

        public IList<DrawerFile> GetSelectedFiles()
        {
            var fileNames = _fileDialog.FileNames;
            List<DrawerFile> files = new List<DrawerFile>();
            foreach (var fileName in fileNames)
            {
                files.Add(new DrawerFile
                {
                    Name = Path.GetFileName(fileName),
                    Path = fileName,
                    Size = fileName.Length.ToString()
                });
            }
            return files;
        }
    }
}