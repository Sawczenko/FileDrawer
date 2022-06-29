using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Core.Application.Stores
{
    public class DrawerStore
    {
        private readonly IDrawerRepository _drawerRepository;
        private readonly List<Drawer> _drawers;
        private readonly Lazy<Task> _initializeLazy;

        public event Action<Drawer> DrawerSelected;
        public event Action<Drawer> DrawerAdded;
        public event Action<Drawer> DrawerChanged; 


        private Drawer _drawer { get; set; }

        public DrawerStore(IDrawerRepository drawerRepository)
        {
            _drawerRepository = drawerRepository;
            _drawers = new List<Drawer>();
            _initializeLazy = new Lazy<Task>(Initialize());
        }

        public void SetSelectedDrawer(Drawer drawer)
        {
            _drawer = drawer;
            DrawerSelected?.Invoke(drawer);
        }

        public Drawer GetSelectedDrawer()
        {
            return _drawer;
        }

        public IEnumerable<Drawer> GetDrawers()
        {
            return _drawers;
        }

        public async Task LoadDrawers()
        {
            await _initializeLazy.Value;
        }

        public void UpdateSelectedDrawer(Drawer drawer)
        {
            _drawerRepository.UpdateDrawer(drawer);
            OnDrawerChanged(drawer);
        }

        public async Task AddDrawer(Drawer drawer)
        {
            await _drawerRepository.AddDrawer(drawer);
            _drawers.Add(drawer);
            OnDrawerAdded(drawer);
        }

        private async Task Initialize()
        {
            IEnumerable<Drawer> drawers = await _drawerRepository.GetDrawers();
            _drawers.Clear();
            _drawers.AddRange(drawers);
        }

        private void OnDrawerAdded(Drawer drawer)
        {
            DrawerAdded?.Invoke(drawer);
        }

        private void OnDrawerChanged(Drawer drawer)
        {
            DrawerChanged?.Invoke(drawer);
        }
    }
}