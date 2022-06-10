using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Services;

namespace Infrastructure.Commands.ManageDrawers.EditDrawersCommands
{
    public class AddFilesCommand : CommandBase
    {
        private readonly IDrawerRepository _drawerRepository;
        private readonly ObservableCollection<DrawerFile> _drawerFiles;

        public AddFilesCommand(IDrawerRepository drawerRepository,ObservableCollection<DrawerFile> drawerFiles)
        {
            _drawerRepository = drawerRepository;
            _drawerFiles = drawerFiles;
        }

        public override void Execute(object? parameter)
        {
            SelectFiles();
            UpdateDrawerFiles(parameter as Drawer);
        }

        private void UpdateDrawerFiles(Drawer selectedDrawer)
        {
            var drawer = _drawerRepository.GetDrawerById(selectedDrawer.Id);
            drawer.FileList = _drawerFiles.ToList();
            _drawerRepository.UpdateDrawer(drawer);
        }

        private void SelectFiles()
        {
            FileService service = new FileService();
            service.OpenFileDialog("C://");
            var files = service.GetSelectedFiles();
            foreach (var drawerFile in files)
            {
                _drawerFiles.Add(drawerFile);
            }
        }
    }
}