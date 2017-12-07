using System.Collections.Generic;
using System.Linq;
using System.IO;
using MediaDevices;

namespace Getting_USB_Devices
{
    internal class DeviceSearcher : IDeviceSearcher
    {
        public List<UsbDevice> GetDevices()
        {
            var devices = new List<UsbDevice>();
            var drives = DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Removable);
            var mtpDevices = MediaDevice.GetDevices();
            foreach (var device in mtpDevices)
            {
                device.Connect();
                if (device.DeviceType != DeviceType.Generic)
                {
                    devices.Add(new UsbDevice(device.FriendlyName, null, null, null, true, null));
                }
            }
            devices.AddRange(drives.Select(drive => new UsbDevice(drive.Name,
                ConvertBytesToMegaBytesString(drive.TotalFreeSpace),
                ConvertBytesToMegaBytesString(drive.TotalSize - drive.TotalFreeSpace), ConvertBytesToMegaBytesString(drive.TotalSize),
                false, drive.VolumeLabel)));
            return devices;
        }

        private static string ConvertBytesToMegaBytesString(long value)
        {
            double megaBytes = (value / 1024) / 1024;
            return $"{megaBytes} MB";
        }
    }
}
