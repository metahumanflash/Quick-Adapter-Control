namespace NetworkAdapterSwitcher
{
    partial class SettingsForm
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox adapterCheckedListBox1;
        private System.Windows.Forms.CheckedListBox adapterCheckedListBox2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openConfigDirectoryButton;

        private void InitializeComponent()
        {
            this.adapterCheckedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.adapterCheckedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.openConfigDirectoryButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // adapterCheckedListBox1
            // 
            this.adapterCheckedListBox1.FormattingEnabled = true;
            this.adapterCheckedListBox1.Location = new System.Drawing.Point(50, 50);
            this.adapterCheckedListBox1.Name = "adapterCheckedListBox1";
            this.adapterCheckedListBox1.Size = new System.Drawing.Size(300, 79);

            // 
            // adapterCheckedListBox2
            // 
            this.adapterCheckedListBox2.FormattingEnabled = true;
            this.adapterCheckedListBox2.Location = new System.Drawing.Point(50, 150);
            this.adapterCheckedListBox2.Name = "adapterCheckedListBox2";
            this.adapterCheckedListBox2.Size = new System.Drawing.Size(300, 79);

            //
            // saveButton
            //
            this.saveButton.Location = new System.Drawing.Point(50, 250);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            //
            // openConfigDirectoryButton
            //
            this.openConfigDirectoryButton.Location = new System.Drawing.Point(150, 250);
            this.openConfigDirectoryButton.Name = "openConfigDirectoryButton";
            this.openConfigDirectoryButton.Size = new System.Drawing.Size(200, 23);
            this.openConfigDirectoryButton.Text = "Open Config Directory";
            this.openConfigDirectoryButton.UseVisualStyleBackColor = true;
            this.openConfigDirectoryButton.Click += new System.EventHandler(this.openConfigDirectoryButton_Click);

            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.Text = "WiFi Adapters";

            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.Text = "Ethernet Adapters";

            //
            // SettingsForm
            //
            this.ClientSize = new System.Drawing.Size(380, 300);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.openConfigDirectoryButton);
            this.Controls.Add(this.adapterCheckedListBox2);
            this.Controls.Add(this.adapterCheckedListBox1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
