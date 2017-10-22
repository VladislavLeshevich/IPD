using System;

namespace WMI
{
    class Program
    {       
        public static void Main(string[] args)
        {
            IDevices devices = new PCIDevices();
            foreach (var device in devices.FindDevices())
            {
                Console.WriteLine("VendorID: {0} , DeviceID {1}", device.GetVendorID(), device.GetDeviceID());
            }
        }
    }
}