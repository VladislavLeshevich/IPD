using System.Collections.Generic;

namespace WMI
{
    interface IDevices
    {
        List<DeviceInfo> FindDevices();
    }
}
