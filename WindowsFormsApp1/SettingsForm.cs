using System;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq; // Add this for LINQ extension methods

namespace NetworkAdapterSwitcher
{
    public partial class SettingsForm : Form
    {
        public List<string> SelectedWifiAdapters { get; private set; }
        public List<string> SelectedEthernetAdapters { get; private set; }
        private string configDirectory;

        public SettingsForm(List<string> currentWifiAdapters, List<string> currentEthernetAdapters, string configDirectory)
        {
            InitializeComponent();

            this.configDirectory = configDirectory;

            var query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID IS NOT NULL");

            foreach (ManagementObject mo in query.Get())
            {
                string description = mo["Description"].ToString();
                adapterCheckedListBox1.Items.Add(description, currentWifiAdapters.Contains(description));
                adapterCheckedListBox2.Items.Add(description, currentEthernetAdapters.Contains(description));
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Ensure using System.Linq is at the top of the file
            SelectedWifiAdapters = new List<string>(adapterCheckedListBox1.CheckedItems.Cast<string>());
            SelectedEthernetAdapters = new List<string>(adapterCheckedListBox2.CheckedItems.Cast<string>());
            DialogResult = DialogResult.OK;
        }

        private void openConfigDirectoryButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", configDirectory);
        }
    }
}
