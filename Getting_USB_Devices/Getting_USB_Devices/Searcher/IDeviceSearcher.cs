using System.Collections.Generic;

namespace Getting_USB_Devices
{
    internal interface IDeviceSearcher
    {
        List<UsbDevice> GetDevices();
    }
}