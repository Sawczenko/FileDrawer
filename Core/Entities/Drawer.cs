using System.Collections.Generic;

namespace Core.Entities
{
    public class Drawer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<File> FileList { get; set; }
        public string DrawerPath { get; set; }
    }
}