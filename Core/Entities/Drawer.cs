using System;
using System.Collections.Generic;

namespace Core.Entities.Entities
{
    public class Drawer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DrawerFile> FileList { get; set; }
        public string Path { get; set; }
        public int FileCount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}