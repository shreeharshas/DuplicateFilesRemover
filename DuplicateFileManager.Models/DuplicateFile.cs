using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFilesManager.Models
{
    public class DuplicateFile
    {
        public string fileName;
        public string filePath;
        public string checkSum;
        public long fileSize;
        private string hashCode;

        public DuplicateFile(string fPath, string fHash, long fSize, string fName)
        {
            this.filePath = fPath;
            this.hashCode = fHash;
            this.fileName = fName;
            this.fileSize = fSize;
            this.checkSum = hashCode;
        }
    }
}
