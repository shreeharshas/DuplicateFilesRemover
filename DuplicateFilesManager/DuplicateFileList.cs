using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFilesManager
{
    public class DuplicateFile
    {
        public string fileName;
        public string filePath;
        public string md5CheckSum;
        public long fileSize;
        private string hashCode;

        public DuplicateFile(string filePath, string hashCode)
        {
            this.filePath = filePath;
            this.hashCode = hashCode;
            this.fileName = Path.GetFileName(filePath);
            this.fileSize = new FileInfo(filePath).Length;
            this.md5CheckSum = hashCode;
        }
    }
}
