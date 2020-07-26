using DuplicateFileManager.Models;
using DuplicateFilesManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DuplicateFilesManager.Core
{
    public class CoreLogic
    {
        private const string DefaultBlankMessage = "Directory empty or No duplicate files found";
        private FileMap DuplicateFilesMap;

        public CoreLogic()
        {
            this.DuplicateFilesMap = new FileMap();
        }

        public async Task<FileMap> GetDuplicateFilesMap(string folderPath, CancellationTokenSource cts)
        {
            FileMap retFileMap;
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(folderPath);

                FileInfo[] filePaths = await Task.Run(() => dInfo.GetFiles("*.*", SearchOption.AllDirectories));

                //List<FileInfoWrapped> filePaths = FilesReader.GetFiles(folderPath);

                if (filePaths.Length == 0)
                {
                    retFileMap = new FileMap();
                    retFileMap.ErrorMessage = DefaultBlankMessage;
                    return retFileMap;
                }

                Dictionary<string, FileInfo> dictFileInfo = new Dictionary<string, FileInfo>();

                //foreach (FileInfoWrapped fInfo in filePaths) {
                //    dictFileInfo[fInfo.Info.FullName] = fInfo.Info;
                //}
                
                foreach (FileInfo fInfo in filePaths) {
                    dictFileInfo[fInfo.FullName] = fInfo;
                }

                retFileMap = await GetCheckSumParallelAsync(dictFileInfo, cts);
                if (retFileMap.Count == 0)
                {
                    retFileMap.ErrorMessage = DefaultBlankMessage;                    
                }
            }
            catch (Exception ex)
            {
                retFileMap = new FileMap();
                retFileMap.ErrorMessage = ex.Message;
            }
            return retFileMap;
        }

        private async Task<FileMap> GetCheckSumParallelAsync(Dictionary<string, FileInfo> filePaths, CancellationTokenSource cts)
        {
            List<CheckSumData> retChkData = new List<CheckSumData>();
            List<Task<CheckSumData>> checkSumTasks = new List<Task<CheckSumData>>();//[filePaths.Values.Count];

            FileMap retMap = new FileMap();

            CancellationToken cancelToken = cts.Token;
            List<CheckSumData> results = new List<CheckSumData>();

            await Task.Run(
                async () =>
                {
                    foreach (FileInfo path in filePaths.Values)
                    {
                        if (cts.IsCancellationRequested){break;}

                        CheckSumData chData = new CheckSumData();
                        var filePath = path.FullName;
                        try
                        {
                            using (var md5 = MD5.Create())
                            {
                                using (var stream = File.OpenRead(filePath))
                                {
                                    string chkSum = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                                    chData.Set(filePath, chkSum);
                                    results.Add(chData);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            chData.Set(filePath, ex.Message);
                            results.Add(chData);
                        }
                    }
                }
            , cancelToken);

            foreach (CheckSumData item in results)
            {
                KeyValuePair<string, string> checkSumInfo = item.GetCheckSumInfo();
                FileInfo fInfo;
                if (filePaths.TryGetValue(checkSumInfo.Key, out fInfo))
                {
                    DuplicateFile dpfl = new DuplicateFile(fInfo.FullName, checkSumInfo.Value, fInfo.Length, fInfo.Name);
                    retMap.AddTolist(dpfl);
                }
            }
            retMap.RemoveSingleAndZeroGroups();
            return retMap;
        }
    }
}
