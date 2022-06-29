using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core.Application.Services;
using Core.Application.Stores;
using Core.Entities.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Core.Application.Commands.ManageDrawers.EditDrawersCommands
{
    public class AddFilesCommand : CommandBase
    {
        private readonly DrawerStore _drawerStore;

        public AddFilesCommand(DrawerStore drawerStore)
        {
            _drawerStore = drawerStore;
        }

        public override void Execute(object? parameter)
        {
            var fileList = SelectFiles();
            UpdateDrawerFiles(fileList);
        }

        private void UpdateDrawerFiles(List<DrawerFile> fileList)
        {
            var drawer = _drawerStore.GetSelectedDrawer();
            drawer.FileList.AddRange(fileList);
            drawer.FileList = drawer.FileList.GroupBy(file => file.Name).Select(file=>file.First()).ToList();
            _drawerStore.UpdateSelectedDrawer(drawer);
        }

        private List<DrawerFile> SelectFiles()
        {
            FileService service = new FileService();
            service.OpenFileDialog("C://");
            return service.GetSelectedFiles().ToList();
        }
    }
}