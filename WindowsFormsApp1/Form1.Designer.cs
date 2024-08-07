namespace NetworkAdapterSwitcher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button enableWifiButton;
        private System.Windows.Forms.Button enableEthernetButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button enableAllButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox debugTextBox; // Use RichTextBox instead

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.enableWifiButton = new System.Windows.Forms.Button();
            this.enableEthernetButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.enableAllButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.debugTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // enableWifiButton
            // 
            this.enableWifiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableWifiButton.Location = new System.Drawing.Point(65, 47);
            this.enableWifiButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enableWifiButton.Name = "enableWifiButton";
            this.enableWifiButton.Size = new System.Drawing.Size(300, 77);
            this.enableWifiButton.TabIndex = 0;
            this.enableWifiButton.Text = "Enable WiFi Only";
            this.enableWifiButton.UseVisualStyleBackColor = true;
            this.enableWifiButton.Click += new System.EventHandler(this.enableWifiButton_Click);
            // 
            // enableEthernetButton
            // 
            this.enableEthernetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableEthernetButton.Location = new System.Drawing.Point(65, 163);
            this.enableEthernetButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enableEthernetButton.Name = "enableEthernetButton";
            this.enableEthernetButton.Size = new System.Drawing.Size(300, 77);
            this.enableEthernetButton.TabIndex = 1;
            this.enableEthernetButton.Text = "Enable Ethernet Only";
            this.enableEthernetButton.UseVisualStyleBackColor = true;
            this.enableEthernetButton.Click += new System.EventHandler(this.enableEthernetButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.Location = new System.Drawing.Point(570, 14);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(112, 35);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // enableAllButton
            // 
            this.enableAllButton.BackColor = System.Drawing.Color.Transparent;
            this.enableAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableAllButton.Location = new System.Drawing.Point(570, 59);
            this.enableAllButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enableAllButton.Name = "enableAllButton";
            this.enableAllButton.Size = new System.Drawing.Size(112, 77);
            this.enableAllButton.TabIndex = 3;
            this.enableAllButton.Text = "Enable All Adapters";
            this.enableAllButton.UseVisualStyleBackColor = false;
            this.enableAllButton.Click += new System.EventHandler(this.enableAllButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Quick_Adapter_Control.Properties.Resources.WiFi;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(372, 163);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(82, 77);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Quick_Adapter_Control.Properties.Resources.Ethernet;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(372, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 77);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(50, 260);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(612, 28);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // debugTextBox
            // 
            this.debugTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.debugTextBox.Location = new System.Drawing.Point(50, 300);
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.debugTextBox.Size = new System.Drawing.Size(612, 150);
            this.debugTextBox.TabIndex = 7;
            this.debugTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::Quick_Adapter_Control.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(695, 500);
            this.Controls.Add(this.debugTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.enableAllButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.enableEthernetButton);
            this.Controls.Add(this.enableWifiButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Network Adapter Switcher";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
