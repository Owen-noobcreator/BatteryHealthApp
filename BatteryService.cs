using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace BatteryHealthApp
{
    public static class BatteryService
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }

        [DllImport("kernel32.dll")]
        public static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS sps);

        public static (double designCap, double fullCap, double currentCap, double currentPercent, double health, string powerStatus) GetBatteryInfo()
        {
            string downloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string logsFolder = Path.Combine(downloads, "Battery Logs");
            Directory.CreateDirectory(logsFolder);

            string htmlPath = Path.Combine(logsFolder, "battery-report.html");
            string textPath = Path.Combine(logsFolder, "battery-report.txt");
            string csvPath = Path.Combine(logsFolder, "battery_health_log.csv");

            // Run powercfg command
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C powercfg /batteryreport /output \"{htmlPath}\"";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();

            if (!File.Exists(htmlPath))
                throw new Exception("Battery report could not be generated.");

            string html = File.ReadAllText(htmlPath);
            string text = Regex.Replace(html, "<.*?>", string.Empty);
            File.WriteAllText(textPath, text);

            string textUpper = text.ToUpperInvariant();
            string designCap = ExtractValue(textUpper, "DESIGN CAPACITY", "MWH");
            string fullCap = ExtractValue(textUpper, "FULL CHARGE CAPACITY", "MWH");

            double designVal = ExtractNumber(designCap);
            double fullVal = ExtractNumber(fullCap);

            // Get system power status
            (double percent, string powerStatus) = GetBatteryStatus();

            double currentCap = (fullVal > 0 && percent > 0) ? (percent / 100.0) * fullVal : 0;
            double health = (designVal > 0 && fullVal > 0) ? (fullVal / designVal) * 100 : 0;

            LogToCsv(csvPath, designVal, fullVal, currentCap, percent, health, powerStatus);

            return (designVal, fullVal, currentCap, percent, health, powerStatus);
        }

        private static (double percent, string status) GetBatteryStatus()
        {
            if (GetSystemPowerStatus(out SYSTEM_POWER_STATUS sps))
            {
                double percent = sps.BatteryLifePercent;
                string acStatus = sps.ACLineStatus switch
                {
                    0 => "Running on Battery",
                    1 => "Plugged In (Charging/AC Power)",
                    _ => "Unknown"
                };
                return (percent, acStatus);
            }
            return (0, "Unknown");
        }

        private static string ExtractValue(string textUpper, string labelUpper, string unit)
        {
            string pattern = labelUpper + @".{0,50}?([\d,\.]+)\s*" + Regex.Escape(unit);
            var match = Regex.Match(textUpper, pattern, RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value + (string.IsNullOrEmpty(unit) ? "" : " " + unit) : "Not found";
        }

        private static double ExtractNumber(string text)
        {
            var match = Regex.Match(text.Replace(",", ""), @"(\d+(\.\d+)?)");
            return match.Success ? double.Parse(match.Groups[1].Value) : 0;
        }

        private static void LogToCsv(string csvPath, double designCap, double fullCap, double currentCap, double percent, double health, string powerStatus)
        {
            bool writeHeader = !File.Exists(csvPath);
            using (var writer = new StreamWriter(csvPath, append: true))
            {
                if (writeHeader)
                {
                    writer.WriteLine("Timestamp,PowerSource,DesignCapacity(mWh),FullChargeCapacity(mWh),CurrentCapacity(mWh),CurrentCharge(%),BatteryHealth(%)");
                }

                string line = $"{DateTime.Now},{powerStatus},{designCap},{fullCap},{currentCap},{percent:F0},{health:F2}";
                writer.WriteLine(line);
            }
        }
    }
}
