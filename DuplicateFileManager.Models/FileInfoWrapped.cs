using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFileManager.Models
{
    public class FileInfoWrapped
    {
        public string ErrorMessage;
        public FileInfo Info;
        
        public FileInfoWrapped() { 
            this.ErrorMessage = "";
        }

        public void SetInfo(FileInfo fInfo)
        {
            this.Info = fInfo;
        }

        public FileInfoWrapped GetObject()
        {
            return this;
        }
    }
}
