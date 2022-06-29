using System.Collections.Generic;
using Core.Entities.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IFileRepository
    {
        IEnumerable<DrawerFile> GetFiles();
        DrawerFile GetFileById(int fileId);
        void AddFile(DrawerFile file);
        void DeleteFile(DrawerFile file);
        void UpdateFile(DrawerFile file);
        void Save();
    }
}