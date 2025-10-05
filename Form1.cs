using System;
using System.Drawing;
using System.Windows.Forms;

namespace BatteryHealthApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshBatteryInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBatteryInfo();
        }

        private void RefreshBatteryInfo()
        {
            try
            {
                var (design, full, current, percent, health, status) = BatteryService.GetBatteryInfo();

                lblPowerStatus.Text = $"Power Source: {status}";
                lblCharge.Text = $"Charge Level: {percent:F0}%";
                lblCapacity.Text = $"Current Capacity: {current:F0} mWh / {full:F0} mWh";
                lblHealth.Text = $"Battery Health: {health:F2}%";
                lblDesign.Text = $"Design Capacity: {design:F0} mWh";

                batteryBar.Value = (int)Math.Min(100, percent);
                batteryBar.ForeColor = health switch
                {
                    > 85 => Color.Green,
                    > 65 => Color.Goldenrod,
                    _ => Color.Red
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ " + ex.Message, "Battery Health Monitor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
