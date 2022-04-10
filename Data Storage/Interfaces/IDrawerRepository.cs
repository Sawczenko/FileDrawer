using System.Collections;
using System.Collections.Generic;
using Core.Entities;

namespace DataStorage.Interfaces
{
    public interface IDrawerRepository
    {
        IEnumerable<Drawer> GetDrawers();
        Drawer GetDrawerById(int drawerId);
        void AddDrawer(Drawer drawer);
        void DeleteDrawer(Drawer drawer);
        void UpdateDrawer(Drawer drawer);
        void Save();
    }
}