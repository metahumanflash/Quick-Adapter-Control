using System;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace NetworkAdapterSwitcher
{
    public partial class Form1 : Form
    {
        private List<string> wifiAdapterDescriptions = new List<string>();
        private List<string> ethernetAdapterDescriptions = new List<string>();

        private readonly string configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NetworkAdapterSwitcher", "adapterConfig.txt");
        private readonly string logFilePath;

        public Form1()
        {
            InitializeComponent();
            EnsureConfigDirectoryExists();
            logFilePath = Path.Combine(Path.GetDirectoryName(configFilePath), "log.txt");
            LoadConfiguration();
            UpdateButtonStates();
        }

        private void EnsureConfigDirectoryExists()
        {
            var configDirectory = Path.GetDirectoryName(configFilePath);
            if (!Directory.Exists(configDirectory))
            {
                Directory.CreateDirectory(configDirectory);
            }
        }

        private void LoadConfiguration()
        {
            if (File.Exists(configFilePath))
            {
                var lines = File.ReadAllLines(configFilePath);
                int divIdx = Array.IndexOf(lines, "---");
                if (divIdx > -1)
                {
                    wifiAdapterDescriptions = lines.Take(divIdx).ToList();
                    ethernetAdapterDescriptions = lines.Skip(divIdx + 1).ToList();
                }
            }
        }

        private void SaveConfiguration()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(configFilePath));
            var lines = wifiAdapterDescriptions.Concat(new[] { "---" }).Concat(ethernetAdapterDescriptions);
            File.WriteAllLines(configFilePath, lines);
        }

        private void UpdateButtonStates()
        {
            bool anyDisabled = GetAllAdaptersWMI().Cast<ManagementObject>()
                .Any(a => a["NetEnabled"] != null && !(bool)a["NetEnabled"]);
            enableAllButton.Enabled = anyDisabled;
        }

        private async void EnableAdapters(IEnumerable<string> adapterDescriptions)
        {
            ShowProgressBar();
            await Task.Run(() =>
            {
                foreach (var description in adapterDescriptions)
                {
                    EnableAdapter(description);
                }
            });
            ShowCompletedProgress();
            UpdateButtonStates();
        }

        private async void DisableAdapters(IEnumerable<string> adapterDescriptions)
        {
            ShowProgressBar();
            await Task.Run(() =>
            {
                foreach (var description in adapterDescriptions)
                {
                    DisableAdapter(description);
                }
            });
            ShowCompletedProgress();
            UpdateButtonStates();
        }

        private void EnableAdapter(string adapterDescription)
        {
            var query = new ManagementObjectSearcher($"SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID IS NOT NULL AND Description='{adapterDescription.Replace("'", "''")}'");

            foreach (ManagementObject mo in query.Get())
            {
                try
                {
                    mo.InvokeMethod("Enable", null);
                    LogSuccess($"Successfully enabled: {adapterDescription}");
                }
                catch (Exception ex)
                {
                    LogError($"Failed to enable {adapterDescription}: {ex.Message}");
                }
            }
        }

        private void DisableAdapter(string adapterDescription)
        {
            var query = new ManagementObjectSearcher($"SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID IS NOT NULL AND Description='{adapterDescription.Replace("'", "''")}'");

            foreach (ManagementObject mo in query.Get())
            {
                try
                {
                    mo.InvokeMethod("Disable", null);
                    LogSuccess($"Successfully disabled: {adapterDescription}");
                }
                catch (Exception ex)
                {
                    LogError($"Failed to disable {adapterDescription}: {ex.Message}");
                }
            }
        }

        private void enableWifiButton_Click(object sender, EventArgs e)
        {
            LogInformation("Enabling WiFi adapters and disabling Ethernet adapters...");
            DisableAdapters(ethernetAdapterDescriptions);
            EnableAdapters(wifiAdapterDescriptions);
        }

        private void enableEthernetButton_Click(object sender, EventArgs e)
        {
            LogInformation("Enabling Ethernet adapters and disabling WiFi adapters...");
            DisableAdapters(wifiAdapterDescriptions);
            EnableAdapters(ethernetAdapterDescriptions);
        }

        private void enableAllButton_Click(object sender, EventArgs e)
        {
            LogInformation("Enabling all disabled network adapters...");
            var disabledAdapters = GetAllAdaptersWMI().Cast<ManagementObject>()
                .Where(a => a["NetEnabled"] != null && !(bool)a["NetEnabled"])
                .Select(a => a["Description"].ToString());

            EnableAdapters(disabledAdapters);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm(wifiAdapterDescriptions, ethernetAdapterDescriptions, Path.GetDirectoryName(configFilePath)))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    wifiAdapterDescriptions = settingsForm.SelectedWifiAdapters;
                    ethernetAdapterDescriptions = settingsForm.SelectedEthernetAdapters;
                    SaveConfiguration();
                    UpdateButtonStates();
                }
            }
        }

        private ManagementObjectCollection GetAllAdaptersWMI()
        {
            var query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID IS NOT NULL");
            return query.Get();
        }

        private void ShowProgressBar()
        {
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = true;
            EnableControls(false);
        }

        private void ShowCompletedProgress()
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 100;
            EnableControls(true);

            Task.Delay(1000).ContinueWith(_ => HideProgressBar(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void HideProgressBar()
        {
            progressBar.Visible = false;
        }

        private void EnableControls(bool enable)
        {
            enableWifiButton.Enabled = enable;
            enableEthernetButton.Enabled = enable;
            enableAllButton.Enabled = enable;
            settingsButton.Enabled = enable;
        }

        // Logging functions
        private void LogSuccess(string message)
        {
            AppendLog(message, Color.Green);
        }

        private void LogError(string message)
        {
            AppendLog(message, Color.Red);
        }

        private void LogInformation(string message)
        {
            AppendLog(message, Color.Blue);
        }

        private void AppendLog(string message, Color color)
        {
            debugTextBox.Invoke(new Action(() =>
            {
                debugTextBox.SelectionStart = debugTextBox.TextLength;
                debugTextBox.SelectionLength = 0;

                debugTextBox.SelectionColor = color;
                debugTextBox.AppendText(message + Environment.NewLine);
                debugTextBox.SelectionColor = debugTextBox.ForeColor;

                File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }));
        }
    }
}
