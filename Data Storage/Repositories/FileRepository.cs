using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DataStorage.Interfaces;

namespace DataStorage.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileDrawerDbContext _fileDrawerDbContext;

        public FileRepository(FileDrawerDbContext fileDrawerDbContext)
        {
            _fileDrawerDbContext = fileDrawerDbContext;
        }
        public IEnumerable<File> GetFiles()
        {
            return _fileDrawerDbContext.Files.AsEnumerable();
        }

        public File GetFileById(int fileId)
        {
            return _fileDrawerDbContext.Files.FirstOrDefault(f => f.Id == fileId);
        }

        public void AddFile(File file)
        {
            _fileDrawerDbContext.Files.Add(file);
            Save();
        }

        public void DeleteFile(File file)
        {
            _fileDrawerDbContext.Files.Remove(file);
            Save();
        }

        public void UpdateFile(File file)
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