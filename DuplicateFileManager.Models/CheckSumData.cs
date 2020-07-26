using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFileManager.Models
{
    public class CheckSumData
    {
        private const string BlankMD5CheckSum = "d41d8cd98f00b204e9800998ecf8427e";
        private const string EmptyHash = "Empty";

        private KeyValuePair<string, string> FileCheckSum;

        public void Set(string Path, string CheckSum) {
            if (BlankMD5CheckSum.Equals(CheckSum))
            {
                CheckSum = EmptyHash;
            }
            this.FileCheckSum = new KeyValuePair<string, string>(Path, CheckSum);
        }

        public KeyValuePair<string, string> GetCheckSumInfo() {
            return this.FileCheckSum;
        }
    }
}
