using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuplicateFilesManager.Enums;

namespace DuplicateFilesManager
{
    public partial class frmMain : Form
    {
        private ProcessingStatus m_AppProcessingStatus;
        public ProcessingStatus AppProcessingStatus
        {
            get{return m_AppProcessingStatus;}
            set
            {
                m_AppProcessingStatus = value;
                InvokePStatusChange();
            }
        }

        private void InvokePStatusChange()
        {
            UpdateButtons();
        }

        public void UpdateButtons()
        {
            switch (AppProcessingStatus)
            {
                case ProcessingStatus.Idle:
                case ProcessingStatus.Complete:
                    btnRefresh.Visible = true;
                    btnStopScan.Visible = false;

                    btnStopScan.Enabled = true;
                    btnDeleteSelected.Enabled = true;
                    btnSelectDuplicates.Enabled = true;
                    btnRefresh.Enabled = true;
                    btnDeselectAll.Enabled = true;
                    break;

                case ProcessingStatus.Process:
                    btnRefresh.Visible = false;
                    btnStopScan.Visible = true;

                    btnStopScan.Enabled = true;
                    btnDeleteSelected.Enabled = false;
                    btnSelectDuplicates.Enabled = false;
                    btnRefresh.Enabled = false;
                    btnDeselectAll.Enabled = false;
                    break;

                case ProcessingStatus.Export:
                    btnStopScan.Enabled = false;
                    btnDeleteSelected.Enabled = false;
                    btnSelectDuplicates.Enabled = false;
                    btnRefresh.Enabled = false;
                    btnDeselectAll.Enabled = false;
                    break;
            }
        }
    }
}
