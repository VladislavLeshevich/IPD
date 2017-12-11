using System.Net.NetworkInformation;

namespace Getting_WIFI_Networks
{
    class NetworkPing
    {
        public string PingToAddress(string address)
        {
            var ping = new Ping();
            PingReply pingReply;
            try
            {
                pingReply = ping.Send(address);
            }
            catch (PingException e)
            {
                return "Network connection error";
            }
            return "RoundTripTime: " + pingReply?.RoundtripTime + "\r\nStatus: " + pingReply?.Status + "\r\nAddress: " +
                   pingReply?.Address;
        }
    }
}
