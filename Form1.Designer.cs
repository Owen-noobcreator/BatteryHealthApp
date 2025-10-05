namespace BatteryHealthApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private System.Windows.Forms.Label lblPowerStatus;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblDesign;
        private System.Windows.Forms.ProgressBar batteryBar;
        private System.Windows.Forms.Button btnRefresh;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblPowerStatus = new System.Windows.Forms.Label();
            this.lblCharge = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblDesign = new System.Windows.Forms.Label();
            this.batteryBar = new System.Windows.Forms.ProgressBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lblPowerStatus
            // 
            this.lblPowerStatus.AutoSize = true;
            this.lblPowerStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPowerStatus.Location = new System.Drawing.Point(30, 30);
            this.lblPowerStatus.Name = "lblPowerStatus";
            this.lblPowerStatus.Size = new System.Drawing.Size(130, 23);
            this.lblPowerStatus.Text = "Power Source: -";

            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCharge.Location = new System.Drawing.Point(30, 70);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(123, 23);
            this.lblCharge.Text = "Charge Level: -";

            // 
            // batteryBar
            // 
            this.batteryBar.Location = new System.Drawing.Point(30, 100);
            this.batteryBar.Name = "batteryBar";
            this.batteryBar.Size = new System.Drawing.Size(620, 25);
            this.batteryBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.batteryBar.Maximum = 100;
            this.batteryBar.Value = 0;

            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHealth.Location = new System.Drawing.Point(30, 140);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(139, 23);
            this.lblHealth.Text = "Battery Health: -";

            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCapacity.Location = new System.Drawing.Point(30, 180);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(154, 23);
            this.lblCapacity.Text = "Current Capacity: -";

            // 
            // lblDesign
            // 
            this.lblDesign.AutoSize = true;
            this.lblDesign.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDesign.Location = new System.Drawing.Point(30, 220);
            this.lblDesign.Name = "lblDesign";
            this.lblDesign.Size = new System.Drawing.Size(152, 23);
            this.lblDesign.Text = "Design Capacity: -";

            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(250, 280);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 40);
            this.btnRefresh.Text = "Refresh Battery Info";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 370);
            this.Controls.Add(this.lblPowerStatus);
            this.Controls.Add(this.lblCharge);
            this.Controls.Add(this.batteryBar);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblDesign);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battery Health Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
