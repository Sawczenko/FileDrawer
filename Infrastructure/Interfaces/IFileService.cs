using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure.Interfaces
{
    public interface IFileService
    {
        void OpenFileDialog(string defaultPath);
        IList<DrawerFile> GetSelectedFiles();
    }
}