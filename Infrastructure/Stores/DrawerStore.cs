using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Core.Entities;
using DataStorage.Interfaces;

namespace Infrastructure.Stores
{
    public class DrawerStore
    {
        private readonly IDrawerRepository _drawerRepository;
        private readonly List<Drawer> _drawers;
        private readonly Lazy<Task> _initializeLazy;

        public event Action<Drawer> DrawerSelected;
        public event Action<Drawer> DrawerAdded;


        public Drawer Drawer { get; set; }
        public IEnumerable<Drawer> Drawers => _drawers;

        public DrawerStore(IDrawerRepository drawerRepository)
        {
            _drawerRepository = drawerRepository;
            _drawers = new List<Drawer>();
            _initializeLazy = new Lazy<Task>(Initialize());
        }

        public void SetSelectedDrawer(Drawer drawer)
        {
            Drawer = drawer;
            DrawerSelected?.Invoke(drawer);
        }

        public async Task LoadDrawers()
        {
            await _initializeLazy.Value;
        }

        private async Task Initialize()
        {
            IEnumerable<Drawer> drawers = await _drawerRepository.GetDrawers();
            _drawers.Clear();
            _drawers.AddRange(drawers);
        }

        public async Task AddDrawer(Drawer drawer)
        {
            await _drawerRepository.AddDrawer(drawer);
            _drawers.Add(drawer);
            OnDrawerAdded(drawer);
        }

        private void OnDrawerAdded(Drawer drawer)
        {
            DrawerAdded?.Invoke(drawer);
        }
    }
}