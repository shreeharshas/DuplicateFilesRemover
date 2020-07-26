using DuplicateFileManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace DuplicateFilesManager.Core
{
    /* This class is a modified version of 
     * https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-iterate-file-directories-with-the-parallel-class
     * 
     * 
     * This class is currently unused, it needs to replace the GetAllFile call in Core
     */

    public class FilesReader
    {
        public static List<FileInfoWrapped> GetFiles(string FolderPath)
        {
            List<FileInfoWrapped> fInfoWrappedFiles = new List<FileInfoWrapped>();
            try
            {
                IterativeFolderTraversal(FolderPath, (f) =>
                {
                    FileInfoWrapped fInfoWrapped = new FileInfoWrapped();
                    try
                    {
                        FileInfo fInfo = new FileInfo(f);
                        fInfoWrapped.SetInfo(fInfo);
                        fInfoWrappedFiles.Add(fInfoWrapped);
                    }
                    catch (FileNotFoundException fnfex) { fInfoWrapped.ErrorMessage = fnfex.Message; }
                    catch (IOException ioex) { fInfoWrapped.ErrorMessage = ioex.Message; }
                    catch (UnauthorizedAccessException uaex) { fInfoWrapped.ErrorMessage = uaex.Message; }
                    catch (SecurityException scex) { fInfoWrapped.ErrorMessage = scex.Message; }
                });
                return fInfoWrappedFiles;
            }
            catch (Exception argex){throw argex;}
        }

        private static void IterativeFolderTraversal(string inputFolder, Action<string> action)
        {
            int fileCount = 0;
            int procCount = System.Environment.ProcessorCount;
            Stack<string> dirs = new Stack<string>();

            if (!Directory.Exists(inputFolder))
            {
                throw new ArgumentException();
            }
            dirs.Push(inputFolder);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs = { };
                string[] files = { };

                try{subDirs = Directory.GetDirectories(currentDir);}                
                catch{continue;}
                
                try
                {
                    if (files.Length < procCount)
                    {
                        foreach (var file in files)
                        {
                            action(file);
                            fileCount++;
                        }
                    }
                    else
                    {
                        Parallel.ForEach(files, () => 0, (file, loopState, localCount) => {
                                action(file);
                                return (int)++localCount;
                            }, (c) =>{Interlocked.Add(ref fileCount, c);
                        });
                    }
                }
                catch{}

                foreach (string str in subDirs)
                    dirs.Push(str);
            }
        }
    }
}