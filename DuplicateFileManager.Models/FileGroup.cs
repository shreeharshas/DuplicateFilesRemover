using DuplicateFilesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFilesManager.Models
{
    public class FileGroup
    {
        public List<DuplicateFile> GroupedFiles;
        public long Count;

        public FileGroup() {
            this.GroupedFiles = new List<DuplicateFile>();
            this.Count = 0;
        }
        
        public void Add(DuplicateFile dpFile) {
            this.GroupedFiles.Add(dpFile);            
            this.Count++;
        }
    }
}
