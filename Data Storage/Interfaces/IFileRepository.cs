using System.Collections.Generic;
using Core.Entities;

namespace DataStorage.Interfaces
{
    public interface IFileRepository
    {
        IEnumerable<File> GetFiles();
        File GetFileById(int fileId);
        void AddFile(File file);
        void DeleteFile(File file);
        void UpdateFile(File file);
        void Save();
    }
}