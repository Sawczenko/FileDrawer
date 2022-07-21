using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class DrawerRepository : IDrawerRepository
    {
        private readonly FileDrawerDatabaseContext _fileDrawerDbContext;

        public DrawerRepository(FileDrawerDatabaseContext fileDrawerDbContext)
        {
            _fileDrawerDbContext = fileDrawerDbContext;
        }

        public async Task<List<Drawer>> GetDrawers()
        {
            return await _fileDrawerDbContext.Drawers.Include(drawer => drawer.FileList).ToListAsync();
        }

        public Drawer GetDrawerById(int drawerId)
        {
            return _fileDrawerDbContext.Drawers.FirstOrDefault(d => d.Id == drawerId);
        }

        public async Task AddDrawer(Drawer drawer)
        {
            await _fileDrawerDbContext.Drawers.AddAsync(drawer);
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

        private void Save()
        {
            _fileDrawerDbContext.SaveChanges();
        }
    }
}