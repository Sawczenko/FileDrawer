using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DataStorage.Interfaces;

namespace DataStorage.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileDrawerDatabaseContext _fileDrawerDbContext;

        public FileRepository(FileDrawerDatabaseContext fileDrawerDbContext)
        {
            _fileDrawerDbContext = fileDrawerDbContext;
        }
        public IEnumerable<DrawerFile> GetFiles()
        {
            return _fileDrawerDbContext.Files.AsEnumerable();
        }

        public DrawerFile GetFileById(int fileId)
        {
            return _fileDrawerDbContext.Files.FirstOrDefault(f => f.Id == fileId);
        }

        public void AddFile(DrawerFile file)
        {
            _fileDrawerDbContext.Files.Add(file);
            Save();
        }

        public void DeleteFile(DrawerFile file)
        {
            _fileDrawerDbContext.Files.Remove(file);
            Save();
        }

        public void UpdateFile(DrawerFile file)
        {
            _fileDrawerDbContext.Files.Update(file);
            Save();
        }

        public void Save()
        {
            _fileDrawerDbContext.SaveChanges();
        }
    }
}