using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace SerWalterClient.Network
{
    internal class Request
    {
        public static string ServiceAddress;

        public static string Send(string cmd, string data)
        {
            NameValueCollection postData = new NameValueCollection();
            postData.Add("cmd", cmd);
            postData.Add("data", data);

            return sendRequest(postData);
        }

        private static string sendRequest(NameValueCollection postData)
        {
            if (ServiceAddress != null)
            {
                using (WebClient client = new WebClient())
                {
                    byte[] response = client.UploadValues(string.Format("http://{0}", ServiceAddress), postData);

                    return Encoding.Default.GetString(response);
                }
            }

            return null;
        }
    }
}