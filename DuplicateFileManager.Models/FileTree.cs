using DuplicateFilesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFilesManager.Models
{
    public class FileMap
    {
        public Dictionary<string, FileGroup> InternalMap; //Hashcode to Filepath

        public string ErrorMessage;
        public long Count;

        public FileMap() {
            InternalMap = new Dictionary<string, FileGroup>();
            Count = InternalMap.Count;
            ErrorMessage = "";
        }

        public void AddTolist(DuplicateFile dupFile)
        {
            FileGroup dfList;
            if(!InternalMap.TryGetValue(dupFile.checkSum, out dfList))
            {
                dfList = new FileGroup();                
            }

            dfList.Add(dupFile);
            InternalMap[dupFile.checkSum] = dfList;
            Count = InternalMap.Count;
        }

        public void Clear()
        {
            InternalMap.Clear();
        }

        public void RemoveSingleAndZeroGroups() {
            List<string> keys = InternalMap.Keys.ToList();
            foreach (string key in keys)
            {
                FileGroup fg = InternalMap[key];
                if (fg.Count < 2)
                {
                    InternalMap.Remove(key);                    
                }
            }
            Count = InternalMap.Count;
        }
    }
}
