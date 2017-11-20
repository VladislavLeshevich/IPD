namespace Battery
{
    internal class BatteryCondition
    {
        public string PlugType { get; private set; }
        public string ChargeStatus { get; private set; }
        public string EstimatedRunTime { get; private set; }

        private enum PlugTypeEnum : short { Battery = 1, AC = 2};
        private const int MaxBatteryStatus = 100;
        private const int MinBatteryStatus = 0;
        private const string BatteryIsChargingMessage = "battery is charging";

        public void SetPlugType(int plugTypeId)
        {
            PlugType = ((PlugTypeEnum) plugTypeId).ToString();
        }

        public void SetChargeStatus(int chargeStatus)
        {
            if(IsChargeStatusValid(chargeStatus))
            {
                ChargeStatus = $"{chargeStatus} %";
            }
        }
        
        public void SetEstimatedRunTime(int estimatedRunTime)
        {
            if (!IsEstimatedRunTimeValid(estimatedRunTime)) return;
            EstimatedRunTime = IsEstimatedRunTimeOfChargingBattery(estimatedRunTime)
                ? BatteryIsChargingMessage
                : $"{estimatedRunTime} minutes";
        }

        private static bool IsChargeStatusValid(int chargeStatus)
        {
            return chargeStatus > MinBatteryStatus && chargeStatus <= MaxBatteryStatus;
        }

        private static bool IsEstimatedRunTimeValid(int estimatedRunTime)
        {
            return estimatedRunTime > 0;
        }

        private static bool IsEstimatedRunTimeOfChargingBattery(int estimatedRunTime)
        {
            const uint estimatedRunTimeOfChargingBattery = 71582788;
            return estimatedRunTime == estimatedRunTimeOfChargingBattery;
        }
    }
}
