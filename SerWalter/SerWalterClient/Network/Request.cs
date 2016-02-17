using Newtonsoft.Json;
using SerWalterClient.Data;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace SerWalterClient.Network
{
    internal class Request
    {
        public static string ServiceAddress;

        public static List<Member> GetMembers()
        {
            MembersResponse response = JsonConvert.DeserializeObject<MembersResponse>(Send("pull/members", null));
            return response == null ? null : response.members;
        }

        public static string Send(string cmd, object data)
        {
            return Send(cmd, JsonConvert.SerializeObject(data));
        }

        public static string Send(string cmd, string data)
        {
            NameValueCollection postData = new NameValueCollection();
            postData["cmd"] = cmd;
            postData["data"] = data;

            return sendRequest(postData);
        }

        private static string sendRequest(NameValueCollection postData)
        {
            if (ServiceAddress != null)
            {
                using (WebClient client = new WebClient())
                {
                    byte[] response = client.UploadValues(string.Format("http://{0}/index.php", ServiceAddress), postData);

                    return Encoding.Default.GetString(response);
                }
            }

            return null;
        }
    }
}