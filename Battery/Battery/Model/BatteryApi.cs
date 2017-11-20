using System;
using System.Management;
using System.Diagnostics;

namespace Battery
{
    internal class BatteryApi
    {
        private static BatteryApi _instance;

        private const string GetWmiBatterySqlQuery = "Select * FROM Win32_Battery";
        private const string BatteryStatusPropertyName = "BatteryStatus";
        private const string BatteryEstimatedChargeRemainingPropertyName = "EstimatedChargeRemaining";
        private const string BatteryEstimatedRuntimePropertyName = "EstimatedRunTime";

        private BatteryApi()
        { }

        public static BatteryApi GetInstance()
        {
            return _instance ?? (_instance = new BatteryApi());
        }

        public BatteryCondition GetCurrentBatteryCondition()
        {
            var query = new ObjectQuery(GetWmiBatterySqlQuery);
            var searcher = new ManagementObjectSearcher(query);
            var collection = searcher.Get();
            var batteryCondition = new BatteryCondition();
            foreach (var coll in collection)
            {
                var wmiBattery = (ManagementObject) coll;
                batteryCondition
                    .SetPlugType(Convert.ToInt32(wmiBattery[BatteryStatusPropertyName]));
                batteryCondition
                    .SetChargeStatus(Convert.ToInt32(wmiBattery[BatteryEstimatedChargeRemainingPropertyName]));
                batteryCondition
                    .SetEstimatedRunTime(Convert.ToInt32(wmiBattery[BatteryEstimatedRuntimePropertyName]));
            }
            return batteryCondition;
        }

        public void SetPowerTimeout(int minutes)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = "/c powercfg /x -monitor-timeout-dc " + minutes
                }
            };
            process.Start();
        }
    }
}
