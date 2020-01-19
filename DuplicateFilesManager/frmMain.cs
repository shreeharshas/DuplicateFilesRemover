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
            this.DuplicateFiles.Clear();
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
                if (e.Node.Text.Contains(":"))
                {
                    //string dirPath = e.Node.Text;                
                    string argument = "/select, \"" + e.Node.Text + "\"";

                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
                else
                {
                    foreach (TreeNode tn in e.Node.Nodes)
                    {
                        tn.Checked = e.Node.Checked;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown error, please retry.");
            }
        }

        private bool IsTreeViewEmpty()
        {
            if (tvDuplicates.Nodes.Count == 0)
                return true;
            else if (tvDuplicates.Nodes.Count == 1)
            {
                return (tvDuplicates.Nodes[0].Nodes == null || tvDuplicates.Nodes[0].Nodes.Count == 0);
            }
            return false;
        }

        private void btnSelectDuplicates_Click(object sender, EventArgs e)
        {
            if (IsTreeViewEmpty())
            {
                ShowTreeViewMessage("Nothing to select");
                return;
            }

            TreeNode firstNode = tvDuplicates.Nodes[0];
            foreach (TreeNode tn in firstNode.Nodes)
                tn.Checked = true;
            firstNode.FirstNode.Checked = false;

            TreeNode nextNode = firstNode.NextNode;
            while (nextNode != null)
            {
                foreach (TreeNode tn in nextNode.Nodes)
                    tn.Checked = true;
                nextNode.FirstNode.Checked = false;
                nextNode = nextNode.NextNode;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Brought to you by Shree (sridhash@gmail.com). Visit https://www.shreeharsha.me for more!");
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (IsTreeViewEmpty())
            {
                ShowTreeViewMessage("Nothing to delete");
                return;
            }

            DialogResult messageBoxResult = MessageBox.Show("Are you sure you want to delete?",
                "Confirm removal", MessageBoxButtons.YesNo);
            if (messageBoxResult == DialogResult.Yes)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbErrorFiles = new StringBuilder();

                foreach (TreeNode tn in tvDuplicates.Nodes)
                {
                    foreach (TreeNode fileNode in tn.Nodes)
                    {
                        if (fileNode.Checked && fileNode.Text.Contains(":"))
                        {
                            try
                            {
                                File.Delete(fileNode.Text);
                            }
                            catch (Exception ex)
                            {
                                sbErrorFiles.AppendLine(ex.Message);
                            }
                        }
                    }
                }
                if (sbErrorFiles.Length > 0)
                {
                    MessageBox.Show("Some files could not be deleted, following is the list of error messages:" + "\n" + sbErrorFiles.ToString());
                }
                else
                {
                    ShowTreeViewMessage("Duplicates deleted, please click refresh to check again.");
                }
            }
        }

        private void tvDuplicates_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!e.Node.Text.Contains(":"))
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    tn.Checked = e.Node.Checked;
                }
            }
        }
    }
}
/*
 Notes:

    If node text contains a colon, it is assumed to be a file path starting as a drive letter e.g., C:, D:, etc.
*/

