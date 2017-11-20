using System;
using System.Windows.Forms;
using System.Threading;

namespace Battery
{
    public partial class BatteryViewer : Form
    {
        private BatteryApi _batteryApi;
        private Thread _batteryConditionUpdater;
        private bool _isBatteryConditionUpdaterContinueWork;
        private readonly int _batteryConditionUpdatingFrequency = 2000;

        public BatteryViewer()
        {
            InitializeComponent();
        }

        private void BatteryViewerLoad(object sender, EventArgs e)
        {
            _batteryApi = BatteryApi.GetInstance();
            _batteryApi.SetPowerTimeout(60);
            _isBatteryConditionUpdaterContinueWork = true;
            _batteryConditionUpdater = new Thread(UpdateBatteryConditIonProcedure);
            _batteryConditionUpdater.Start();
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            TurnOffBatteryConditionUpdater();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            System.Windows.Forms.Application.Exit();
        }

        private void UpdateBatteryConditIonProcedure()
        {
            while (_isBatteryConditionUpdaterContinueWork)
            {
                var batteryCondition = _batteryApi.GetCurrentBatteryCondition();
                UpdateBatteryCondition(batteryCondition);
                Thread.Sleep(_batteryConditionUpdatingFrequency);
            }
        }

        private delegate void UpdateBatteryConditionCallBack(BatteryCondition batteryCondition);

        private void UpdateBatteryCondition(BatteryCondition batteryCondition)
        {
            if (batteryListBox.InvokeRequired)
            {
                UpdateBatteryConditionCallBack callBack = UpdateBatteryCondition;
                Invoke(callBack, batteryCondition);
            }
            else
            {
                SetUpdatedBatteryCondition(batteryCondition);
            }
        }

        private void SetUpdatedBatteryCondition(BatteryCondition batteryCondition) 
        {
            batteryListBox.Items.Clear();
            batteryListBox.Items.Add($"Battery plug type: \t\t{batteryCondition.PlugType}");
            batteryListBox.Items.Add($"Battery charge status: \t{batteryCondition.ChargeStatus}");
            batteryListBox.Items.Add($"Battery estimated runtime: \t{batteryCondition.EstimatedRunTime}");
        }

        private void TurnOffBatteryConditionUpdater()
        {
            _isBatteryConditionUpdaterContinueWork = false;
            _batteryConditionUpdater.Abort();
        }

        private void PowerTimeoutTrackBarScroll(object sender, EventArgs e)
        {
            int powerTimeoutInMunites = powerTimeoutTrackBar.Value;
            if (powerTimeoutInMunites == 0)
            {
                powerTimeoutInMunites = 1;
            }
            _batteryApi.SetPowerTimeout(powerTimeoutInMunites);
        }

        private void BatteryListBoxSelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
