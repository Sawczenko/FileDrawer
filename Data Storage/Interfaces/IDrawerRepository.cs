using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace DataStorage.Interfaces
{
    public interface IDrawerRepository
    {
        Task<List<Drawer>> GetDrawers();
        Drawer GetDrawerById(int drawerId);
        Task AddDrawer(Drawer drawer);
        void DeleteDrawer(Drawer drawer);
        void UpdateDrawer(Drawer drawer);
    }
}