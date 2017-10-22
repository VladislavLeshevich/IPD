namespace WMI
{
    class DeviceInfo
    {
        private string DeviceID;
        private string VendorID;

        public DeviceInfo(string deviceID, string vendorID)
        {
            DeviceID = deviceID;
            VendorID = vendorID;
        }

        public string GetDeviceID()
        {
            return DeviceID;
        }

        public string GetVendorID()
        {
            return VendorID;
        }
    }
}
