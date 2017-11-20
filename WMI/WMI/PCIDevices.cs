using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;

namespace WMI
{
    class PCIDevices : IDevices
    {
        Regex deviceID;
        Regex vendorID;
        ManagementObjectSearcher pciDeviceList;        

        public PCIDevices()
        {
            deviceID = new Regex("DEV_.{4}");
            vendorID = new Regex("VEN_.{4}");
            pciDeviceList = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE 'PCI%'");
        }

        public List<DeviceInfo> FindDevices()
        {                  
            List<DeviceInfo> listDeviceInfo = new List<DeviceInfo>();

            foreach (var item in pciDeviceList.Get())
            {
                var info = item["DeviceID"].ToString();

                var deviceIDTemp = deviceID.Match(info).Value.Substring(4).ToLower();
                var vendorIDTemp = vendorID.Match(info).Value.Substring(4).ToLower();
                DeviceInfo deviceInfo = FindDeviceInText(deviceIDTemp, vendorIDTemp);
                if (deviceInfo != null)
                {
                    listDeviceInfo.Add(deviceInfo);
                }
            }

            return listDeviceInfo;
        }

        private static DeviceInfo FindDeviceInText(string dev, string ven)
        {
            var filePci = new StreamReader("pci_ids.txt");
            var vendor = new Regex("^" + ven + "  ");
            var device = new Regex("^\\t" + dev + "  ");

            while (!filePci.EndOfStream)
            {
                var vendorText = filePci.ReadLine();
                if (vendorText != null && vendor.Match(vendorText).Success)
                {
                    while (!filePci.EndOfStream)
                    {
                        var deviceText = filePci.ReadLine();
                        if (deviceText == null || !device.Match(deviceText).Success)
                            continue;
                        return new DeviceInfo(deviceText.Substring(7), vendorText.Substring(6));                                            
                    }
                }              
            }

            return null;
        }
    }
}
