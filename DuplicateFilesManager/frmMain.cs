using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateFilesManager
{
    public partial class frmMain : Form
    {
        #region Members
        private string UserFolderPath;
        private Dictionary<string, List<DuplicateFile>> DuplicateFiles;
        #endregion

        #region Methods
        public frmMain()
        {
            InitializeComponent();

            if (this.DuplicateFiles == null)
                this.DuplicateFiles = new Dictionary<string, List<DuplicateFile>>();
        }

        private void ShowTreeViewMessage(string message)
        {
            tvDuplicates.Nodes.Clear();
            TreeNode tnMessage = new TreeNode(message);
            tvDuplicates.CheckBoxes = false;
            tvDuplicates.Nodes.Add(tnMessage);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tvDuplicates.Nodes.Clear();
            UserFolderPath = txtFolderPath.Text;
            if (String.IsNullOrWhiteSpace(UserFolderPath))
            {
                MessageBox.Show("Please select folder first");
                return;
            }

            RefreshDuplicateFiles(UserFolderPath);

            if (this.DuplicateFiles.Count == 0)
            {
                //MessageBox.Show("No duplicate files found!");
                ShowTreeViewMessage("No duplicate files found!");
                return;
            }
            /*IEnumerable<KeyValuePair<string, List<DuplicateFile>>> dups = RefreshDuplicateFiles(UserFolderPath);
            List<string> duplicateHashCodesList = new List<string>();
            List<string> duplicateFilesList = new List<string>();
            duplicateHashCodesList.Add("----------------------------------------ALL-----------------------------------------");
            foreach (KeyValuePair<string, List<DuplicateFile>> kvp in dups)
            {
                duplicateHashCodesList.Add(kvp.Key);
                foreach (DuplicateFile dpFile in kvp.Value)
                    duplicateFilesList.Add(dpFile.filePath);
            }
            
            lstPotentialDuplicate.DataSource = duplicateHashCodesList;
            ((ListBox)(chklstFilesList)).DataSource = duplicateFilesList;
            */
            tvDuplicates.CheckBoxes = true;
            foreach (KeyValuePair<string, List<DuplicateFile>> kvp in this.DuplicateFiles)
            {
                if (kvp.Value.Count > 1)
                {
                    TreeNode[] tnChildren = new TreeNode[kvp.Value.Count];
                    for (int i = 0; i < kvp.Value.Count; i++)
                    {
                        DuplicateFile df = kvp.Value[i];
                        TreeNode tnChild = new TreeNode(df.filePath);
                        tnChild.ToolTipText = "Size(KB):" + Convert.ToString(df.fileSize / 1024);
                        tnChildren[i] = tnChild;
                    }
                    TreeNode tn = new TreeNode(kvp.Key, tnChildren);
                    tn.Expand();
                    tvDuplicates.Nodes.Add(tn);
                }
            }
        }



        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void RefreshDuplicateFiles(string folderPath)
        {
            string strErrMsg = "";
            Dictionary<string, List<DuplicateFile>> retDict = new Dictionary<string, List<DuplicateFile>>();
            try
            {
                string[] filePaths = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
                foreach (string filePath in filePaths)
                {
                    string hashCode = GetCheckSum(filePath);

                    DuplicateFile dpfl = new DuplicateFile(filePath, hashCode);
                    List<DuplicateFile> hsOut;
                    if (!retDict.TryGetValue(hashCode, out hsOut))
                        hsOut = new List<DuplicateFile>();
                    hsOut.Add(dpfl);
                    retDict[hashCode] = hsOut;
                }

                foreach (KeyValuePair<string, List<DuplicateFile>> kvp in retDict)
                {
                    if (kvp.Value.Count > 1)
                        this.DuplicateFiles[kvp.Key] = kvp.Value;
                }

                //return retDict.Where(kvp => kvp.Value.Count > 1);
                //return retDict;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
            }
            if (strErrMsg != "")
                ShowTreeViewMessage(strErrMsg);
        }

        private string GetCheckSum(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        #endregion

        private void tvDuplicates_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                //string dirPath = e.Node.Text;                
                string argument = "/select, \"" + e.Node.Text + "\"";

                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown error, please retry.");
            }
        }

        private void btnSelectDuplicates_Click(object sender, EventArgs e)
        {
            if (tvDuplicates.Nodes.Count == 0)
            {
                ShowTreeViewMessage("Nothing to select");
                return;
            }

            TreeNode firstNode = tvDuplicates.Nodes[0];

        }
    }
}
/* Future Enhancements:
 Delete folder if folder is empty = if hashcode is selected
 Move to parent if only file in the directory
     */