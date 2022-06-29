using System.Collections.Generic;
using Core.Entities.Entities;

namespace Core.Application.Interfaces
{
    public interface IFileService
    {
        void OpenFileDialog(string defaultPath);
        IList<DrawerFile> GetSelectedFiles();
    }
}