using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using DataStorage.Interfaces;

namespace DataStorage.Repositories
{
    public class DrawerRepository : IDrawerRepository
    {
        private readonly FileDrawerDbContext _fileDrawerDbContext;

        public DrawerRepository(FileDrawerDbContext fileDrawerDbContext)
        {
            _fileDrawerDbContext = fileDrawerDbContext;
        }

        public IEnumerable<Drawer> GetDrawers()
        {
            return _fileDrawerDbContext.Drawers.AsEnumerable();
        }

        public Drawer GetDrawerById(int drawerId)
        {
            return _fileDrawerDbContext.Drawers.FirstOrDefault(d => d.Id == drawerId);
        }

        public void AddDrawer(Drawer drawer)
        {
            _fileDrawerDbContext.Drawers.Add(drawer);
            Save();
        }

        public void DeleteDrawer(Drawer drawer)
        {
            _fileDrawerDbContext.Drawers.Remove(drawer);
            Save();
        }

        public void UpdateDrawer(Drawer drawer)
        {
            _fileDrawerDbContext.Drawers.Update(drawer);
            Save();
        }

        public void Save()
        {
            _fileDrawerDbContext.SaveChanges();
        }
    }
}