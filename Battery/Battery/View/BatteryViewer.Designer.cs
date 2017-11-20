namespace Battery
{
    partial class BatteryViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.batteryListBox = new System.Windows.Forms.ListBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.powerTimeoutTrackBar = new System.Windows.Forms.TrackBar();
            this.PowerTimeoutLabel = new System.Windows.Forms.Label();
            this.min1Label = new System.Windows.Forms.Label();
            this.min10Label = new System.Windows.Forms.Label();
            this.min30Label = new System.Windows.Forms.Label();
            this.min40Label = new System.Windows.Forms.Label();
            this.min20Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.powerTimeoutTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // batteryListBox
            // 
            this.batteryListBox.FormattingEnabled = true;
            this.batteryListBox.ItemHeight = 20;
            this.batteryListBox.Location = new System.Drawing.Point(10, 15);
            this.batteryListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.batteryListBox.Name = "batteryListBox";
            this.batteryListBox.Size = new System.Drawing.Size(427, 184);
            this.batteryListBox.TabIndex = 0;
            this.batteryListBox.SelectedIndexChanged += new System.EventHandler(this.BatteryListBoxSelectedIndexChanged);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(327, 346);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(112, 35);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // powerTimeoutTrackBar
            // 
            this.powerTimeoutTrackBar.Location = new System.Drawing.Point(10, 245);
            this.powerTimeoutTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.powerTimeoutTrackBar.Maximum = 40;
            this.powerTimeoutTrackBar.Name = "powerTimeoutTrackBar";
            this.powerTimeoutTrackBar.Size = new System.Drawing.Size(429, 69);
            this.powerTimeoutTrackBar.TabIndex = 2;
            this.powerTimeoutTrackBar.TickFrequency = 5;
            this.powerTimeoutTrackBar.Scroll += new System.EventHandler(this.PowerTimeoutTrackBarScroll);
            // 
            // PowerTimeoutLabel
            // 
            this.PowerTimeoutLabel.AutoSize = true;
            this.PowerTimeoutLabel.Location = new System.Drawing.Point(20, 215);
            this.PowerTimeoutLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PowerTimeoutLabel.Name = "PowerTimeoutLabel";
            this.PowerTimeoutLabel.Size = new System.Drawing.Size(138, 20);
            this.PowerTimeoutLabel.TabIndex = 3;
            this.PowerTimeoutLabel.Text = "Set power timeout";
            // 
            // min1Label
            // 
            this.min1Label.AutoSize = true;
            this.min1Label.Location = new System.Drawing.Point(6, 294);
            this.min1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.min1Label.Name = "min1Label";
            this.min1Label.Size = new System.Drawing.Size(47, 20);
            this.min1Label.TabIndex = 4;
            this.min1Label.Text = "1 min";
            // 
            // min10Label
            // 
            this.min10Label.AutoSize = true;
            this.min10Label.Location = new System.Drawing.Point(96, 294);
            this.min10Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.min10Label.Name = "min10Label";
            this.min10Label.Size = new System.Drawing.Size(56, 20);
            this.min10Label.TabIndex = 5;
            this.min10Label.Text = "10 min";
            // 
            // min30Label
            // 
            this.min30Label.AutoSize = true;
            this.min30Label.Location = new System.Drawing.Point(286, 294);
            this.min30Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.min30Label.Name = "min30Label";
            this.min30Label.Size = new System.Drawing.Size(56, 20);
            this.min30Label.TabIndex = 6;
            this.min30Label.Text = "min 30";
            // 
            // min40Label
            // 
            this.min40Label.AutoSize = true;
            this.min40Label.Location = new System.Drawing.Point(382, 294);
            this.min40Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.min40Label.Name = "min40Label";
            this.min40Label.Size = new System.Drawing.Size(56, 20);
            this.min40Label.TabIndex = 7;
            this.min40Label.Text = "min 40";
            // 
            // min20Label
            // 
            this.min20Label.AutoSize = true;
            this.min20Label.Location = new System.Drawing.Point(194, 294);
            this.min20Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.min20Label.Name = "min20Label";
            this.min20Label.Size = new System.Drawing.Size(56, 20);
            this.min20Label.TabIndex = 8;
            this.min20Label.Text = "20 min";
            // 
            // BatteryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 400);
            this.Controls.Add(this.min20Label);
            this.Controls.Add(this.min40Label);
            this.Controls.Add(this.min30Label);
            this.Controls.Add(this.min10Label);
            this.Controls.Add(this.min1Label);
            this.Controls.Add(this.PowerTimeoutLabel);
            this.Controls.Add(this.powerTimeoutTrackBar);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.batteryListBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BatteryViewer";
            this.Text = "BatteryViewer";
            this.Load += new System.EventHandler(this.BatteryViewerLoad);
            ((System.ComponentModel.ISupportInitialize)(this.powerTimeoutTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox batteryListBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TrackBar powerTimeoutTrackBar;
        private System.Windows.Forms.Label PowerTimeoutLabel;
        private System.Windows.Forms.Label min1Label;
        private System.Windows.Forms.Label min10Label;
        private System.Windows.Forms.Label min30Label;
        private System.Windows.Forms.Label min40Label;
        private System.Windows.Forms.Label min20Label;
    }
}

