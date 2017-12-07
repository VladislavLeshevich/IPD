using System.Linq;
using UsbEject;

namespace Getting_USB_Devices
{
    internal class UsbDevice
    {
        public string Name { get; set; }
        public string TotalFreeSpace { get; set; }
        public string OccupiedSpace { get; set; }
        public string TotalSize { get; set; }
        public bool IsMtp { get; set; }
        public string VolumeName { get; set; }

        public UsbDevice(string name, string totalFreeSpace, string occupiedSpace, string totalSize, bool isMtp, string volumeName)
        {
            Name = name;
            TotalFreeSpace = totalFreeSpace;
            OccupiedSpace = occupiedSpace;
            TotalSize = totalSize;
            IsMtp = isMtp;
            VolumeName = volumeName;
        }

        public bool Eject()
        {
            var ejectedDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == Name.Remove(2));
            ejectedDevice?.Eject(false);
            ejectedDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == Name.Remove(2));
            return ejectedDevice == null;
        }
    }
}
